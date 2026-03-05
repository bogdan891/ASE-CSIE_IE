import streamlit as st
import requests

st.title("Citate inspiraționale")

st.markdown("""
### Prezentare generală
Această aplicație folosește **ZenQuotes API** pentru a prelua citate inspiraționale aleatorii. Nu este necesară cheie API.

- `st.button` pentru declanșarea unei acțiuni
- `st.session_state` pentru a păstra datele între reîncărcări, istoricul citatelor
- `st.expander` pentru secțiuni care pot fi ascunse sau afișate
- Afișare stilizată cu markdown
""")

st.markdown("---")

# -------------------------------------------------------------------
# Inițializare session state pentru istoricul citatelor
# -------------------------------------------------------------------

if "quote_history" not in st.session_state:
    st.session_state.quote_history = []

# -------------------------------------------------------------------
# Funcție API
# -------------------------------------------------------------------

def get_random_quote():
    """Preia un citat inspirațional aleatoriu din ZenQuotes API."""
    url = "https://zenquotes.io/api/random"
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        if data and len(data) > 0:
            return {
                "quote": data[0].get("q", ""),
                "author": data[0].get("a", "Necunoscut")
            }
    return None

# -------------------------------------------------------------------
# Interfața utilizator
# -------------------------------------------------------------------

if st.button("Obține un citat nou"):
    with st.spinner("Se preia citatul..."):
        quote_data = get_random_quote()

    if quote_data is None:
        st.error("Nu s-a putut prelua citatul. Încearcă din nou.")
    else:
        # Adaugă în istoric
        st.session_state.quote_history.insert(0, quote_data)

if st.session_state.quote_history:
    # Afișează cel mai recent citat
    latest = st.session_state.quote_history[0]
    st.markdown(f"""
> *"{latest['quote']}"*
>
> -- **{latest['author']}**
""")

    # Afișează istoricul citatelor
    if len(st.session_state.quote_history) > 1:
        with st.expander(f"Istoric citate ({len(st.session_state.quote_history)} citate)"):
            for i, q in enumerate(st.session_state.quote_history):
                st.markdown(f"**{i + 1}.** *\"{q['quote']}\"* -- {q['author']}")
                if i < len(st.session_state.quote_history) - 1:
                    st.divider()

    # Buton pentru ștergere istoric
    if st.button("Șterge istoricul"):
        st.session_state.quote_history = []
        st.rerun()
else:
    st.info("Apasă butonul de mai sus pentru a primi primul citat.")

st.markdown("---")
st.markdown("""
### Cum funcționează
1. La apăsarea butonului se trimite o cerere GET către `https://zenquotes.io/api/random`.
2. API-ul returnează un obiect JSON cu citatul `q` și autorul `a`.
3. Citatul este salvat în `st.session_state.quote_history`, care păstrează datele între reîncărcările aplicației.
4. Citatele anterioare sunt afișate într-un `st.expander` pentru a păstra interfața curată.

Concept important, `st.session_state`:
În mod normal, Streamlit rulează din nou întregul script la fiecare interacțiune, iar variabilele se resetează.
`st.session_state` funcționează ca un dicționar care păstrează valorile între rulări.
Este util pentru istoric, contoare sau date acumulate.

Documentație API: ZenQuotes
""")