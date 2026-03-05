import streamlit as st
import requests
import pandas as pd

st.title("Vizualizator profil GitHub")

st.markdown("""
### Prezentare generală
Această aplicație folosește **API-ul public GitHub** pentru a afișa informații despre orice utilizator GitHub.
Nu este necesară cheie API, dar există o limită de 60 de cereri pe oră.

- `st.text_input` pentru introducerea unui username
- `st.image` pentru afișarea avatarului
- `st.metric` pentru statistici importante
- `st.tabs` pentru organizarea conținutului
- `st.dataframe` pentru afișarea datelor tabelare
- `st.link_button` pentru linkuri externe
""")

st.markdown("---")

# -------------------------------------------------------------------
# Funcții API
# -------------------------------------------------------------------

@st.cache_data
def get_github_user(username):
    """Preia datele profilului unui utilizator GitHub."""
    url = f"https://api.github.com/users/{username}"
    response = requests.get(url)
    if response.status_code == 200:
        return response.json()
    return None


@st.cache_data
def get_github_repos(username):
    """Preia repository-urile publice ale unui utilizator GitHub."""
    url = f"https://api.github.com/users/{username}/repos?sort=updated&per_page=10"
    response = requests.get(url)
    if response.status_code == 200:
        return response.json()
    return None

# -------------------------------------------------------------------
# Interfața utilizator
# -------------------------------------------------------------------

username = st.text_input("Introdu un username GitHub", value="torvalds")

if st.button("Caută"):
    with st.spinner("Se preiau datele profilului..."):
        user = get_github_user(username)

    if user is None:
        st.error(f"Nu s-a găsit utilizatorul GitHub: '{username}'. Verifică ortografia.")
    else:
        # Antet profil
        col1, col2 = st.columns([1, 3])

        with col1:
            avatar_url = user.get("avatar_url", "")
            if avatar_url:
                st.image(avatar_url, width=150)

        with col2:
            display_name = user.get("name", username)
            st.subheader(display_name)

            bio = user.get("bio", "")
            if bio:
                st.write(bio)

            location = user.get("location", "")
            if location:
                st.write(f"**Locație:** {location}")

            company = user.get("company", "")
            if company:
                st.write(f"**Companie:** {company}")

            st.link_button("Vezi pe GitHub", user.get("html_url", f"https://github.com/{username}"))

        # Statistici
        st.divider()
        col1, col2, col3, col4 = st.columns(4)
        col1.metric("Repo-uri publice", user.get("public_repos", 0))
        col2.metric("Followers", user.get("followers", 0))
        col3.metric("Following", user.get("following", 0))
        col4.metric("Gists publice", user.get("public_gists", 0))

        # Taburi pentru repo-uri și date brute
        tab1, tab2 = st.tabs(["Repo-uri recente", "Date brute profil"])

        with tab1:
            repos = get_github_repos(username)
            if repos:
                repo_data = []
                for repo in repos:
                    repo_data.append({
                        "Nume": repo.get("name", ""),
                        "Descriere": repo.get("description", "") or "",
                        "Limbaj": repo.get("language", "") or "N/A",
                        "Stars": repo.get("stargazers_count", 0),
                        "Forks": repo.get("forks_count", 0),
                        "URL": repo.get("html_url", "")
                    })
                df = pd.DataFrame(repo_data)
                st.dataframe(df, use_container_width=True, hide_index=True)
            else:
                st.info("Nu există repository-uri publice.")

        with tab2:
            st.json(user)

st.markdown("---")
st.markdown("""
### Cum funcționează
1. Utilizatorul introduce un username GitHub.
2. Aplicația face două cereri API:
   - `https://api.github.com/users/{username}` pentru datele profilului.
   - `https://api.github.com/users/{username}/repos?sort=updated&per_page=10` pentru repository-urile recente.
3. Informațiile profilului sunt afișate folosind `st.image`, `st.metric` și `st.link_button`.
4. Repository-urile sunt afișate într-un `st.dataframe` organizat în `st.tabs`.

API-ul public GitHub permite 60 de cereri pe oră fără autentificare.
Decoratorul `@st.cache_data` salvează temporar rezultatele pentru a evita cereri repetate.

Documentație API: GitHub REST API
""")