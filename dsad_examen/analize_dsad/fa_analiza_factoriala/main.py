import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns

from sklearn.preprocessing import StandardScaler
from factor_analyzer import FactorAnalyzer, calculate_bartlett_sphericity, calculate_kmo


# =========================================================
# 1) CITIRE DATE + TRATARE VALORI LIPSA + STANDARDIZARE
# =========================================================

# Citim setul de date; index_col=0 presupune ca prima coloană este un ID / etichetă.
data = pd.read_csv("ConsumAlimentar.csv", index_col=0)

# Înlocuim valorile lipsă (NaN) cu media pe coloană (imputare simplă).
# axis="rows" înseamnă că aplicăm funcția pe fiecare coloană (nu pe rânduri).
data = data.apply(lambda col: col.fillna(col.mean()), axis="rows")

# Standardizare: transformăm fiecare variabilă astfel încât să aibă medie 0 și deviație standard 1.
# E important pentru FA, ca variabilele să fie comparabile.
data_transf = StandardScaler().fit_transform(data)


# =========================================================
# 2) TESTE DE ADECVARE PENTRU ANALIZA FACTORIALA (FA)
# =========================================================

# Testul Bartlett verifică dacă matricea de corelații este semnificativ diferită de identitatea.
# Dacă p-value < 0.05 => există corelații suficiente => FA e justificată.
chi_square_value, p_value = calculate_bartlett_sphericity(data_transf)
print(f"Bartlett Test: {chi_square_value}, p-value:{p_value}\n")

# Testul KMO (Kaiser-Meyer-Olkin) măsoară dacă datele sunt potrivite pentru FA.
# Reguli uzuale:
#   KMO < 0.5 slab
#   0.5-0.6 mediocru
#   0.6-0.7 acceptabil
#   0.7-0.8 bun
#   >0.8 foarte bun
kmo_all, kmo_model = calculate_kmo(data_transf)
print(f"Testul KMO: {kmo_model}\n")


# =========================================================
# 3) EXTRAGEREA VALORILOR PROPRII (EIGENVALUES) PENTRU A ALEGE NR. DE FACTORI
# =========================================================

# Inițial "fit" cu numărul maxim de factori (=nr. variabile), ca să putem obține eigenvalues.
# rotation="varimax" => rotație ortogonală pentru interpretare mai clară.
fa = FactorAnalyzer(n_factors=data_transf.shape[1], rotation="varimax")
fa.fit(data_transf)

# Eigenvalues = varianța explicată de fiecare factor (în ordinea factorilor).
eigenvalues = fa.get_eigenvalues()[0]

# Procent din varianță explicată de fiecare factor
var_percent = eigenvalues * 100 / np.sum(eigenvalues)

# Varianță cumulată (câtă varianță e explicată de primii k factori)
var_cum = np.cumsum(var_percent)

# Construim un tabel cu rezultatele pentru raport / interpretare.
tabel_varianta = pd.DataFrame({
    "Valoare Proprie": eigenvalues,
    "% Varianta Explicata": var_percent,
    "% Varianta Cumulata": var_cum
}, index=[f"F{i+1}" for i in range(len(eigenvalues))])


# =========================================================
# 4) SCREE PLOT + CRITERII DE SELECTIE A FACTORILOR
# =========================================================

def scree_plot(eigenvalues, var_cum, threshold=79):
    """
    Desenează:
      - Scree plot: eigenvalues vs. număr factor
      - Linie Kaiser (eigenvalue=1)
      - Prag de varianță cumulată (ex: 79%)
      - O aproximare a "cotului" (Cattell), folosind o regulă simplificată

    Return:
      - kaiser: nr. factori cu eigenvalue > 1
      - thres: primul k unde varianța cumulată depășește threshold (%)
      - cattell: aproximare a punctului unde graficul se aplatizează
    """
    plt.title("Plot varianta componente plus criterii de relevanta")

    m = len(eigenvalues)
    indices = np.arange(1, m + 1)

    # Linie eigenvalues
    plt.plot(indices, eigenvalues, "r-", label="Valoare proprie factori")

    # Criteriul Kaiser: păstrăm factorii cu eigenvalue > 1
    plt.axhline(y=1, color="b", linestyle="--", label="Kaiser")

    # Prag de varianță cumulată: găsim primul k care depășește threshold (%)
    thres = np.where(var_cum > threshold)[0][0] + 1
    if thres <= m:
        plt.axhline(
            y=eigenvalues[thres - 1],
            color="y",
            linestyle="--",
            label=f"Unde trece de {threshold}%"
        )

    # Cattell (cot): aici e o aproximare.
    # np.diff(eigenvalues) calculează scăderile între eigenvalues consecutive.
    # Când scăderea devine mică (aproape 0), graficul "se aplatizează".
    cattell_index = np.where(np.diff(eigenvalues) > -0.1)[0]
    cattell = cattell_index[0] + 1 if len(cattell_index) > 0 else None
    if cattell is not None:
        plt.axhline(
            y=eigenvalues[cattell - 1],
            color="g",
            linestyle="--",
            label="Unde se aplatizeaza graficul"
        )

    kaiser = np.sum(eigenvalues > 1)

    plt.legend()
    plt.show()

    return kaiser, thres, cattell


# Apelăm funcția de selecție și tipărim valorile obținute.
kaiser, thres, cattell = scree_plot(eigenvalues, var_cum)
print(f"Kaiser: {kaiser}\n thres: {thres}\n cattell:{cattell}\n")


# =========================================================
# 5) REFACEM ANALIZA CU NR. DE FACTORI SELECTAT (thres)
# =========================================================

# method="principal" => extracție prin principal factor / principal axis (în funcție de librărie)
# rotation="varimax" => rotație pentru interpretare clară
fa = FactorAnalyzer(n_factors=thres, rotation="varimax", method="principal")
fa.fit(data_transf)

# Încărcături factoriale: corelația dintre variabile și factori (după rotație).
loadings = pd.DataFrame(
    fa.loadings_,
    index=data.columns,
    columns=[f"F{i+1}" for i in range(fa.loadings_.shape[1])]
)

print(tabel_varianta)
print("\nÎncărcăturile factoriale:\n", loadings.head())


# =========================================================
# 6) CORELOGRAMA INCARCATURILOR FACTORIALE (HEATMAP)
# =========================================================

def corelograma_corelatii(loadings):
    plt.figure(figsize=(10, 7))
    sns.heatmap(loadings, cmap="RdBu", center=0, annot=True)
    plt.title("Corelograma Încărcăturilor Factoriale")
    plt.show()

corelograma_corelatii(loadings)


# =========================================================
# 7) CERCUL CORELAȚIILOR (PLOT PE 2 FACTORI)
# =========================================================

def cerc_corelatii(loadings, c1=0, c2=1):
    """
    Reprezentăm variabilele ca vectori în planul (Factor c1, Factor c2).
    Dacă o variabilă are încărcături mari pe un factor, va “arăta” în direcția lui.
    """
    x = loadings.iloc[:, c1]
    y = loadings.iloc[:, c2]

    plt.title("Cerc Corelatii")

    # Cerc de rază 1: orientativ (în PCA are interpretare clasică, în FA e o vizualizare utilă).
    circle = plt.Circle((0, 0), 1, color="gray", linestyle="--", fill=False)
    plt.gca().add_patch(circle)

    # Axe
    plt.axhline(y=0, color="gray", linewidth=0.8)
    plt.axvline(x=0, color="gray", linewidth=0.8)

    # Vectori pentru fiecare variabilă
    for i, varname in enumerate(loadings.index):
        plt.arrow(
            0, 0, x[i], y[i],
            head_width=0.09,
            color="r",
            alpha=0.7,
            length_includes_head=True
        )
        plt.text(x[i], y[i], varname, fontsize=9)

    # Limite și aspect pătrat
    plt.xlim(-1.1, 1.1)
    plt.ylim(-1.1, 1.1)
    plt.gca().set_aspect('equal', 'box')

    # Etichete (în codul tău scrie C1/C2, deși sunt factori; am păstrat stilul tău)
    plt.xlabel(f"C{c1+1}")
    plt.ylabel(f"C{c2+1}")

    plt.show()

cerc_corelatii(loadings, 0, 1)


# =========================================================
# 8) COMUNALITATI + VARIANTA SPECIFICA
# =========================================================

# Comunalitate = cât din varianta variabilei e explicată de factorii comuni
comunalitati = pd.DataFrame(
    fa.get_communalities(),
    index=loadings.index,
    columns=["Comunalitati"]
)

# Varianta specifică = 1 - comunalitate (partea neexplicată de factorii comuni)
varianta_specifica = pd.DataFrame(
    1 - comunalitati.values,
    index=comunalitati.index,
    columns=["Varianta Specifica"]
)

print(comunalitati)
print(varianta_specifica)


def corelograme_comunalitati_variante_specifice(comunalitati, varianta_specifica):
    plt.title("Corelograma Comunalitati")
    sns.heatmap(comunalitati, cmap="YlGnBu", annot=True, center=0)
    plt.show()

    plt.title("Corelograma Variantelor Specifice")
    sns.heatmap(varianta_specifica, cmap="YlGnBu", annot=True, center=0)
    plt.show()

corelograme_comunalitati_variante_specifice(comunalitati, varianta_specifica)


# =========================================================
# 9) SCORURI FACTORIALE + SCATTERPLOT
# =========================================================

# Scorurile factoriale: poziția fiecărei observații în spațiul factorilor.
# Aici le calculezi manual ca: Z * loadings (aproximare).
# Notă: unele implementări calculează scorurile cu metode dedicate (regresie, Bartlett etc.).
scoruri = pd.DataFrame(
    data_transf @ fa.loadings_,
    index=data.index,
    columns=loadings.columns
)

print(scoruri)


def scatterplot_scoruri(scoruri, c1=0, c2=1):
    x = scoruri.iloc[:, c1]
    y = scoruri.iloc[:, c2]

    plt.title("Scatter Scoruri")
    plt.axhline(y=0, color="gray", linewidth=0.8)
    plt.axvline(x=0, color="gray", linewidth=0.8)

    plt.scatter(x, y, color="blue")
    plt.xlabel(f"{scoruri.columns[c1]}")
    plt.ylabel(f"{scoruri.columns[c2]}")
    plt.show()

scatterplot_scoruri(scoruri, 0, 1)