package ro.ase.acs.task5;

public class RezidentialSector extends Sector{
    RezidentialSector() {
        this.energie = "EOLIANA";
    }
    @Override
    public void gestiuneEnergie() {
        System.out.println("Energie: " + this.energie);
    }
}
