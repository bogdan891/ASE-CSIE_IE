package ro.ase.acs;

public class GermanyFactory implements PhoneFactory {
    @Override
    public Phone createPhone() {
        return new GermanyPhone();
    }
}
