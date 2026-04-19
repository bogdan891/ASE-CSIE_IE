package ro.ase.acs;

public class PhoneItem {
    private boolean glassCase;
    private boolean screenProtection;
    private boolean extendedMemory;
    private boolean giftCase;
    private boolean insurance;

    PhoneItem() {}

    PhoneItem(boolean glassCase, boolean screenProtection,
              boolean extendedMemory, boolean giftCase, boolean insurance) {
        this.glassCase = glassCase;
        this.screenProtection = screenProtection;
        this.extendedMemory = extendedMemory;
        this.giftCase = giftCase;
        this.insurance = insurance;
    }

    public boolean isGlassCase() {
        return glassCase;
    }

    public boolean isScreenProtection() {
        return screenProtection;
    }

    public boolean isExtendedMemory() {
        return extendedMemory;
    }

    public boolean isGiftCase() {
        return giftCase;
    }

    public boolean isInsurance() {
        return insurance;
    }

    public String toString() {
        return "Comandă Telefon: [" +
                "Carcasă sticlă=" + glassCase +
                ", Protecție ecran=" + screenProtection +
                ", Memorie extinsă=" + extendedMemory +
                ", Husă cadou=" + giftCase +
                ", Asigurare=" + insurance +
                ']';
    }
}
