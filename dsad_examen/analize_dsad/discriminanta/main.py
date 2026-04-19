import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

from sklearn.model_selection import train_test_split
from sklearn.discriminant_analysis import LinearDiscriminantAnalysis
from sklearn.naive_bayes import GaussianNB
from sklearn.metrics import confusion_matrix, accuracy_score, classification_report
from sklearn.preprocessing import StandardScaler


# =========================================================
# 1) FUNCTIE: INLOCUIRE VALORI LIPSA (NaN)
# =========================================================
def inlocuire_nan(df: pd.DataFrame):
    """
    Completează valorile lipsă (NaN) astfel:
      - pentru coloane numerice: cu media coloanei
      - pentru coloane nenumerice: cu moda (cea mai frecventă valoare)

    Atenție: folosește inplace=True (modifică df direct).
    În general merge, dar în unele versiuni de pandas apare SettingWithCopyWarning
    dacă df e un view. Aici fiind citit din CSV, de obicei e ok.
    """
    for col in df.columns:
        if df[col].isnull().any():
            if pd.api.types.is_numeric_dtype(df[col]):
                # NaN numeric -> media
                df[col].fillna(df[col].mean(), inplace=True)
            else:
                # NaN categorial -> moda (prima valoare cea mai frecventă)
                df[col].fillna(df[col].mode()[0], inplace=True)


# =========================================================
# 2) FUNCTIA PRINCIPALA
# =========================================================
def main():
    # -----------------------------------------------------
    # 2.1) CITIRE DATE
    # -----------------------------------------------------
    # Citim setul de date. index_col=0 presupune ca prima coloană este index / ID.
    df = pd.read_csv("hernia.csv", index_col=0)

    # Completăm valorile lipsă
    inlocuire_nan(df)

    # -----------------------------------------------------
    # 2.2) DEFINIRE TARGET + PREDICTORI
    # -----------------------------------------------------
    # Presupunem că ultima coloană este targetul (clasa).
    # Dacă în fișier targetul e în altă coloană, aici trebuie schimbat.
    target_col = df.columns[-1]
    predictor_cols = df.columns[:-1]

    # X = matricea cu predictorii (variabile explicative)
    X = df[predictor_cols].values

    # y = vectorul cu clasele (variabila țintă)
    y = df[target_col].values

    # -----------------------------------------------------
    # 2.3) STANDARDIZARE
    # -----------------------------------------------------
    # Standardizare: medie 0, deviație 1.
    # NOTĂ IMPORTANTĂ (de examen):
    # Cel mai corect e să faci fit pe train și transform pe test (evită "data leakage").
    # Tu ai standardizat înainte de split; e ok pentru laborator, dar nu e "perfect".
    X = StandardScaler().fit_transform(X)

    # -----------------------------------------------------
    # 2.4) IMPARTIRE TRAIN / TEST
    # -----------------------------------------------------
    # test_size=0.3 => 30% test, 70% train
    # random_state => reproducibilitate (același split la fiecare rulare)
    X_train, X_test, y_train, y_test = train_test_split(
        X, y,
        test_size=0.3,
        random_state=42
    )

    # =====================================================
    # 3) LDA (Linear Discriminant Analysis)
    # =====================================================
    # LDA găsește axe discriminante (combinații liniare) care separă clasele.
    lda = LinearDiscriminantAnalysis()
    lda.fit(X_train, y_train)

    print("\n=== LDA ===")
    print("Clase:", lda.classes_)   # clasele întâlnite în y
    print("Priors:", lda.priors_)   # probabilități a priori ale claselor (estimate din train)

    # -----------------------------------------------------
    # 3.1) SCORURI DISCRIMINANTE PE TEST
    # -----------------------------------------------------
    # transform(X_test) -> coordonatele observațiilor pe axele discriminante.
    # nr_axe = min(nr_clase - 1, nr_variabile)
    z_test = lda.transform(X_test)

    # -----------------------------------------------------
    # 3.2) GRAFICE PENTRU LDA
    # -----------------------------------------------------

    # Histogramă pe prima axă discriminantă (dacă există)
    if z_test.shape[1] >= 1:
        plt.figure(figsize=(7, 5))
        plt.title("Distribuție scor LDA (axa 1) - set de test")

        # Plotează histograme separate pentru fiecare clasă
        for clasa in np.unique(y_test):
            plt.hist(
                z_test[y_test == clasa, 0],
                alpha=0.5,
                label=str(clasa),
                bins=10
            )

        plt.xlabel("Scor LDA1")
        plt.legend()
        plt.tight_layout()
        plt.show()

    # Scatterplot în primele 2 axe discriminante (dacă există 2)
    if z_test.shape[1] >= 2:
        plt.figure(figsize=(7, 5))
        plt.title("Instanțe în primele 2 axe discriminante")

        for clasa in np.unique(y_test):
            plt.scatter(
                z_test[y_test == clasa, 0],  # axa 1
                z_test[y_test == clasa, 1],  # axa 2
                alpha=0.5,
                label=str(clasa)
            )

        plt.xlabel("Scor LDA1")
        plt.ylabel("Scor LDA2")
        plt.legend()
        plt.tight_layout()
        plt.show()

    # -----------------------------------------------------
    # 3.3) PREDICTIE + EVALUARE (LDA)
    # -----------------------------------------------------
    y_pred_lda = lda.predict(X_test)

    # Matrice de confuzie: rând = real, coloană = prezis
    cm_lda = confusion_matrix(y_test, y_pred_lda)

    # Acuratețe: proporția de clasificări corecte
    acc_lda = accuracy_score(y_test, y_pred_lda)

    print("\n=== Matrice de confuzie LDA ===")
    print(cm_lda)
    print(f"Acuratete LDA: {acc_lda*100:.2f}%")

    # classification_report: precizie, recall, f1-score pe fiecare clasă
    print("Raport clasificare LDA:")
    print(classification_report(y_test, y_pred_lda))

    # =====================================================
    # 4) NAIVE BAYES (GaussianNB)
    # =====================================================
    # GaussianNB presupune distribuții Gaussiene pentru fiecare variabilă, pe fiecare clasă.
    # E rapid, simplu, uneori surprinzător de bun.
    nb = GaussianNB()
    nb.fit(X_train, y_train)

    y_pred_nb = nb.predict(X_test)

    cm_nb = confusion_matrix(y_test, y_pred_nb)
    acc_nb = accuracy_score(y_test, y_pred_nb)

    print("\n=== Naive Bayes ===")
    print("Matrice de confuzie:")
    print(cm_nb)
    print(f"Acuratete Bayes: {acc_nb*100:.2f}%")
    print("Raport clasificare Bayes:")
    print(classification_report(y_test, y_pred_nb))

    # =====================================================
    # 5) SALVARE REZULTATE (OPTIONAL)
    # =====================================================
    # Salvăm real vs predicții în CSV, ca să poți analiza manual greșelile.
    results_df = pd.DataFrame({
        "Real": y_test,
        "Pred_LDA": y_pred_lda,
        "Pred_Bayes": y_pred_nb
    })

    results_df.to_csv("Rezultate_Discriminare.csv", index=False)
    print("\n=== Rezultate salvate în 'Rezultate_Discriminare.csv' ===")


# =========================================================
# 6) ENTRY POINT
# =========================================================
if __name__ == "__main__":
    main()
