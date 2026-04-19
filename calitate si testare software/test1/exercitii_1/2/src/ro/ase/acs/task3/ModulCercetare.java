package ro.ase.acs.task3;

import java.util.ArrayList;
import java.util.Arrays;

public class ModulCercetare extends ModulSupravietuire {

    ModulCercetare() {
        super();
        this.serieCapsula = "RES-PROTO-01";
        this.inventar.addAll(Arrays.asList("Microscop Laser", "Scanner Geologic", "Senzor Atmosferic"));
    }

    @Override
    public void afisareStatus() {
        System.out.println(">>> Status Modul Cercetare <<<");
        System.out.println("ID Capsulă: " + serieCapsula);
        System.out.println("Echipament bord: " + inventar);
        System.out.println("----------------------------");
    }
}