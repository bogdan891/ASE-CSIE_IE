import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

# 1) Matrice ierarhie + dendrogramă (SciPy)
from scipy.cluster.hierarchy import linkage, dendrogram

# 2) Clustering ierarhic (scikit-learn)
from sklearn.cluster import AgglomerativeClustering

# 3) Indici Silhouette
from sklearn.metrics import silhouette_score, silhouette_samples

# Preprocesare
from sklearn.preprocessing import StandardScaler

# Plotare în 2D cu PCA (pentru vizualizare)
from sklearn.decomposition import PCA


# =========================================================
# 0) PREPROCESARE: TRATARE VALORI LIPSA
# =========================================================
def inlocuire_nan(df: pd.DataFrame):
    """
    Înlocuiește valorile lipsă (NaN):
      - numeric: cu media coloanei
      - nenumeric (categoric/text): cu moda coloanei
    Modifică DataFrame-ul direct (inplace).
    """
    for col in df.columns:
        if df[col].isnull().any():
            if pd.api.types.is_numeric_dtype(df[col]):
                df[col].fillna(df[col].mean(), inplace=True)
            else:
                df[col].fillna(df[col].mode()[0], inplace=True)


# =========================================================
# 1) DENDROGRAMĂ + PRAG (THRESHOLD)
# =========================================================
def plot_dendrogram_with_threshold(Z, labels, threshold, title):
    """
    Plotează dendrograma folosind matricea ierarhiei Z.
    - color_threshold: colorează clusterii formați sub pragul dat
    - linia roșie: pragul folosit (vizualizează tăierea dendrogramei)
    """
    plt.figure(figsize=(8, 6))
    plt.title(title)

    dendrogram(Z, labels=labels, color_threshold=threshold)

    plt.axhline(y=threshold, color='red', linestyle='--',
                label=f"threshold = {threshold:.2f}")

    plt.legend()
    plt.tight_layout()
    plt.show()


# =========================================================
# 2) SILHOUETTE PLOT (PE CLUSTERE)
# =========================================================
def plot_silhouette(X, labels, title):
    """
    Construiește silhouette plot:
      - silhouette_samples(X, labels) => valoare silhouette pe fiecare instanță
      - aranjăm valorile pe fiecare cluster și le afișăm ca benzi
      - linia roșie verticală = media globală silhouette
    """
    s_vals = silhouette_samples(X, labels)          # silhouette per instanță
    s_mean = np.mean(s_vals)                       # silhouette mediu global
    unique_clusters = np.unique(labels)

    plt.figure(figsize=(6, 5))
    y_lower = 10  # offset vertical între blocurile de clustere

    for i, clust in enumerate(unique_clusters):
        # valorile silhouette ale instanțelor din clusterul curent
        c_sil = s_vals[labels == clust]
        c_sil.sort()

        y_upper = y_lower + len(c_sil)

        # culoare diferită pe cluster (dintr-o paletă)
        color = plt.cm.Set1(i % 9)

        # umplem zona 0..silhouette pentru instanțele din cluster
        plt.fill_between(np.arange(y_lower, y_upper), 0, c_sil,
                         facecolor=color, alpha=0.7)

        # etichetă cluster pe axa y
        plt.text(-0.05, (y_lower + y_upper) / 2, str(clust))
        y_lower = y_upper + 10

    # linia mediei silhouette
    plt.axvline(x=s_mean, color='red', linestyle='--',
                label=f"Mean Silhouette = {s_mean:.2f}")

    plt.title(title)
    plt.xlabel("Valoare silhouette")
    plt.ylabel("Instanțe (grupate pe clustere)")
    plt.xlim([-0.1, 1])
    plt.legend()
    plt.tight_layout()
    plt.show()


# =========================================================
# 3) HISTOGRAME PE CLUSTERE (PENTRU VARIABILE NUMERICE)
# =========================================================
def plot_histograms(df, labels, numeric_cols, partition_name):
    """
    Pentru fiecare variabilă numerică:
      - plotează histograme suprapuse pe clustere
      - util pentru interpretarea clusterelor (profilare)
    """
    clusters = np.unique(labels)

    for col in numeric_cols:
        plt.figure(figsize=(8, 5))
        plt.title(f"Histograma variabilei '{col}' | {partition_name}")

        for cl in clusters:
            subset = df.loc[labels == cl, col]
            plt.hist(subset, alpha=0.5, label=f"Cluster {cl}")

        plt.xlabel(col)
        plt.legend()
        plt.tight_layout()
        plt.show()


# =========================================================
# 4) VIZUALIZARE CLUSTERE IN 2D CU PCA
# =========================================================
def plot_partition_in_pca(X, labels, title, index_labels=None):
    """
    Proiectează datele în 2D cu PCA și colorează punctele după cluster.
    Aceasta este doar o vizualizare (PCA nu influențează clusteringul).
    """
    pca = PCA(n_components=2)
    X_2d = pca.fit_transform(X)

    plt.figure(figsize=(6, 5))
    plt.title(title)

    clusters = np.unique(labels)

    for i, cl in enumerate(clusters):
        color = plt.cm.Set1(i % 9)
        plt.scatter(
            X_2d[labels == cl, 0],
            X_2d[labels == cl, 1],
            c=[color],
            alpha=0.7,
            label=f"Cluster {cl}"
        )

    plt.xlabel("PC1")
    plt.ylabel("PC2")
    plt.legend()

    # (opțional) etichetăm fiecare observație cu indexul (de ex. județ, regiune etc.)
    if index_labels is not None:
        for j in range(len(index_labels)):
            plt.text(X_2d[j, 0], X_2d[j, 1], str(index_labels[j]), fontsize=7)

    plt.tight_layout()
    plt.show()


# =========================================================
# 5) MAIN: PIPELINE COMPLET CLUSTERING IERARHIC
# =========================================================
def main():
    # -----------------------------------------------------
    # 5.1) CITIRE DATE + PREPROCESARE
    # -----------------------------------------------------
    df = pd.read_csv("teritorial_2022.csv", index_col=0)
    inlocuire_nan(df)

    # Selectăm doar coloanele numerice pentru clustering
    numeric_cols = df.select_dtypes(include=[np.number]).columns.tolist()
    X = df[numeric_cols].values

    # Standardizare (recomandat pentru distanțe euclidiene și Ward)
    X = StandardScaler().fit_transform(X)

    # -----------------------------------------------------
    # 5.2) MATRICE IERARHIE (LINKAGE) - METODA WARD
    # -----------------------------------------------------
    # Z conține "fuziunile": la fiecare pas se combină două clustere.
    Z = linkage(X, method='ward')

    print("\n=== Primele 5 fuziuni (matrice ierarhie Z) ===")
    print(Z[:5, :])

    # -----------------------------------------------------
    # 5.3) ESTIMARE k OPTIM (EURISTIC: MAXIMUL SALTULUI PE DISTANȚE)
    # -----------------------------------------------------
    # Z[:,2] sunt distanțele la care se fac fuziunile.
    # Luăm diferențele consecutive și căutăm "cel mai mare salt"
    # (similar cu o idee de tip "elbow", dar aplicată pe fuziuni).
    n = X.shape[0]  # număr observații

    distances = Z[1:, 2] - Z[:-1, 2]
    idx_max = np.argmax(distances) + 1

    # Dacă după idx_max "se rupe" bine, sugerăm k = n - idx_max
    k_opt = n - idx_max
    print(f"Partiție estimată ca optimă: k = {k_opt}")

    # Prag pentru dendrogramă: între cele două distanțe unde apare saltul
    if idx_max < Z.shape[0]:
        threshold_opt = (Z[idx_max, 2] + Z[idx_max - 1, 2]) / 2
    else:
        threshold_opt = Z[idx_max - 1, 2]

    # -----------------------------------------------------
    # 5.4) O A DOUA PARTIȚIE "FIXĂ" (EX: k=5) PENTRU COMPARAȚIE
    # -----------------------------------------------------
    k_other = 5

    # Relație: la un set cu n observații, pentru a rămâne cu k clustere
    # trebuie făcute n-k fuziuni.
    nr_jonctiuni_k = n - k_other

    if nr_jonctiuni_k > 0:
        threshold_k = (Z[nr_jonctiuni_k, 2] + Z[nr_jonctiuni_k - 1, 2]) / 2
    else:
        threshold_k = 0

    print(f"\nPartiție comparativă: k = {k_other}, threshold_k ≈ {threshold_k:.2f}")

    # -----------------------------------------------------
    # 5.5) CONSTRUIRE ETICHETE CLUSTERE (AgglomerativeClustering)
    # -----------------------------------------------------
    # Partiție optimă
    hc_opt = AgglomerativeClustering(n_clusters=k_opt, linkage='ward')
    labels_opt = hc_opt.fit_predict(X)
    df["Cluster_Optim"] = labels_opt

    # Partiție fixă (k_other)
    hc_k = AgglomerativeClustering(n_clusters=k_other, linkage='ward')
    labels_k = hc_k.fit_predict(X)
    df[f"Cluster_{k_other}"] = labels_k

    # -----------------------------------------------------
    # 5.6) DENDROGRAME CU PRAGURI (OPTIM + k FIX)
    # -----------------------------------------------------
    plot_dendrogram_with_threshold(
        Z, df.index.to_list(), threshold_opt,
        f"Dendrogramă | partiție optimă (k={k_opt})"
    )

    plot_dendrogram_with_threshold(
        Z, df.index.to_list(), threshold_k,
        f"Dendrogramă | partiție k={k_other}"
    )

    # -----------------------------------------------------
    # 5.7) SILHOUETTE (EVALUARE CALITATE CLUSTERE)
    # -----------------------------------------------------
    # Partiție optimă
    sil_opt_global = silhouette_score(X, labels_opt)
    print(f"\nSilhouette global | k_opt={k_opt}: {sil_opt_global:.2f}")
    plot_silhouette(X, labels_opt, f"Silhouette | partiție optimă (k={k_opt})")

    # Partiție k fix
    sil_k_global = silhouette_score(X, labels_k)
    print(f"Silhouette global | k={k_other}: {sil_k_global:.2f}")
    plot_silhouette(X, labels_k, f"Silhouette | partiție k={k_other}")

    # -----------------------------------------------------
    # 5.8) PROFILAREA CLUSTERELOR: HISTOGRAME PE VARIABILE
    # -----------------------------------------------------
    plot_histograms(df, labels_opt, numeric_cols, f"Partiție optimă (k={k_opt})")
    plot_histograms(df, labels_k, numeric_cols, f"Partiție k={k_other}")

    # -----------------------------------------------------
    # 5.9) VIZUALIZARE 2D CU PCA (DOAR PENTRU INTUIȚIE)
    # -----------------------------------------------------
    plot_partition_in_pca(X, labels_opt, f"Partiție optimă (k={k_opt}) | PCA", df.index)
    plot_partition_in_pca(X, labels_k, f"Partiție k={k_other} | PCA", df.index)

    # -----------------------------------------------------
    # 5.10) SALVARE REZULTATE
    # -----------------------------------------------------
    df.to_csv("Rezultate_Cluster_Finale.csv")
    print("\n=== Rezultate salvate în 'Rezultate_Cluster_Finale.csv' ===")


if __name__ == "__main__":
    main()
