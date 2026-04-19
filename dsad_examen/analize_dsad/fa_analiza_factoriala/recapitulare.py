import numpy as np
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
from sklearn.preprocessing import StandardScaler
from factor_analyzer import FactorAnalyzer

data = pd.read_csv("ConsumAlimentar.csv", index_col=0)
data = data.apply(lambda col: col.fillna(col.mean()))
data_t = StandardScaler().fit_transform(data)
fa = FactorAnalyzer(n_factors=data_t.shape[1], rotation="varimax")
