package ro.ase.acs.task3;

import java.util.ArrayList;

public abstract class Cartier implements Cloneable {
    ArrayList<String> buildings;
    int parcuri;
    ArrayList<String> utilities;
    boolean pollutionSensors;

    public ArrayList<String> getBuildings() {
        return new ArrayList<>(buildings);
    }

    public void setBuildings(ArrayList<String> buildings) {
        this.buildings = buildings;
    }

    public int getParcuri() {
        return parcuri;
    }

    public void setParcuri(int parcuri) {
        this.parcuri = parcuri;
    }

    public ArrayList<String> getUtilities() {
        return new ArrayList<>(utilities);
    }

    public void setUtilities(ArrayList<String> utilities) {
        this.utilities = utilities;
    }

    public boolean isPollutionSensors() {
        return pollutionSensors;
    }

    public void setPollutionSensors(boolean pollutionSensors) {
        this.pollutionSensors = pollutionSensors;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        CartierModel copy = (CartierModel) super.clone();
        copy.buildings = new ArrayList<>(this.buildings);
        copy.parcuri = this.parcuri;
        copy.utilities = new ArrayList<>(utilities);
        copy.pollutionSensors = this.pollutionSensors;
        return copy;
    }

    public abstract void show();
}
