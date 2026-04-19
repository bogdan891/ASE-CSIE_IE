package ro.ase.acs;

public class PhoneFactory {
    public Phone getPhone(PhoneType type) {
        return switch (type) {
            case CHEAP -> new CheapPhone();
            case NORMAL -> new NormalPhone();
            case PREMIUM -> new PremiumPhone();
        };
    }
}
