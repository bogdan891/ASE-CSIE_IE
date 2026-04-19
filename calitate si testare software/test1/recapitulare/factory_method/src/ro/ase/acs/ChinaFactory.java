package ro.ase.acs;

public class ChinaFactory implements PhoneFactory {

    @Override
    public Phone createPhone() {
        return new ChinaPhone();
    }
}
