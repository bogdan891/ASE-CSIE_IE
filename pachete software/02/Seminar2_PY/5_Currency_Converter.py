import streamlit as st
import requests

st.title("Convertor valutar")

st.markdown("""
### Prezentare generală
Această aplicație folosește **ExchangeRate API** pentru a converti valute folosind cursuri de schimb actualizate.
Nu este necesară cheie API.

- `st.form` și `st.form_submit_button` pentru trimiterea simultană a mai multor inputuri
- `st.selectbox` pentru alegerea valutelor
- `st.number_input` pentru introducerea sumei
- `st.metric` pentru afișarea rezultatului
- `@st.cache_data` pentru memorarea temporară a cursurilor
""")

st.markdown("---")

# -------------------------------------------------------------------
# Funcție API
# -------------------------------------------------------------------

@st.cache_data(ttl=3600)  # memorare în cache pentru 1 oră
def get_exchange_rates(base_currency):
    """Preia cursurile de schimb pentru o valută de bază."""
    url = f"https://open.er-api.com/v6/latest/{base_currency}"
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        if data.get("result") == "success":
            return data
    return None

# -------------------------------------------------------------------
# Valute comune
# -------------------------------------------------------------------

COMMON_CURRENCIES = [
    "USD", "EUR", "GBP", "RON", "JPY", "CHF", "CAD", "AUD",
    "CNY", "INR", "BRL", "KRW", "SEK", "NOK", "PLN", "CZK", "HUF"
]

# -------------------------------------------------------------------
# Interfața utilizator
# -------------------------------------------------------------------

with st.form("converter_form"):
    col1, col2, col3 = st.columns(3)

    with col1:
        base = st.selectbox("Din", COMMON_CURRENCIES, index=0)
    with col2:
        target = st.selectbox("În", COMMON_CURRENCIES, index=3)
    with col3:
        amount = st.number_input("Sumă", min_value=0.01, value=100.0, step=1.0)

    submitted = st.form_submit_button("Convertește")

if submitted:
    with st.spinner("Se preiau cursurile de schimb..."):
        data = get_exchange_rates(base)

    if data is None:
        st.error("Nu s-au putut prelua cursurile de schimb. Încearcă din nou.")
    else:
        rates = data.get("rates", {})
        if target in rates:
            rate = rates[target]
            result = amount * rate

            st.divider()

            col1, col2, col3 = st.columns(3)
            col1.metric("Sumă", f"{amount:,.2f} {base}")
            col2.metric("Curs de schimb", f"1 {base} = {rate:.4f} {target}")
            col3.metric("Rezultat", f"{result:,.2f} {target}")

            # Alte cursuri pentru context
            st.divider()
            st.subheader("Alte cursuri")

            rate_cols = st.columns(4)
            other_currencies = [c for c in COMMON_CURRENCIES if c != base][:8]
            for i, curr in enumerate(other_currencies):
                if curr in rates:
                    rate_cols[i % 4].metric(curr, f"{rates[curr]:.4f}")
        else:
            st.error(f"Valuta {target} nu a fost găsită în cursurile de schimb.")

        # Timp actualizare
        st.caption(f"Cursuri actualizate la: {data.get('time_last_update_utc', 'N/A')}")

        with st.expander("Vezi răspunsul complet API"):
            st.json(data)

st.markdown("---")
st.markdown("""
### Cum funcționează
1. Utilizatorul selectează valuta de bază, valuta țintă și suma într-un **formular**.
2. La trimiterea formularului, aplicația trimite o cerere GET către `https://open.er-api.com/v6/latest/{base}`.
3. API-ul returnează toate cursurile raportate la valuta de bază.
4. Aplicația înmulțește suma cu cursul valutei țintă și afișează rezultatul.

Concept important, `st.form`:
Fără formular, Streamlit ar rula din nou scriptul la fiecare modificare a unui câmp.
Formularul grupează toate inputurile și declanșează execuția doar la apăsarea butonului.
Este util când faci apeluri API, pentru a evita cereri inutile.

Parametrul `ttl=3600` din `@st.cache_data` înseamnă că datele sunt păstrate 1 oră,
după care sunt reîmprospătate automat.

Documentație API: ExchangeRate API
""")