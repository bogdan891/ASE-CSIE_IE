# --- TODO 1: MERGE ȘI CURĂȚARE ---
df_supported.rename(columns={'Retail Branding':'manufacturer'}, inplace=True)
df_temp = pd.merge(df_usage, df_device, on="use_id", how="left")
df_merged = pd.merge(df_temp, df_supported, left_on="device", right_on="Model", how="left")

# ATENȚIE: dropna() fără inplace=True sau reatribuire nu face nimic!
df_master = df_merged.dropna(subset=["manufacturer"]).copy()

# --- TODO 2: SESSION STATE ȘI FORMULAR ---
if "filtrare_aplicata" not in st.session_state:
    st.session_state.filtrare_aplicata = 0

# Inițializăm df_filtrat cu tot tabelul (cazul în care nu s-a apăsat butonul încă)
df_filtrat = df_master

with st.form("Formular"):
    lista_platforme = df_master["platform"].unique()
    optiuni_select = st.multiselect("Platforme", lista_platforme, default=list(lista_platforme))
    trafic_minim = st.number_input("Trafic minim MB", value=500)
    submitted = st.form_submit_button("Analizează")

if submitted:
    st.session_state.filtrare_aplicata += 1
    # Filtrare multiplă (atenție la paranteze!)
    df_filtrat = df_master[
        (df_master["platform"].isin(optiuni_select)) &
        (df_master["monthly_mb"] >= trafic_minim)
    ]

# --- TODO 3: AGREGARE NIVEL BOSS ---
# Aici e "magia" cu redenumirea coloanelor direct în .agg
df_final = df_filtrat.groupby('manufacturer').agg(
    avg_mb=('monthly_mb', 'mean'),
    max_sms=('outgoing_sms_per_month', 'max'),
    user_count=('use_id', 'nunique')
).reset_index()

# Filtrăm producătorii cu minim 2 utilizatori
df_final = df_final[df_final["user_count"] >= 2]

# --- TODO 4: VIZUALIZARE ---
st.metric("Filtraje rulate:", st.session_state.filtrare_aplicata)

if not df_final.empty:
    fig = px.scatter(
        df_final,
        x='avg_mb',
        y='max_sms',
        size='user_count',
        color='manufacturer',
        title="Analiză Producători (Trafic vs SMS)"
    )
    st.plotly_chart(fig)
else:
    st.warning("Nu există date pentru selecția curentă!")