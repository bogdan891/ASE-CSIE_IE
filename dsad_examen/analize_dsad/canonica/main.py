import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns

from sklearn.preprocessing import StandardScaler
from sklearn.cross_decomposition import CCA


# =========================
# 0) UTILITARE
# =========================

def safe_impute_mean(df: pd.DataFrame) -> pd.DataFrame:
    # imputare cu media pe coloana (numeric only)
    out = df.copy()
    for c in out.columns:
        if pd.api.types.is_numeric_dtype(out[c]):
            out[c] = out[c].fillna(out[c].mean())
    return out

def corr_vec(a, b):
    # corelație Pearson între 2 vectori 1D
    a = np.asarray(a).ravel()
    b = np.asarray(b).ravel()
    return np.corrcoef(a, b)[0, 1]

def corr_matrix(Z, S):
    """
    Corelații între variabilele din Z (n x p) și scoruri S (n x k).
    Return: matrice p x k
    """
    Z = np.asarray(Z)
    S = np.asarray(S)
    p = Z.shape[1]
    k = S.shape[1]
    L = np.zeros((p, k))
    for i in range(p):
        for j in range(k):
            L[i, j] = corr_vec(Z[:, i], S[:, j])
    return L

def set_matplotlib_defaults():
    plt.rcParams["figure.figsize"] = (10, 6)
    plt.rcParams["axes.grid"] = False


# =========================
# 1) CITIRE + PREGATIRE DATE
# =========================

set_matplotlib_defaults()

data = pd.read_csv("ConsumAlimentar.csv", index_col=0)
data = safe_impute_mean(data)

# IMPORTANT: defineste blocurile X si Y
# Exemplu: primele 5 in X, restul in Y (SCHIMBA dupa tema ta)
X_cols = list(data.columns[:5])
Y_cols = list(data.columns[5:])

if len(X_cols) == 0 or len(Y_cols) == 0:
    raise ValueError("Trebuie sa ai cel putin o coloana in X si una in Y.")

X = data[X_cols].values
Y = data[Y_cols].values

# Standardizare separata
scX = StandardScaler()
scY = StandardScaler()
Xz = scX.fit_transform(X)
Yz = scY.fit_transform(Y)

n, p = Xz.shape
_, q = Yz.shape
m = min(p, q)

print(f"Observatii n={n}, variabile X p={p}, variabile Y q={q}, max componente canonice m=min(p,q)={m}")


# =========================
# 2) FIT CCA
# =========================

# Poti reduce n_components daca vrei (de ex. 2)
n_components = m
cca = CCA(n_components=n_components, max_iter=5000)
cca.fit(Xz, Yz)

U, V = cca.transform(Xz, Yz)  # scoruri canonice


# =========================
# 3) CORELATII CANONICE + "SCREE"
# =========================

r_can = np.array([corr_vec(U[:, k], V[:, k]) for k in range(n_components)])
r2 = r_can**2
cum_r2 = np.cumsum(r2)

tabel_cc = pd.DataFrame(
    {"r (corelatie canonica)": r_can, "r^2": r2, "r^2 cumulata": cum_r2},
    index=[f"CC{k+1}" for k in range(n_components)]
)
print("\nCorelatii canonice:\n", tabel_cc)

# Bar chart r si r^2
plt.figure()
plt.title("Corelatii canonice (r)")
plt.bar(np.arange(1, n_components+1), r_can)
plt.axhline(0, linewidth=0.8)
plt.xlabel("Componenta canonica")
plt.ylabel("r")
plt.show()

plt.figure()
plt.title("Varianță comuna pe perechi (r^2)")
plt.bar(np.arange(1, n_components+1), r2)
plt.xlabel("Componenta canonica")
plt.ylabel("r^2")
plt.show()

# "Scree-like": r^2 cumulata
plt.figure()
plt.title("Cumul r^2 (tip scree)")
plt.plot(np.arange(1, n_components+1), cum_r2, marker="o")
plt.xlabel("Componenta canonica")
plt.ylabel("r^2 cumulata")
plt.ylim(0, 1.05)
plt.show()


# =========================
# 4) WEIGHTS, LOADINGS (STRUCTURE), CROSS-LOADINGS
# =========================

# Weights: coeficientii combinatiilor lineare
x_weights = pd.DataFrame(cca.x_weights_, index=X_cols, columns=[f"CC{k+1}" for k in range(n_components)])
y_weights = pd.DataFrame(cca.y_weights_, index=Y_cols, columns=[f"CC{k+1}" for k in range(n_components)])

# Loadings (structure): corr(X var, U) si corr(Y var, V)
x_load = pd.DataFrame(corr_matrix(Xz, U), index=X_cols, columns=[f"CC{k+1}" for k in range(n_components)])
y_load = pd.DataFrame(corr_matrix(Yz, V), index=Y_cols, columns=[f"CC{k+1}" for k in range(n_components)])

# Cross-loadings: corr(X var, V) si corr(Y var, U)
x_cross = pd.DataFrame(corr_matrix(Xz, V), index=X_cols, columns=[f"CC{k+1}" for k in range(n_components)])
y_cross = pd.DataFrame(corr_matrix(Yz, U), index=Y_cols, columns=[f"CC{k+1}" for k in range(n_components)])

print("\nX weights:\n", x_weights)
print("\nY weights:\n", y_weights)
print("\nX loadings (corr X cu U):\n", x_load)
print("\nY loadings (corr Y cu V):\n", y_load)
print("\nX cross-loadings (corr X cu V):\n", x_cross)
print("\nY cross-loadings (corr Y cu U):\n", y_cross)


# =========================
# 5) CORELOGRAME (HEATMAP)
# =========================

def heatmap_df(df, title, cmap="RdBu", center=0):
    plt.figure(figsize=(10, max(4, 0.35 * df.shape[0])))
    sns.heatmap(df, annot=True, cmap=cmap, center=center, linewidths=0.5)
    plt.title(title)
    plt.show()

heatmap_df(x_load, "Corelograma X loadings (corr X cu U)")
heatmap_df(y_load, "Corelograma Y loadings (corr Y cu V)")
heatmap_df(x_weights, "Corelograma X weights (coeficienti U)")
heatmap_df(y_weights, "Corelograma Y weights (coeficienti V)")

# Cross-loadings sunt utile cand vrei sa vezi cum "intra" X in setul Y si invers
heatmap_df(x_cross, "Corelograma X cross-loadings (corr X cu V)")
heatmap_df(y_cross, "Corelograma Y cross-loadings (corr Y cu U)")


# =========================
# 6) SCATTER PLOTS SCORURI (U_k vs V_k) SI (U1 vs U2)
# =========================

def scatter_uv(U, V, k=0):
    plt.figure()
    plt.title(f"Scatter scoruri canonice: U{k+1} vs V{k+1}  (r={r_can[k]:.3f})")
    plt.axhline(0, color="gray", linewidth=0.8)
    plt.axvline(0, color="gray", linewidth=0.8)
    plt.scatter(U[:, k], V[:, k])
    plt.xlabel(f"U{k+1}")
    plt.ylabel(f"V{k+1}")
    plt.show()

for k in range(min(n_components, 3)):
    scatter_uv(U, V, k=k)

if n_components >= 2:
    plt.figure()
    plt.title("Scatter scoruri: U1 vs U2")
    plt.axhline(0, color="gray", linewidth=0.8)
    plt.axvline(0, color="gray", linewidth=0.8)
    plt.scatter(U[:, 0], U[:, 1])
    plt.xlabel("U1")
    plt.ylabel("U2")
    plt.show()

    plt.figure()
    plt.title("Scatter scoruri: V1 vs V2")
    plt.axhline(0, color="gray", linewidth=0.8)
    plt.axvline(0, color="gray", linewidth=0.8)
    plt.scatter(V[:, 0], V[:, 1])
    plt.xlabel("V1")
    plt.ylabel("V2")
    plt.show()


# =========================
# 7) "BIPLOT-ish": vectori loadings in planul (CC1, CC2)
# =========================

def biplot_loadings(loadings_df, title, comp1=0, comp2=1):
    if loadings_df.shape[1] <= max(comp1, comp2):
        print("Nu sunt suficiente componente pentru biplot.")
        return

    x = loadings_df.iloc[:, comp1].values
    y = loadings_df.iloc[:, comp2].values
    labels = loadings_df.index.tolist()

    plt.figure(figsize=(8, 8))
    plt.title(title)

    # Cerc unitate (nu e "cercul corelatiilor" clasic ca la PCA, dar e util vizual)
    circle = plt.Circle((0, 0), 1, color="gray", linestyle="--", fill=False)
    plt.gca().add_patch(circle)

    plt.axhline(0, color="gray", linewidth=0.8)
    plt.axvline(0, color="gray", linewidth=0.8)

    for i in range(len(labels)):
        plt.arrow(0, 0, x[i], y[i], head_width=0.03, alpha=0.8, length_includes_head=True)
        plt.text(x[i], y[i], labels[i], fontsize=9)

    plt.xlim(-1.1, 1.1)
    plt.ylim(-1.1, 1.1)
    plt.gca().set_aspect("equal", "box")
    plt.xlabel(f"CC{comp1+1}")
    plt.ylabel(f"CC{comp2+1}")
    plt.show()

if n_components >= 2:
    biplot_loadings(x_load, "Biplot loadings X (corr X cu U) in planul CC1-CC2", 0, 1)
    biplot_loadings(y_load, "Biplot loadings Y (corr Y cu V) in planul CC1-CC2", 0, 1)


# =========================
# 8) REDUNDANTA (cat din varianta unui set e explicata de variatele canonice ale celuilalt set)
# =========================
# Redundanta pentru X: medie(loadings_X^2 pe variabile) * r^2
# Redundanta pentru Y: medie(loadings_Y^2 pe variabile) * r^2

avg_var_expl_X = (x_load**2).mean(axis=0).values  # pe fiecare componenta
avg_var_expl_Y = (y_load**2).mean(axis=0).values

red_X_given_Y = avg_var_expl_X * r2
red_Y_given_X = avg_var_expl_Y * r2

tabel_red = pd.DataFrame({
    "Avg Var(X) explicata de U": avg_var_expl_X,
    "Avg Var(Y) explicata de V": avg_var_expl_Y,
    "Redundanta X (prin Y)": red_X_given_Y,
    "Redundanta Y (prin X)": red_Y_given_X
}, index=[f"CC{k+1}" for k in range(n_components)])

print("\nRedundanta:\n", tabel_red)

plt.figure()
plt.title("Redundanta pe componente canonice")
plt.plot(np.arange(1, n_components+1), red_X_given_Y, marker="o", label="Redundanta X (prin Y)")
plt.plot(np.arange(1, n_components+1), red_Y_given_X, marker="o", label="Redundanta Y (prin X)")
plt.xlabel("Componenta canonica")
plt.ylabel("Redundanta")
plt.ylim(0, max(0.05, np.max([red_X_given_Y.max(), red_Y_given_X.max()]) * 1.2))
plt.legend()
plt.show()


# =========================
# 9) TEST DE SEMNIFICATIE PRIN PERMUTARI (OPTIONAL, DAR FOARTE UTIL LA EXAMEN)
# =========================
# Ideea: daca rupem legatura dintre X si Y (permuta randurile din Y), corelatiile canonice ar trebui sa scada.
# Facem p-value empiric pentru fiecare CC.

def permutation_test_cca(Xz, Yz, n_components, n_perm=500, random_state=42):
    rng = np.random.default_rng(random_state)
    cca0 = CCA(n_components=n_components, max_iter=5000)
    cca0.fit(Xz, Yz)
    U0, V0 = cca0.transform(Xz, Yz)
    r_obs = np.array([corr_vec(U0[:, k], V0[:, k]) for k in range(n_components)])

    r_perm = np.zeros((n_perm, n_components))
    for b in range(n_perm):
        idx = rng.permutation(Xz.shape[0])
        Yp = Yz[idx, :]
        ccab = CCA(n_components=n_components, max_iter=5000)
        ccab.fit(Xz, Yp)
        Ub, Vb = ccab.transform(Xz, Yp)
        r_perm[b, :] = [corr_vec(Ub[:, k], Vb[:, k]) for k in range(n_components)]

    # p-value: proportia permutarilor cu |r_perm| >= |r_obs|
    pvals = np.mean(np.abs(r_perm) >= np.abs(r_obs), axis=0)
    return r_obs, pvals, r_perm

# Ruleaza doar daca ai timp (la examen poti seta n_perm=200)
r_obs, pvals, r_perm = permutation_test_cca(Xz, Yz, n_components=min(n_components, 3), n_perm=300)

tabel_perm = pd.DataFrame({
    "r observat": r_obs,
    "p-value permutare": pvals
}, index=[f"CC{k+1}" for k in range(len(r_obs))])

print("\nTest permutare (primele componente):\n", tabel_perm)

# Boxplot distributie permutari pentru CC1
plt.figure()
plt.title("Permutari: distributia r pentru CC1 (|r| sub ipoteza H0)")
plt.hist(r_perm[:, 0], bins=25)
plt.axvline(r_obs[0], linewidth=2, label="r observat")
plt.axvline(-r_obs[0], linewidth=2)
plt.legend()
plt.show()
