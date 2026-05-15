package ro.ase.acs.state;

public class MoneyInputState implements  VendingMachineState{
    @Override
    public void displayMessage() {
        System.out.println("You better have my money...");
    }
}
