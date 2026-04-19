package ro.ase.acs.task6;

import java.util.HashMap;
import java.util.Map;

public class RegistruServicii {
    private static final Map<String, Serviciu> registry = new HashMap<>();

    public static Serviciu getSingleton(String nume) {
        if (!registry.containsKey(nume)) {
            registry.put(nume, new Serviciu(nume));
        }
        return registry.get(nume);
    }

    public static class Serviciu {
        private String nume;
        Serviciu(String nume) {
            this.nume = nume;
        }

        public void execute() {
            System.out.println("Se presteaza serviciul: " + nume);
        }
    }
}
