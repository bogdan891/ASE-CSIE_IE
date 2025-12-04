import numpy as np
import pandas as pd
from pandas.core.dtypes.common import is_numeric_dtype


def fillNan(t):
    assert isinstance(t, pd.DataFrame)
    for v in t.columns:
        if any(t[v].isna()):
            if is_numeric_dtype(t[v]):
                t[v].fillna(t[v].mean(), inplace=True)
            else:
                t[v].fillna(t[v].mode()[0], inplace=True)

miscare = pd.read_csv("MiscareaNatLoc.csv")
populatie = pd.read_csv("PopulatieLocalitati.csv")

fillNan(miscare)
fillNan(populatie)

miscare = miscare.merge(populatie[["Populatie", "Judet"]], left_index = True, right_index = True)

#cerinta 1
miscare["TotalDecedati"] = miscare["Decedati"] + miscare["DecedatiSub1An"]
cerinta1 = miscare[miscare["TotalDecedati"] > miscare["NascutiVii"]]
cerinta1 = cerinta1[["Siruta","Localitate","TotalDecedati","NascutiVii"]]
cerinta1.to_csv("Cerinta1.csv", index=False)

#cerinta2
miscare["RataMortalitateInfantila"] = np.round((miscare["DecedatiSub1An"] * 1000) / miscare["NascutiVii"], 4)
cerinta2 = miscare[["Siruta","Localitate","RataMortalitateInfantila"]].sort_values(by="RataMortalitateInfantila", ascending = False)
cerinta2.to_csv("Cerinta2.csv", index=False)

#cerinta3
miscare["RataNatalitatii"] = np.round((miscare["NascutiVii"] * 1000) / miscare["Populatie"], 4)
miscare["RataMoralitatii"] = np.round((miscare["TotalDecedati"] * 1000) / miscare["Populatie"], 4)
miscare["SporNatural"] = miscare["RataNatalitatii"] - miscare["RataMoralitatii"]
cerinta3 = miscare.groupby("Judet")["SporNatural"].mean().reset_index()
cerinta3.to_csv("Cerinta3.csv", index=False)

#cerinta4
def max_localitati(gr, cols):
    res = {}
    for c in cols:
        max_val = gr[c].max()
        res[c] = ",".join(gr[gr[c]==max_val]["Localitate"])
    return pd.Series(res)

indicatori = ["Casatorii","Decedati","DecedatiSub1An","Divorturi","NascutiMorti","NascutiVii"]
cerinta4 = miscare.groupby("Judet").apply(max_localitati, cols=indicatori)
cerinta4.reset_index(inplace=True)
cerinta4.to_csv("Cerinta4.csv", index=False)

#grafice
import matplotlib.pyplot as plt
#scatter Populație vs Născuți Vii
plt.figure(figsize = (8, 6))

plt.scatter(miscare["Populatie"], miscare["NascutiVii"])
plt.xlabel("Populatie")
plt.ylabel("Nascuti Vii")
plt.title("Populatie vs Nascuti Vii")

plt.figure(figsize = (8, 6))
top10 = miscare.nlargest(10, "RataMortalitateInfantila")
plt.plot(top10["Localitate"], top10["RataMortalitateInfantila"])
plt.ylabel("Rata Mortalitate Infantila")
plt.title("Top 10 Localitati - Mortalitate Infantila")

plt.show()