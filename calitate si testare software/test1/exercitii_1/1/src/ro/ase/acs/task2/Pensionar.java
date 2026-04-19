package ro.ase.acs.task2;

public class Pensionar implements Ticket{
    Pensionar() {}

    @Override
    public void showDiscount() {
        System.out.println("Pensionarii au reducere de 50%");
    }
}
