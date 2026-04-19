package ro.ase.acs;

public class GermanyPhone implements  Phone{
    private String screen;

    GermanyPhone() {
        this.screen = "OLED";
    }

    @Override
    public void show() {
        System.out.println("Ecran OLED (Standard Germany)");
    }
}
