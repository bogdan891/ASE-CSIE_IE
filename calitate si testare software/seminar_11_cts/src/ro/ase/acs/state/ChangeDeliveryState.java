package ro.ase.acs.state;

public class ChangeDeliveryState implements VendingMachineState{
    @Override
    public void displayMessage() {
        System.out.println("Pick up your change, peasant!");
    }
}
