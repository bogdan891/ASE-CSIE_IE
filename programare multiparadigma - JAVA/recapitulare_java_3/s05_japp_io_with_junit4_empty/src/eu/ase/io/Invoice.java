package eu.ase.io;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.EOFException;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;

// create Invoice class which contains:
// A. Fields:
// A.1 - prices: double[]
// A.2 - units: int[]
// A.3 - descs: String[] - descriptions of the products within invoice
// B. Methods:
// B.1 - constructor: public Invoice(int[] units, double[] prices, String[] productsDesc)
// B.2 - get and set methods
// B.3 - public void saveInvoice2File(String invoiceFileName) - save the invoice values (in order of the described fields) 
// into a file
// B.4 - public double readInvoiceFromFileAndCalcTotal(String invoiceFileName) - read from the file and calculate 
// the total of the invoice
// B.5 - clone method for deep copy

public class Invoice implements Cloneable {
	private double[] prices;
	private int[] units;
	private String[] descs;
	
	public Invoice(int[] units, double[] prices, String[] productsDesc) {
		if(units != null) {
			this.units = new int[units.length];
			for(int i=0; i < units.length; i++) {
				this.units[i] = units[i];
			}
		}
		else {
			this.units = null;
		}
		
		if(prices != null) {
			this.prices = new double[prices.length];
			for(int i=0; i < units.length; i++) {
				this.prices[i] = prices[i];
			}
		} else {
			this.prices = null;
		}
		
		if(productsDesc != null) {
			this.descs = new String[productsDesc.length];
			for(int i=0; i < units.length; i++) {
				this.descs[i] = productsDesc[i];
			}
		} else {
			this.descs = null;
		}
	}
	
	public Invoice() {
		// TODO Auto-generated constructor stub
	}

	public void saveInvoice2File(String invoiceFileName) {
	    try (FileOutputStream fos = new FileOutputStream(invoiceFileName);
	         BufferedOutputStream bos = new BufferedOutputStream(fos);
	         DataOutputStream dos = new DataOutputStream(bos)) {

	        int length = (units != null) ? units.length : 0;
	        dos.writeInt(length);

	        for (int i = 0; i < length; i++) {
	            dos.writeInt(units[i]);
	        }

	        for (int i = 0; i < length; i++) {
	            dos.writeDouble(prices[i]);
	        }

	        for (int i = 0; i < length; i++) {
	            dos.writeUTF(descs[i]);
	        }
	        
	        dos.close();

	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	}
	
	public double readInvoiceFromFileAndCalcTotal(String invoiceFileName) {
		double total = 0;
		
		try (FileInputStream fis = new FileInputStream(invoiceFileName);
			BufferedInputStream bis = new BufferedInputStream(fis);
			DataInputStream dis = new DataInputStream(bis);) {
			
			int length = dis.readInt();
			
			if(length > 0) {
				this.units = new int[length];
				this.prices = new double[length];
				this.descs = new String[length];
				
				for (int i = 0; i < length; i++) {
					this.units[i] = dis.readInt();
				}
				
				for (int i = 0; i < length; i++) {
					this.prices[i] = dis.readDouble();
				}
				
				for (int i = 0; i < length; i++) {
					this.descs[i] = dis.readUTF();
				}
				
				for (int i = 0; i < length; i++) {
					total += this.units[i] * this.prices[i];
				}
				
				dis.close();
			} else {
				this.units = null;
				this.prices = null;
				this.descs = null;
			}
			
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return total;
	}

	@Override
	public Invoice clone() throws CloneNotSupportedException {
		Invoice i = (Invoice)super.clone();
		if(this.units != null) {
			i.units = new int[this.units.length];
			for(int index=0; index < this.units.length; index++) {
				i.units[index] = this.units[index];
			}
		}
		else {
			i.units = null;
		}
		
		if(this.prices != null) {
			i.prices = new double[this.prices.length];
			for(int index=0; index < this.prices.length; index++) {
				i.prices[index] = prices[index];
			}
		} else {
			i.prices = null;
		}
		
		if(this.descs != null) {
			i.descs = new String[this.descs.length];
			for(int index=0; index < this.prices.length; index++) {
				i.descs[index] = this.descs[index];
			}
		} else {
			i.descs = null;
		}
		
		return i;
	}
}
