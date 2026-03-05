import streamlit as st

st.title("Proiect de grup: Construiește propria aplicație cu API")

st.markdown("""
---

## Ce veți construi

Fiecare grup va crea o **aplicație Streamlit pe o singură pagină** care se conectează la un **API public**,
preia date pe baza inputului utilizatorului și afișează rezultatele într-un mod clar și atractiv vizual.

Gândește-te la cele șase aplicații exemplu pe care le-ai văzut în seminar, Meteo, Glume, Citate, Țări,
Valute, GitHub. Sarcina ta este să construiești ceva similar, dar folosind un **API diferit**, ales de voi.

---

## Instrucțiuni pas cu pas

### Pasul 1: Formați grupul
- Lucrați în grupuri de **2, 3 sau 4 studenți**.
- Stabiliți rolurile: cine scrie codul, cine testează, cine pregătește prezentarea.

### Pasul 2: Alegeți un API
- Alegeți un API din lista de mai jos sau găsiți unul pe [publicapis.dev](https://publicapis.dev).
- API-ul trebuie să fie **gratuit** și să returneze date în format **JSON**.
- Testați API-ul direct în browser pentru a vedea cum arată răspunsul.

### Pasul 3: Creați aplicația
- Creați un **fișier Python nou** (exemplu, `my_app.py`).
- Folosiți template-ul de mai jos ca punct de plecare.
- Aplicația voastră trebuie să includă:
""")

st.markdown("""
| Cerință | Ce înseamnă | Exemplu |
|---|---|---|
| **Input de la utilizator** | Utilizatorul trebuie să poată introduce sau selecta ceva | `st.text_input("Introduce un nume Pokemon")` |
| **Apel API** | Aplicația trebuie să preia date folosind `requests.get()` | `requests.get(f"https://pokeapi.co/api/v2/pokemon/{name}")` |
| **Gestionare erori** | Afișează mesaj dacă apare o problemă | `st.error("Pokemonul nu a fost găsit!")` |
| **Afișare formatată** | Nu doar JSON brut, folosește elemente Streamlit | `st.metric`, `st.image`, `st.columns`, `st.write` |
| **Cel puțin 2 widget-uri** | Folosiți cel puțin două elemente interactive diferite | `st.text_input` + `st.button` |
""")

st.markdown("""
### Pasul 4: Testați aplicația
- Rulați aplicația cu `streamlit run my_app.py`.
- Testați și inputuri greșite.
- Asigurați-vă că interfața este clară și ușor de citit.

### Pasul 5: Prezentați în fața clasei, 2-3 minute
- Arătați aplicația rulând live.
- Explicați ce API ați folosit și ce face aplicația.
- Menționați un lucru interesant sau dificil pe care l-ați întâlnit.

---

## API-uri sugerate
""")

apis = [
    {
        "name": "PokeAPI - Căutare Pokemon",
        "url": "https://pokeapi.co/",
        "endpoint": "https://pokeapi.co/api/v2/pokemon/{name}",
        "key": "Nu",
        "idea": "Caută un Pokemon după nume. Afișează imaginea, tipurile, statistici precum HP, attack, defense și abilități."
    },
    {
        "name": "Dog CEO API - Imagini cu câini",
        "url": "https://dog.ceo/dog-api/",
        "endpoint": "https://dog.ceo/api/breeds/image/random",
        "key": "Nu",
        "idea": "Afișează imagini aleatorii cu câini. Adaugă un selectbox pentru rasă și afișează mai multe imagini în coloane."
    },
    {
        "name": "Universities API - Căutare universități",
        "url": "http://universities.hipolabs.com/",
        "endpoint": "http://universities.hipolabs.com/search?country={country}",
        "key": "Nu",
        "idea": "Caută universități după țară și afișează rezultatele într-un tabel."
    },
    {
        "name": "OMDb API - Căutare filme",
        "url": "https://www.omdbapi.com/",
        "endpoint": "https://www.omdbapi.com/?t={title}&apikey={key}",
        "key": "Da",
        "idea": "Caută un film după titlu. Afișează poster, an, gen, regizor, descriere și rating IMDb."
    },
    {
        "name": "NASA APOD - Imaginea zilei",
        "url": "https://api.nasa.gov/",
        "endpoint": "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY",
        "key": "Da",
        "idea": "Afișează fotografia astronomică a zilei și permite alegerea unei date anterioare."
    },
    {
        "name": "TheCatAPI - Imagini cu pisici",
        "url": "https://thecatapi.com/",
        "endpoint": "https://api.thecatapi.com/v1/images/search",
        "key": "Nu",
        "idea": "Afișează imagini aleatorii cu pisici și permite alegerea numărului de imagini prin slider."
    },
]

for api in apis:
    with st.expander(f"{api['name']} (Cheie API necesară: {api['key']})"):
        st.write(f"**Documentație:** [{api['url']}]({api['url']})")
        st.code(f'requests.get("{api["endpoint"]}")', language="python")
        st.write(f"**Idee de proiect:** {api['idea']}")

st.markdown("""
Puteți căuta și alte API-uri gratuite pe publicapis.dev.

---

## Template cod de început
""")

st.code("""
import streamlit as st
import requests

st.title("Numele aplicației mele")

st.markdown("Descriere scurtă a aplicației.")

user_input = st.text_input("Introduce ceva")

if st.button("Caută"):
    if not user_input:
        st.warning("Introduceți o valoare.")
    else:
        with st.spinner("Se încarcă..."):
            url = f"https://api.example.com/{user_input}"
            response = requests.get(url)

        if response.status_code == 200:
            data = response.json()
            st.subheader("Rezultate")
            st.json(data)
        else:
            st.error("A apărut o eroare.")
""", language="python")

st.markdown("""
### Cum rulați aplicația

Deschideți terminalul și rulați:

```
streamlit run my_app.py
```

---

## Comenzi utile

| Comandă                          | Ce face                                     | Exemplu                            |
| -------------------------------- | ------------------------------------------- | ---------------------------------- |
| `st.title("text")`               | Afișează un titlu mare                      | `st.title("Căutare Pokemon")`      |
| `st.subheader("text")`           | Afișează un subtitlu                        | `st.subheader("Statistici")`       |
| `st.write(data)`                 | Afișează text, numere sau tabele            | `st.write(f"Nume: {name}")`        |
| `st.text_input("label")`         | Câmp de introducere text                    | `st.text_input("Introdu orașul")`  |
| `st.selectbox("label", options)` | Meniu dropdown                              | `st.selectbox("Rasă", breeds)`     |
| `st.button("label")`             | Buton pe care îl poți apăsa                 | `st.button("Caută")`               |
| `st.slider("label", min, max)`   | Slider pentru valori numerice               | `st.slider("Număr", 1, 10, 5)`     |
| `st.image(url)`                  | Afișează o imagine dintr-un URL             | `st.image(data["sprite"])`         |
| `st.metric("label", value)`      | Afișează un indicator numeric               | `st.metric("HP", 45)`              |
| `st.columns(n)`                  | Creează coloane alăturate                   | `col1, col2 = st.columns(2)`       |
| `st.json(data)`                  | Afișează JSON brut                          | `st.json(response.json())`         |
| `st.dataframe(df)`               | Afișează un tabel interactiv                | `st.dataframe(my_dataframe)`       |
| `st.spinner("text")`             | Afișează indicator de încărcare             | `with st.spinner("Se încarcă...")` |
| `st.success("text")`             | Mesaj verde de succes                       | `st.success("Gata!")`              |
| `st.error("text")`               | Mesaj roșu de eroare                        | `st.error("Nu a fost găsit")`      |
| `st.warning("text")`             | Mesaj galben de avertizare                  | `st.warning("Încearcă din nou")`   |
| `st.expander("label")`           | Secțiune care se poate deschide sau închide | `with st.expander("Detalii")`      |
""")
