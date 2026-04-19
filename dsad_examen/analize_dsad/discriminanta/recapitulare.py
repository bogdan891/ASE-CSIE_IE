import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

from sklearn.preprocessing import StandardScaler
from sklearn.model_selection import train_test_split
from sklearn.discriminant_analysis import LinearDiscriminantAnalysis
from sklearn.metrics import confusion_matrix, accuracy_score, classification_report
from sklearn.naive_bayes import  GaussianNB

def inlocuire_nan(df: pd.DataFrame):
    for col in df.columns:
        if df[col].isnull().any():
            if pd.api.types.is_numeric_dtype(df[col]):
                df[col].fillna(df[col].mean(), inplace=True)
            else:
                df[col].fillna(df[col].mode()[0], inplace=True)

def main():
    df = pd.read_csv("file.csv", index_col = 0)
    target_col = df[-1]
    predictor_col = df[:-1]

    X = df[predictor_col].values
    y = df[target_col].values
    X = StandardScaler().fit_transform(X)

    X_train, X_test, y_train, y_test = train_test_split(X, y, train_size=0.3, random_state=42)

    lda = LinearDiscriminantAnalysis()
    lda.fit(X_train, y_train)

    print("\n=== LDA ===")
    print("Clase:", lda.classes_)
    print("Priors:", lda.priors_)