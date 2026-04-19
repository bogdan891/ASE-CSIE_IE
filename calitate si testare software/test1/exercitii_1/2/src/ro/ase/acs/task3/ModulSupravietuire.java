package ro.ase.acs.task3;

import java.util.ArrayList;
import java.util.List;

public abstract class ModulSupravietuire implements Cloneable {
    protected String serieCapsula;
    protected List<String> inventar;

    ModulSupravietuire() {
        this.inventar = new ArrayList<>();
    }

    public void setSerieCapsula(String serieCapsula) {
        this.serieCapsula = serieCapsula;
    }

    public void setInventar(List<String> inventar) {
        this.inventar = new ArrayList<>(inventar);
    }

    public List<String> getInventar() {
        return inventar;
    }

    // Metoda de afișare pentru testare
    public abstract void afisareStatus();

    // Implementarea DEEP COPY
    @Override
    public Object clone() throws CloneNotSupportedException {
        ModulSupravietuire copie = (ModulSupravietuire) super.clone();
        copie.inventar = new ArrayList<>(this.inventar);
        return copie;
    }
}