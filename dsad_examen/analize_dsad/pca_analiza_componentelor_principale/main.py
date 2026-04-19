import matplotlib.pyplot as plt
import pandas as pd
from sklearn.decomposition import PCA
from sklearn.preprocessing import StandardScaler
import seaborn as sns
import numpy as np


# =========================================================
# 1) CITIRE DATE + TRATARE VALORI LIPSA
# =========================================================

# Citim setul de date; index_col=0 => prima coloană devine index (nume observații / ID-uri)
data = pd.read_csv("ConsumAlimentar.csv", index_col=0)

# Imputare: înlocuim valorile lipsă (NaN) cu media coloanei (doar pentru variabile numerice)
data = data.apply(lambda col: col.fillna(col.mean()), axis="rows")

# Extragem valorile numerice în format NumPy (matrice n x p)
data_numeric = data.values


# =========================================================
# 2) STANDARDIZARE (NECESARA IN PCA)
# =========================================================

# Standardizare: fiecare variabilă -> medie 0, deviație standard 1
# Motiv: PCA este sensibil la scale. Variabilele cu valori mari ar domina rezultatul.
data_numeric = StandardScaler().fit_transform(data_numeric)


# =========================================================
# 3) PCA INITIAL (PENTRU EIGENVALUES SI VARIANTA EXPLICATA)
# =========================================================

# PCA fără a fixa numărul de componente (calculăm toate componentele posibile)
pca = PCA()
pca.fit(data_numeric)

# Eigenvalues (valoare proprie) = varianța explicată de fiecare componentă principală
eigenvalues = pca.explained_variance_

# Procent din varianța totală explicat de fiecare componentă
eigen_values_ratio = pca.explained_variance_ratio_ * 100

# Procent cumulat (suma procentelor până la componenta k)
cumsum = np.cumsum(eigen_values_ratio)

# Tabel pentru raport: eigenvalues + procente + cumul
df_varianta = pd.DataFrame({
    "Valoare Proprie": eigenvalues,
    "Varianta explicata %": eigen_values_ratio,
    "Varianta cumulata %": cumsum
}, index=[f"C{i+1}" for i in range(len(eigenvalues))])

print(df_varianta)


# =========================================================
# 4) SCREE PLOT + CRITERII DE SELECTIE A NR. DE COMPONENTE
# =========================================================

def scree_plot(eigenvalues, threshold=79):
    """
    Scree plot + 3 criterii uzuale de selecție:
      1) Kaiser: păstrăm componentele cu eigenvalue > 1
      2) Prag de varianță cumulată: păstrăm primele componente până depășim threshold%
      3) Cattell (cot): punctul unde scăderea eigenvalues devine mică (euristic)

    Returnează:
      - kaiser: numărul de componente conform Kaiser
      - cattell: aproximare a componentelor până la “cot”
      - thres: numărul de componente până la pragul de varianță
    """
    plt.title("Scree Plot (eigenvalues)")

    m = len(eigenvalues)
    indices = np.arange(1, m + 1)

    # Curba eigenvalues
    plt.plot(indices, eigenvalues, "r-", label="Valori proprii")

    # Linie Kaiser (eigenvalue = 1)
    plt.axhline(y=1, color="b", linestyle="--", label="Kaiser (λ = 1)")

    # Prag de varianță cumulată calculat din eigenvalues
    # (echivalent cu explained_variance_ratio, doar că îl recalculăm explicit)
    thres_praguri = np.cumsum(eigenvalues) * 100 / np.sum(eigenvalues)
    thres = np.where(thres_praguri > threshold)[0][0] + 1

    # Marcăm pe grafic componenta unde depășim threshold%
    if thres <= m:
        plt.axhline(
            y=eigenvalues[thres - 1],
            color="y",
            linestyle="--",
            label=f"Prag varianță cumulată > {threshold}%"
        )

    # “Cotul” (Cattell) printr-o regulă simplificată:
    # când diferența dintre valori consecutive devine mică (aproape 0),
    # considerăm că graficul se aplatizează.
    cattell_vec = np.where(np.diff(eigenvalues) > -0.1)[0]
    cattell = cattell_vec[0] + 1 if len(cattell_vec) > 0 else None

    if cattell is not None:
        plt.axhline(
            y=eigenvalues[cattell - 1],
            color="g",
            linestyle="--",
            label="Cattell (zona de aplatizare)"
        )

    # Număr de componente după Kaiser
    kaiser = np.sum(eigenvalues > 1)

    plt.xlabel("Componentă")
    plt.ylabel("Valoare proprie (λ)")
    plt.legend()
    plt.show()

    return kaiser, cattell, thres


# Calculăm numărul de componente recomandat de fiecare criteriu
kaiser, cattel, thres = scree_plot(eigenvalues, threshold=79)


# =========================================================
# 5) PCA FINAL (CU NR. DE COMPONENTE ALES)
# =========================================================

# Refacem PCA doar cu numărul de componente ales.
# Aici păstrăm varianta "thres" (prag de varianță cumulată).
pca = PCA(n_components=thres)
pca.fit(data_numeric)


# =========================================================
# 6) INCARCATURI FACTORIALE (LOADINGS)
# =========================================================

# Loadings = corelația dintre variabilele originale și componente
# O formulă uzuală: loadings = components_.T * sqrt(eigenvalues)
# (după convenția PCA pe date standardizate)
loadings = pca.components_.T * np.sqrt(eigenvalues[:thres])

df_loadings = pd.DataFrame(
    loadings,
    columns=[f"C{i+1}" for i in range(loadings.shape[1])],
    index=data.columns
)
print(df_loadings)


# =========================================================
# 7) HEATMAP PENTRU LOADINGS (INTERPRETARE RAPIDA)
# =========================================================

def corelograma_loadings(df_loadings):
    plt.title("Corelograma încărcăturilor (loadings)")
    sns.heatmap(df_loadings, center=0, cmap="RdBu", annot=True)
    plt.show()

corelograma_loadings(df_loadings)


# =========================================================
# 8) CERCUL CORELAȚIILOR (PLANUL C1-C2)
# =========================================================

def cerc_corelatii(df_loadings, c1=0, c2=1):
    """
    Reprezentăm variabilele ca vectori în planul (C1, C2).
    Direcția și lungimea vectorului sugerează asocierea cu componentele.
    """
    x = df_loadings.iloc[:, c1]
    y = df_loadings.iloc[:, c2]

    plt.title("Cerc corelații (variabile în planul componentelor)")

    # Cerc unitate (orientativ)
    cerc = plt.Circle((0, 0), 1, fill=False, color="gray")
    plt.gca().add_patch(cerc)

    plt.axhline(y=0, color="gray", linewidth=0.8)
    plt.axvline(x=0, color="gray", linewidth=0.8)

    # Vectori pentru fiecare variabilă
    for i, nume in enumerate(df_loadings.index):
        plt.arrow(
            0, 0, x[i], y[i],
            color="r",
            length_includes_head=True,
            head_width=0.09,
            alpha=0.7
        )
        plt.text(x[i] * 1.06, y[i] * 1.06, nume, fontsize=9)

    plt.xlim(-1.1, 1.1)
    plt.ylim(-1.1, 1.1)
    plt.gca().set_aspect('equal', 'box')
    plt.xlabel(f"C{c1 + 1}")
    plt.ylabel(f"C{c2 + 1}")
    plt.show()

# Cerc corelații pentru primele 2 componente
cerc_corelatii(df_loadings, 0, 1)


# =========================================================
# 9) SCORURI PCA (COORDONATELE OBSERVATIILOR IN SPATIUL COMPONENTELOR)
# =========================================================

# Scoruri = proiecția observațiilor în spațiul componentelor
scores = pca.transform(data_numeric)

df_scores = pd.DataFrame(
    scores,
    columns=[f"C{i+1}" for i in range(scores.shape[1])],
    index=data.index
)
print(df_scores)


# =========================================================
# 10) GRAFIC OBSERVATII IN PLANUL COMPONENTELOR (C1-C2)
# =========================================================

def plot_componente_scoruri(df_scores, c1=0, c2=1):
    plt.title("Observații în planul componentelor (scoruri)")
    plt.scatter(df_scores.iloc[:, c1], df_scores.iloc[:, c2], color="b")

    plt.axhline(y=0, linewidth=0.8, color="gray")
    plt.axvline(x=0, linewidth=0.8, color="gray")

    plt.xlabel(f"C{c1 + 1}")
    plt.ylabel(f"C{c2 + 1}")

    # Etichetăm punctele cu numele observațiilor (indexul)
    for idx in df_scores.index:
        x_val = df_scores.loc[idx, f"C{c1 + 1}"]
        y_val = df_scores.loc[idx, f"C{c2 + 1}"]
        plt.text(x_val, y_val, str(idx), fontsize=8)

    plt.show()

plot_componente_scoruri(df_scores, 0, 1)


# =========================================================
# 11) INDICATORI DE CALITATE: COSINUSURI, COMUNALITATI, CONTRIBUTII
# =========================================================

def cosinusuri_comunalitati_contributii(df_loadings, df_scores):
    """
    - Cosinusuri^2 (pentru variabile): loadings^2
      indică cât de bine este reprezentată variabila pe fiecare componentă.

    - Comunalități (pentru variabile): suma cos^2 pe componente
      indică proporția din varianta variabilei explicată de componentele păstrate.

    - Contribuții (pentru observații): (score^2) / (suma score^2 pe componentă)
      indică ce observații contribuie cel mai mult la o componentă.
    """
    # Cosinusuri^2 pentru variabile
    cos = df_loadings ** 2

    # Comunalități pentru variabile
    comunalitati = pd.DataFrame(cos.sum(axis="columns"), columns=["Comunalitati"])

    # Contribuțiile observațiilor la componente:
    # (IMPORTANT: împărțirea se face pe coloană, adică pe fiecare componentă separat)
    contributii = (df_scores ** 2) / (df_scores ** 2).sum(axis=0)

    return cos, comunalitati, contributii


cos, comunalitati, contributii = cosinusuri_comunalitati_contributii(df_loadings, df_scores)

print("\nCOSINUS^2 (variabile x componente):\n", cos)
print("\nCOMUNALITATI (pe variabile):\n", comunalitati)
print("\nCONTRIBUTII (observatii la componente):\n", contributii)


# =========================================================
# 12) HEATMAP PENTRU COMUNALITATI
# =========================================================

def corelograma_comunalitati(comunalitati):
    plt.title("Comunalități (calitatea reprezentării variabilelor)")
    sns.heatmap(comunalitati, annot=True, cmap="YlGnBu")
    plt.show()

corelograma_comunalitati(comunalitati)
