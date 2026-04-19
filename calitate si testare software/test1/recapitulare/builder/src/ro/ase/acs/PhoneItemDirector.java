package ro.ase.acs;

public class PhoneItemDirector {
    private PhoneItemBuilder phoneItemBuilder ;
    public PhoneItem create() {
    phoneItemBuilder= new PhoneItemBuilder();
    phoneItemBuilder.addGlassCase(false)
            .addScreenProtection(false)
            .addInsurance(false);
    return phoneItemBuilder.build();
    }
}
