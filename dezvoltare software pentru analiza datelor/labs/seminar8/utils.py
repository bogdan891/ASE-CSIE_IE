from pandas import DataFrame


def tabelare_mattrice(x, nume_randuri = None, nume_coloane = None, nume_fisier = None):
    df = DataFrame(x, index=nume_randuri, colums=nume_coloane)
    if nume_fisier is not None:
        df.to_csv(nume_fisier)

    return df

def nan_replace(df):
    for col in df.columns:
        if df[col].isna().any:
            df[col].fillna(df[col].mean(), inplace = True)
        else:
            mode_result = df[col].mode()
            df[col].fillna(mode_result[0], inplace = True)
