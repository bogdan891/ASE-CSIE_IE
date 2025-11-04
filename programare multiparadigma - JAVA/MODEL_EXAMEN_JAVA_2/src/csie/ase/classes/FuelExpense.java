package csie.ase.classes;

public class FuelExpense extends CarExpense{
	private static final long serialVersionUID = 1L;
	private String fuelType;

    public FuelExpense(double amount, String fuelType) {
        super("fuel", amount);
        this.fuelType = fuelType;
    }

    public String getFuelType() {
        return fuelType;
    }

    public void setFuelType(String fuelType) {
        this.fuelType = fuelType;
    }

    @Override
    public String toString() {
        return super.toString() + " [fuelType=" + fuelType + "]";
    }
}
