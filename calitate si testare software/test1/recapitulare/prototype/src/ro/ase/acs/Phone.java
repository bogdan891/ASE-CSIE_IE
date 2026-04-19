package ro.ase.acs;

import java.util.ArrayList;

public abstract class Phone implements Cloneable {
    int brightness;
    ArrayList<String> apps;
    ArrayList<String> contacts;

    public Phone(){
        this.apps = new ArrayList<>();
        this.contacts = new ArrayList<>();
    }

    public Phone(int brightness, ArrayList<String> apps, ArrayList<String> contacts) {
        this.brightness = brightness;
        this.apps = new ArrayList<>(apps);
        this.contacts = new ArrayList<>(contacts);
    }

    public int getBrightness() {
        return brightness;
    }

    public void setBrightness(int brightness) {
        this.brightness = brightness;
    }

    public ArrayList<String> getApps() {
        return new ArrayList<>(apps);
    }

    public void setApps(ArrayList<String> apps) {
        if (apps != null) this.apps = new ArrayList<>(apps);
        else this.apps = null;
    }

    public ArrayList<String> getContacts() {
        return new ArrayList<>(contacts);
    }

    public void setContacts(ArrayList<String> contacts) {
        if (contacts != null) this.contacts = new ArrayList<>(contacts);
        else this.contacts = null;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Phone copy = (Phone) super.clone();
        copy.brightness = this.brightness;
        copy.apps = new ArrayList<>(this.apps);
        copy.contacts = new ArrayList<>(this.contacts);
        return copy;
    }

    public abstract void showSpecs();
}
