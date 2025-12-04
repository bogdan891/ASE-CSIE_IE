import PCA
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import utils
from utils import nan_replace, tabelare_mattrice

t = pd.read_csv("Freelancer.csv", index_col=1)
nan_replace(t)

#la ACP mereu trb facuta standardizarea

variabile_observate=list(t.columns)[2:]
x_orig = t[variabile_observate]
x = (x_orig -np.mean(x_orig, axis=0)) / np.std(x_orig, axis=0)

n,m=x.shape

#init model ACP
model_acp = PCA()
model_acp.fit(x)

#val proprii
alpha = model_acp.explained_variance_

#vectorii proprii - eigen vectors / loadings
a = model_acp.components_

#componentele princ rezultate in urma ACP c = x @ a
c = model_acp.transform(x)

#afisarea componentelor princ
labels = ["C" + str(i+1) for i in range(len(alpha))]
componente_df = tabelare_mattrice(c, t.index, labels, "componente.csv")

#det nr componentelor princ semnificative
#kaiser - cons ca fiind semnificative acele comp care au std > 1
conditie = np.where(alpha > 1) # intoarce un tuplu cu un sg el de genul (array([0,1,2,3,4,5,6]),)
print("Kaiser: ", conditie)
array_din_where = conditie[0]
nr_comp_kaiser = len(array_din_where[0])

#cattel
eps = alpha[0:(m-1)] - alpha[1:m]
sigma = eps[0:(m-2)] - eps[1:len(eps)]
indici_negativi = (sigma < 0)
print("Indici cattle: ", indici_negativi)
if any(indici_negativi):
    conditie = np.where(indici_negativi) # intoarce un tuplu cu un sg el de genul (array([5,6, ...]),)
    array_din_where = conditie[0]
    nr_comp_cattle = array_din_where[0]

#procent acoperire