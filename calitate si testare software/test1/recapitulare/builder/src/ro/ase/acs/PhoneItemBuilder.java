package ro.ase.acs;

public class PhoneItemBuilder {
    private boolean glassCase;
    private boolean screenProtection;
    private boolean extendedMemory;
    private boolean giftCase;
    private boolean insurance;

    public PhoneItemBuilder addGlassCase(boolean glassCase) {
        this.glassCase = glassCase;
        return this; // Permite înlănțuirea: .addX().addY()
    }

    public PhoneItemBuilder addScreenProtection(boolean screenProtection) {
        this.screenProtection = screenProtection;
        return this;
    }

    public PhoneItemBuilder addExtendedMemory(boolean extendedMemory) {
        this.extendedMemory = extendedMemory;
        return this;
    }

    public PhoneItemBuilder addGiftCase(boolean giftCase) {
        this.giftCase = giftCase;
        return this;
    }

    public PhoneItemBuilder addInsurance(boolean insurance) {
        this.insurance = insurance;
        return this;
    }

    public PhoneItem build() {
        return new PhoneItem(glassCase, screenProtection, extendedMemory, giftCase, insurance);
    }
}
