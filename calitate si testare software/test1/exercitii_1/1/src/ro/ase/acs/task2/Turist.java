package ro.ase.acs.task2;

public class Turist implements Ticket{
    Turist() {}

    @Override
    public void showDiscount() {
        System.out.println("Turistii nu au reducere");
    }
}
