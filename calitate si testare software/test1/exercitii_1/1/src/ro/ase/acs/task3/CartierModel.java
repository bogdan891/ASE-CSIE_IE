package ro.ase.acs.task3;

import java.util.ArrayList;
import java.util.List;

public class CartierModel extends Cartier {

    public CartierModel() {
        this.buildings = new ArrayList<>();
        this.utilities = new ArrayList<>();
    }

    @Override
    public void show() {
        System.out.println("Cladiri" + this.getBuildings() + ", Parcuri: " + this.getParcuri() + ", Utilitati" + this.getUtilities() + ", Senzori Poluare: " + this.isPollutionSensors());
    }
}
