package ro.ase.acs;

public class ChinaPhone implements  Phone{
    private String screen;

    ChinaPhone() {
        this.screen = "LCD";
    }

    @Override
    public void show() {
        System.out.println("Ecran LCD (Standard China)");
    }
}
