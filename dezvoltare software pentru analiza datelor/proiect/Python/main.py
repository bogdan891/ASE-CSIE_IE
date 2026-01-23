import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from scipy.cluster.hierarchy import dendrogram, linkage, fcluster
from sklearn.preprocessing import StandardScaler

date_proiect = pd.read_csv("Date.csv")
variabila_nume = date_proiect.columns[0]
variabile_economice = date_proiect.columns[1:]

x = date_proiect[variabile_economice].values
nume_tari = date_proiect[variabila_nume].values

scaler = StandardScaler()
x_standardizat = scaler.fit_transform(x)

tabel_standardizat = pd.DataFrame(x_standardizat, columns=variabile_economice, index=nume_tari)
tabel_standardizat.to_csv("Date_Standardizate.csv")

metoda_linkage = linkage(x_standardizat, method="ward", metric="euclidean")

plt.figure(figsize=(12, 8))
plt.title("Dendrograma Rezilentei Zonei Euro (Metoda Ward)")

deondrograma = dendrogram(
    metoda_linkage,
    labels=nume_tari,
    leaf_rotation=90,
    leaf_font_size=10,
    color_threshold=3.5
)

plt.axhline(y=3.5, color="r", linestyle="--", label="Prag taiere (3 clustere)")
plt.ylabel("Distanta Euclidiana (Dissimilaritatea)")
plt.legend()
plt.tight_layout()
plt.savefig("Dendrograma.png")
plt.show()

numar_clustere = 3
predictie_clustere = fcluster(metoda_linkage, t=3.5, criterion="distance")

rezultate_finale = pd.DataFrame({
    "Tara": nume_tari,
    "Cluster": predictie_clustere
})

for col in variabile_economice:
    rezultate_finale[col] = date_proiect[col].values

rezultate_finale.sort_values(by="Cluster").to_csv("Clasificare_Tari_Cluster.csv", index=False)
profil_clustere = rezultate_finale.drop(columns=["Tara"]).groupby("Cluster").mean()
print("\nRezultate Finale Analiza Cluster\n")
print(profil_clustere)
profil_clustere.to_csv("Profiul_Mediu_Clustere.csv")