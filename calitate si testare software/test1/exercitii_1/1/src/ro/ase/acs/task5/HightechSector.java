package ro.ase.acs.task5;

public class HightechSector extends Sector{
    HightechSector() {
        this.energie = "SOLARA";
    }

    @Override
    public void gestiuneEnergie() {
        System.out.println("Energie: " + this.energie);
    }
}
