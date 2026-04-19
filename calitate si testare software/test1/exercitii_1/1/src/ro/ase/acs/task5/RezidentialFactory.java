package ro.ase.acs.task5;

public class RezidentialFactory implements Factory{
    @Override
    public Sector createSector() {
        return new RezidentialSector();
    }
}
