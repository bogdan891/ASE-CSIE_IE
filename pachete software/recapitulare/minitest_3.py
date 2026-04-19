import streamlit as st
import pandas as pd
import plotly.express as px
import dateutil

st.title("Analiză Rapidă - Phone Data")

# 1. Încărcarea datelor
df = pd.read_csv("phone_data.csv")

# ------------------------------------------------
# TODO 1: Conversie Date (Pandas)
# Transformă coloana 'date' în format datetime.
# ------------------------------------------------
df["date"] = pd.to_datetime(df["date"], dayfirst=True)

# ------------------------------------------------
# TODO 2: Filtrare cu Streamlit
# Adaugă un st.selectbox numit "Alege rețeaua:" care să conțină
# rețelele unice din coloana df['network'].
# Filtrează dataframe-ul să conțină doar rețeaua aleasă.
# ------------------------------------------------
lista = df["network"].unique()
val = st.selectbox("Retea", lista, key="Vodafone", help="Alege o retea")
df_filtrat = df[df["network"] == val]
st.dataframe(df_filtrat)

# ------------------------------------------------
# TODO 3: Agregare (Pandas)
# Pe datele filtrate mai sus, fă o grupare (groupby) după 'month'.
# Calculează suma pentru coloana 'duration'.
# Folosește .reset_index() la final ca să redevină tabel normal.
# ------------------------------------------------
df_agregat = df_filtrat.groupby("month").agg(durata_totala=('duration', 'sum')).reset_index()
st.dataframe(df_agregat)

# ------------------------------------------------
# TODO 4: Grafic (Plotly + Streamlit)
# Desenează un bar chart (px.bar) folosind tabelul agregat.
# Axa X va fi luna ('month'), axa Y va fi durata.
# Afișează-l pe ecran cu st.plotly_chart.
# ------------------------------------------------
df_agregat = df_filtrat.groupby('month').agg(durata_totala=('duration', 'sum')).reset_index()
fig = px.bar(df_agregat, x="month", y="durata_totala")
st.plotly_chart(fig)