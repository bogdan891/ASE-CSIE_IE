import streamlit as st
import pandas as pd
import plotly.express as px
import dateutil

st.title("📞 Analiză Trafic Mobil")

# Încărcăm datele
df = pd.read_csv("phone_data.csv")

# ------------------------------------------------
# TODO 1: Curățare date (Pandas)
# 1. Convertește coloana 'date' în format datetime
#    (folosind apply cu dateutil.parser.parse, dayfirst=True).
# ------------------------------------------------
df["date"] = pd.to_datetime(df["date"], dayfirst=True)
st.dataframe(df)

# ------------------------------------------------
# TODO 2: Metrici rapide (Streamlit Layout)
# 1. Împarte ecranul în 2 coloane (col1, col2).
# 2. În col1 pune un st.metric cu numărul total de rânduri din dataset.
# 3. În col2 pune un st.metric cu durata maximă din tot datasetul (df['duration'].max()).
# ------------------------------------------------
col1, col2 = st.columns(2)
with col1:
    st.metric("Numarul total de randuri: ", len(df))
with col2:
    st.metric("Durata maxima din dataset: ", df["duration"].max())

# ------------------------------------------------
# TODO 3: Filtrare interactivă (Streamlit Widgets)
# 1. Creează un st.selectbox pentru a alege tipul de acțiune ('item').
#    Valorile trebuie să fie unice din coloana df['item'].
# 2. Filtrează df-ul inițial păstrând doar rândurile unde 'item' este cel selectat.
#    Salvează rezultatul în `df_filtrat`.
# ------------------------------------------------
lista_item = list(df["item"].unique())
item_select = st.selectbox("Selecteaza un item", lista_item, key="call", help="Alege un item pt filtrare")
df_filtrat = df[df["item"] == item_select]
st.dataframe(df_filtrat)

# ------------------------------------------------
# TODO 4: Agregare pe lună (Pandas)
# 1. Fă un groupby pe coloana 'month' folosind `df_filtrat`.
# 2. Calculează suma duratelor ('duration') pentru fiecare lună.
# 3. Folosește .reset_index() la final ca să îl transformi înapoi în tabel normal,
# ------------------------------------------------
st.dataframe(df_filtrat.groupby('month').agg(durata_totala=('duration', 'sum')).reset_index())

# ------------------------------------------------
# TODO 5: Vizualizare (Plotly)
# 1. Creează un px.bar folosind `df_agregat`, cu axa X='month' și Y='duration'.
# 2. Afișează graficul în pagină folosind funcția specifică din Streamlit.
# ------------------------------------------------
df_agregat = df_filtrat.groupby('month').agg(durata_totala=('duration', 'sum')).reset_index()
fig = px.bar(df_agregat, x="month", y="durata_totala")
st.plotly_chart(fig)