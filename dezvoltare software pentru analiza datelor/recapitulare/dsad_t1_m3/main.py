import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

# ============================================
# 1. CITIREA DATELOR
# ============================================

agri = pd.read_csv("Agricultura.csv")
pop = pd.read_csv("PopulatieLocalitati.csv")

# Coloanele activităților agricole
activitati = ["PlanteNepermanente", "PlanteInmultire", "CrestereaAnimalelor",
              "FermeMixte", "ActivitatiAuxiliare"]

# ============================================
# 1. CERINȚA 1 — TOTAL CIFRĂ DE AFACERI / LOCALITATE
# ============================================

agri["Total"] = agri[activitati].sum(axis=1)

cerinta1 = agri[["Siruta", "Localitate", "Total"]]
cerinta1.to_csv("Cerinta1.csv", index=False)
print("Cerinta1.csv a fost generat.")


# ============================================
# 2. CERINȚA 2 — ACTIVITATEA CU CIFRA DE AFACERI MAXIMĂ
# ============================================

agri["ActivitateMax"] = agri[activitati].idxmax(axis=1)

cerinta2 = agri[["Siruta", "Localitate", "ActivitateMax"]]
cerinta2.to_csv("Cerinta2.csv", index=False)
print("Cerinta2.csv a fost generat.")


# ============================================
# 3. CERINȚA 3 — CIFRA DE AFACERI PE LOCUITOR / JUDEȚ
# ============================================

# Combinăm datele pe Siruta
merged = pd.merge(agri, pop, on="Siruta")

# Grupăm pe județ și însumăm activitățile + populația
sum_judete = merged.groupby("Judet")[activitati + ["Populatie"]].sum()

# Calculăm cifra de afaceri pe locuitor
for act in activitati:
    sum_judete[act] = sum_judete[act] / sum_judete["Populatie"]

cerinta3 = sum_judete[activitati].reset_index()
cerinta3.to_csv("Cerinta3.csv", index=False)
print("Cerinta3.csv a fost generat.")


# ============================================
# 4. CERINȚA 4 — MEDIA PONDERATĂ A CIFREI DE AFACERI PE JUDEȚ
# ============================================

# Formula: sum(CifraLocalitate * PopLocalitate) / sum(PopLocalitate)

def media_ponderata(df, nume_col):
    return np.average(df[nume_col], weights=df["Populatie"])

rezultate = []

for jud, df_jud in merged.groupby("Judet"):
    rand = {"Judet": jud}
    for act in activitati:
        rand[act] = media_ponderata(df_jud, act)
    rezultate.append(rand)

cerinta4 = pd.DataFrame(rezultate)
cerinta4.to_csv("Cerinta4.csv", index=False)
print("Cerinta4.csv a fost generat.")


# ============================================
# 5. CERINȚA 5 — GRAFIC CU PRIMELE 50 LOCALITĂȚI
# ============================================

top50 = cerinta1.sort_values("Total", ascending=False).head(50)

plt.figure(figsize=(12,6))
plt.bar(top50["Localitate"], top50["Total"])
plt.xticks(rotation=90)
plt.title("Top 50 localități după cifra totală de afaceri")
plt.tight_layout()
plt.show()