package ro.ase.acs.task5;

public class HightechFactory implements Factory{
    @Override
    public Sector createSector() {
        return new HightechSector();
    }
}
