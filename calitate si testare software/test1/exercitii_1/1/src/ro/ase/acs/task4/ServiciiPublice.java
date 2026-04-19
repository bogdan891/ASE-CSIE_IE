package ro.ase.acs.task4;

public class ServiciiPublice {
    private boolean colectareSelectiva;
    private boolean iluminatInteligent;
    private boolean parcareRezervata;
    private boolean accesBiblioteca;
    private boolean monitorizareVideo;

    ServiciiPublice(boolean colectareSelectiva, boolean iluminatInteligent, boolean parcareRezervat, boolean accesBiblioteca, boolean monitorizareVideo) {
        this.colectareSelectiva = colectareSelectiva;
        this.iluminatInteligent = iluminatInteligent;
        this.parcareRezervata = parcareRezervat;
        this.accesBiblioteca = accesBiblioteca;
        this.monitorizareVideo = monitorizareVideo;
    }

    public ServiciiPublice() {
    }

    public void setColectareSelectiva(boolean colectareSelectiva) {
        this.colectareSelectiva = colectareSelectiva;
    }

    public void setIluminatInteligent(boolean iluminatInteligent) {
        this.iluminatInteligent = iluminatInteligent;
    }

    public void setParcareRezervata(boolean parcareRezervata) {
        this.parcareRezervata = parcareRezervata;
    }

    public void setAccesBiblioteca(boolean accesBiblioteca) {
        this.accesBiblioteca = accesBiblioteca;
    }

    public void setMonitorizareVideo(boolean monitorizareVideo) {
        this.monitorizareVideo = monitorizareVideo;
    }

    @Override
    public String toString() {
        return "Pachet Servicii Publice: [" +
                "Colectare Selectivă = " + (colectareSelectiva ? "DA" : "NU") +
                ", Iluminat Inteligent = " + (iluminatInteligent ? "DA" : "NU") +
                ", Parcare Rezervată = " + (parcareRezervata ? "DA" : "NU") +
                ", Acces Bibliotecă = " + (accesBiblioteca ? "DA" : "NU") +
                ", Monitorizare Video = " + (monitorizareVideo ? "DA" : "NU") +
                "]";
    }

    public static class Builder {
        ServiciiPublice sp = new ServiciiPublice();
        public Builder addColectare(boolean status) {
            sp.colectareSelectiva = status;
            return this;
        }

        public Builder addIluminat(boolean status) {
            sp.iluminatInteligent = status;
            return this;
        }

        public Builder addParcare(boolean status) {
            sp.parcareRezervata = status;
            return this;
        }

        public Builder addBiblioteca(boolean status) {
            sp.accesBiblioteca = status;
            return this;
        }

        public Builder addMonitorizare(boolean status) {
            sp.monitorizareVideo = status;
            return this;
        }

        public ServiciiPublice build() {
            ServiciiPublice copy = sp;
            sp = new ServiciiPublice();
            return copy;
        }
    }
}
