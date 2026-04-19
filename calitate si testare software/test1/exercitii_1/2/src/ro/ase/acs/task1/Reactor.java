package ro.ase.acs.task1;

public class Reactor {
    private static Reactor instance;

    /**Nava spațială are un singur Reactor cu Antimaterie.
    Din motive de siguranță extremă, dacă două module diferite
     ar încerca să creeze instanțe separate ale controlerului de reactor,
     nava ar exploda din cauza conflictelor de fază. Trebuie să garantezi
     că orice componentă a navei (Navigație, Life Support) accesează aceeași
     poartă de comunicare cu reactorul, creată abia la prima solicitare,
     pentru a economisi energie la decolare.*/

    private Reactor() {}

    public static synchronized Reactor getInstance() {
        if(instance == null) instance = new Reactor();
        return instance;
    }

    public void use() {
        System.out.println("Reactorul este in uz...");
    }
}
