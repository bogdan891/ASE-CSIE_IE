package ro.ase.acs.state;

public class VendingMachine {
    private VendingMachineState vendingMachineState;
    private double balance;

    public VendingMachine() {
        this.vendingMachineState = new MoneyInputState();
        this.balance = 0;
        this.vendingMachineState.displayMessage();
    }

    public void setVendingMachineState(VendingMachineState vendingMachineState) {
        this.vendingMachineState = vendingMachineState;
    }

    public void inputMoney(double amount) {
        this.balance += amount;
        this.vendingMachineState = new ProductSelectionState();
        this.vendingMachineState.displayMessage();
    }

    public void buyProduct(double price) {
        if(price <= this.balance) {
            this.balance -= price;
            this.vendingMachineState = new ProductDeliveryState();
            this.vendingMachineState.displayMessage();

            if (this.balance > 0) {
                this.balance = 0;
                this.vendingMachineState = new ChangeDeliveryState();
                this.vendingMachineState.displayMessage();
            }
        }
        this.vendingMachineState = new MoneyInputState();
        vendingMachineState.displayMessage();
    }
}
