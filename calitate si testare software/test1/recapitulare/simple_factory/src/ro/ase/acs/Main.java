package ro.ase.acs;

public class Main {
    /**
     *Fabrica produce trei modele de bază: Ieftin, Normal și Premium.
     * Se dorește realizarea unui modul care să permită instanțierea acestor telefoane pe baza unui Enum primit ca parametru.
     * Clientul (magazinul) nu trebuie să știe cum se asamblează procesorul sau ecranul,
     * ci doar să ceară un "Telefon Ieftin" și să primească obiectul gata făcut.
     */
    public static void main(String[] args) {
        PhoneFactory factory = new PhoneFactory();
        Phone p1 = factory.getPhone(PhoneType.CHEAP);
        Phone p2 = factory.getPhone(PhoneType.PREMIUM);
        p1.showSpecs();
        p2.showSpecs();
    }
}