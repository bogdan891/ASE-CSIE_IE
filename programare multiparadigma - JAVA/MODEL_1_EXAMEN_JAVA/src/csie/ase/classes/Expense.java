package csie.ase.classes;

import java.io.Serializable;

import csie.ase.utils.Payable;
import csie.ase.utils.PaymentException;

public class Expense implements Payable, Serializable, Cloneable {
	private static final long serialVersionUID = 1L;
	private String type;
	private double amount;
	 
	public String getType() {
		return type;
	}
	
	public void setType(String type) {
		this.type = type;
	}
	
	public double getAmount() {
		return amount;
	}
	
	public void setAmount(double amount) {
		this.amount = amount;
	}
	
	public Expense() {
		this.type = "General";
		this.amount = 0;
	}

	public Expense(String type, double amount) {
		super();
		this.type = type;
		this.amount = amount;
	} 
	
	public void pay() throws PaymentException
	{
		if (amount <= 0) {
            throw new PaymentException("Suma trebuie să fie mai mare ca 0!");
        }
        System.out.println("Ai plătit " + amount + " RON pentru " + type);
	}

	@Override
	protected Expense clone() throws CloneNotSupportedException {
		return new Expense(this.type, this.amount);
	}
}
