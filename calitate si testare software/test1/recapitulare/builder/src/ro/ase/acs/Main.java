package ro.ase.acs;

public class Main {
    public static void main(String[] args) {
        /**
         * Utilizatorul își poate cumpăra un telefon personalizat.
         * El poate alege: carcasă de sticlă, protecție ecran, memorie extinsă,
         * husă cadou sau asigurare. Dacă utilizatorul nu alege nimic,
         * telefonul vine în varianta standard (fără accesorii).
         * Se dorește un modul care să permită construcția pas cu pas
         * a acestei comenzi complexe, fără a avea un constructor cu 10 parametri.
         */
        PhoneItemBuilder builder = new PhoneItemBuilder();
        PhoneItemDirector director = new PhoneItemDirector();
        PhoneItem standardPhone = director.create();
        PhoneItem customPhone = builder.addInsurance(true).addExtendedMemory(true).build();
        System.out.println("Varianta Standard: " + standardPhone);
        System.out.println("Varianta Custom: " + customPhone);
    }
}