package ro.ase.acs;

import java.util.ArrayList;

public class TestPhone extends Phone{
    public TestPhone() {
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        return super.clone();
    }

    public TestPhone(int brightness, ArrayList<String> apps, ArrayList<String> contacts) {
        super(brightness, apps, contacts);
    }

    @Override
    public void showSpecs() {
        System.out.println("=== SPECIFICAȚII TELEFON TEST ===");
        System.out.println("Luminozitate: " + brightness);
        System.out.println("Număr Aplicații: " + apps.size());
        System.out.println("Lista Contacte: " + String.join(", ", contacts));
        System.out.println("=================================");
    }
}
