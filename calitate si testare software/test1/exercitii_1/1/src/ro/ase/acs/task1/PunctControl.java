package ro.ase.acs.task1;

public class PunctControl {
    private static PunctControl instance;

    private PunctControl() {}

    public static synchronized PunctControl getInstance() {
        if (instance == null) instance = new PunctControl();
        return instance;
    }

    public void use() {
        System.out.println("Se utilizeaza punctul de control trafic");
    }
}
