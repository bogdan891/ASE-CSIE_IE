package ro.ase.acs.interfaces;

public interface Taxable {
    float computeTax();
    default boolean isTaxabel() {
       return true;
    };
}
