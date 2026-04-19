package ro.ase.acs;

public class Main {
    public static void main(String[] args) throws CloneNotSupportedException {
        final String STD = "STANDARD_TEST";
        /**
         * Pentru a economisi timp în procesul de testare, inginerii vor să creeze un "Telefon de Test"
         * complet configurat (cu toate aplicațiile, setările de luminozitate și contactele salvate).
         * Deoarece configurarea manuală durează 20 de minute, ei vor un buton care să multiplice acest
         * telefon de test deja configurat pentru a livra rapid 100 de unități identice către laboratorul de probe.
         */

        PhoneCollection collection = new PhoneCollection();
        Phone p1 = collection.getPhone(STD);
        p1.setBrightness(50);
        p1.getApps().add("Sistem de Operare");
        p1.showSpecs();
        Phone p2 = collection.getPhone(STD);
        p2.showSpecs();
        if(p1 == p2) System.out.println("Same");
        else System.out.println("Diff");
    }
}