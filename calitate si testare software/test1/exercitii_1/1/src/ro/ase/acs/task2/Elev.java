package ro.ase.acs.task2;

public class Elev implements Ticket {
    Elev() {}

    @Override
    public void showDiscount() {
        System.out.println("Elevii au gratuitate");
    }
}
