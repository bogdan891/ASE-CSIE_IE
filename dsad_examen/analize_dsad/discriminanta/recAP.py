import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.model_selection import train_test_split
from sklearn.discriminant_analysis import LinearDiscriminantAnalysis
from sklearn.naive_bayes import GaussianNB
from sklearn.metrics import confusion_matrix, accuracy_score, classification_report
from sklearn.preprocessing import StandardScaler

def inlocuire_nan(df: pd.DataFrame):
    for col in df.columns:
        if df[col].isnull().any():
            if pd.api.types.is_numeric_dtype(df[col]):
                df[col].fillna(df[col].mean(), inplace=True)
            else:
                df[col].fillna(df[col].mode()[0], inplace=True)


def main():
    df = pd.read_csv("hernia.csv", index_col=0)
    inlocuire_nan(df)

    target_col = df.columns[-1]
    predictor_col = df.columns[:-1]

    X = df[predictor_col].values
    y = df[target_col].values
    X = StandardScaler().fit_transform(X)

    X_train, X_test, y_train, y_test = train_test_split(
        X, y,
        test_size=0.3,
        random_state=42
    )

    lda = LinearDiscriminantAnalysis()
    lda.fit(X_train, y_train)

    print("\n=== LDA ===")
    print("Clase:", lda.classes_)
    print("Priors:", lda.priors_)

    z_test = lda.transform(X_test)
    if z_test.shape[1] >= 1:
        plt.figure(figsize=(7, 5))
        plt.title("Distribuție scor LDA (axa 1) - set de test")
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

    y_pred_lda = lda.predict(X_test)
    cm_lda = confusion_matrix(y_test, y_pred_lda)
    acc_lda = accuracy_score(y_test, y_pred_lda)
    print("\n=== Matrice de confuzie LDA ===")
    print(cm_lda)
    print(f"Acuratete LDA: {acc_lda * 100:.2f}%")
    print("Raport clasificare LDA:")
    print(classification_report(y_test, y_pred_lda))
    nb = GaussianNB()
    nb.fit(X_train, y_train)

    y_pred_nb = nb.predict(X_test)

    cm_nb = confusion_matrix(y_test, y_pred_nb)
    acc_nb = accuracy_score(y_test, y_pred_nb)

    print("\n=== Naive Bayes ===")
    print("Matrice de confuzie:")
    print(cm_nb)
    print(f"Acuratete Bayes: {acc_nb * 100:.2f}%")
    print("Raport clasificare Bayes:")
    print(classification_report(y_test, y_pred_nb))

    results_df = pd.DataFrame({
        "Real": y_test,
        "Pred_LDA": y_pred_lda,
        "Pred_Bayes": y_pred_nb
    })

    results_df.to_csv("Rezultate_Discriminare.csv", index=False)
    print("\n=== Rezultate salvate în 'Rezultate_Discriminare.csv' ===")

if __name__ == "__main__":
    main()