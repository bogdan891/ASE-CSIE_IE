import streamlit as st
import requests

st.title("Random Jokes")

st.markdown("""
### Prezentare generală
Această aplicație folosește **JokeAPI** pentru a prelua glume aleatorii. Nu este necesară cheie API.
Aplicația demonstrează:

- `st.selectbox` pentru alegerea unei categorii
- `st.button` pentru a obține o glumă nouă
- Afișare condiționată în funcție de tipul glumei, una scurtă sau în două părți
- `st.divider` pentru separare vizuală
""")

st.markdown("---")

# -------------------------------------------------------------------
# Funcție API
# -------------------------------------------------------------------

def get_joke(category="Any"):
    """Preia o glumă din JokeAPI."""
    url = f"https://v2.jokeapi.dev/joke/{category}?safe-mode"
    response = requests.get(url)
    if response.status_code == 200:
        return response.json()
    return None

# -------------------------------------------------------------------
# Interfața utilizator
# -------------------------------------------------------------------

category = st.selectbox(
    "Selectează o categorie de glume",
    ["Any", "Programming", "Pun", "Spooky", "Christmas"]
)

if st.button("Obține o glumă"):
    with st.spinner("Se încarcă gluma..."):
        joke_data = get_joke(category)

    if joke_data is None or joke_data.get("error", False):
        st.error("Nu s-a putut prelua gluma. Încearcă din nou.")
    else:
        st.divider()

        if joke_data["type"] == "single":
            # Glumă pe o singură linie
            st.markdown(f"### {joke_data['joke']}")
        else:
            # Glumă în două părți
            st.markdown(f"### {joke_data['setup']}")
            st.write("")
            if st.button("Arată gluma", key="punchline"):
                st.markdown(f"**{joke_data['delivery']}**")
            else:
                st.markdown(f"**{joke_data['delivery']}**")

        st.divider()

        # Afișare informații suplimentare
        col1, col2 = st.columns(2)
        col1.write(f"**Categorie:** {joke_data.get('category', 'N/A')}")
        col2.write(f"**Tip:** {joke_data.get('type', 'N/A')}")

        # Afișare răspuns complet JSON
        with st.expander("Vezi răspunsul complet API"):
            st.json(joke_data)

st.markdown("---")
st.markdown("""
### Cum funcționează
1. Utilizatorul selectează o categorie din listă.
2. La apăsarea butonului se trimite o cerere GET către `https://v2.jokeapi.dev/joke/{category}`.
3. API-ul returnează un obiect JSON cu fie un câmp `joke` pentru glume scurte, fie `setup` și `delivery` pentru glume în două părți.
4. Aplicația verifică valoarea câmpului `type` și afișează gluma corespunzător.

Se folosește `?safe-mode` pentru a filtra conținutul nepotrivit.

Documentație API: JokeAPI
""")