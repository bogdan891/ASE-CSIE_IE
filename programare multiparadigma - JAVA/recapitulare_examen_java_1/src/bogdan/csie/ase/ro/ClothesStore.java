package bogdan.csie.ase.ro;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Objects;

public class ClothesStore extends Store implements Cloneable, StoreAction, Serializable {
	private static final long serialVersionUID = 1L;
	private String name;
	private Products style;
	private int nbOfWorkers;
	private float[] priceOfArticle;
	
	//Getters & Setters
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public Products getStyle() {
		return style;
	}
	
	public void setStyle(Products style) {
		this.style = style;
	}
	
	public int getNbOfWorkers() {
		return nbOfWorkers;
	}
	
	public void setNbOfWorkers(int nbOfWorkers) {
		if(nbOfWorkers > 0) {
			this.nbOfWorkers = nbOfWorkers;
		} else {
			throw new IllegalArgumentException("The area of store must be positive!");
		}
	}
	
	public float[] getPriceOfArticle() {
	    return priceOfArticle != null ? Arrays.copyOf(priceOfArticle, priceOfArticle.length) : null;
	}
	
	public void setPriceOfArticle(float[] priceOfArticle) {
		if(priceOfArticle != null) {
			this.priceOfArticle = new float[priceOfArticle.length];
			this.priceOfArticle = Arrays.copyOf(priceOfArticle, priceOfArticle.length);
		} else {
			this.priceOfArticle = null;
		}
	}
	
	//Constructors
	
	public ClothesStore() {
		super();
		this.name = "N/A";
		this.style = Products.Default;
		this.nbOfWorkers = 0;
		this.priceOfArticle = null;
		nbOfStores++;
	}

	public ClothesStore(String address, String owner, double area, String name, Products style, int nbOfWorkers, float[] priceOfArticle) {
		super(address, owner, area);
		this.name = name;
		this.style = style;
		this.nbOfWorkers = nbOfWorkers;
		if(priceOfArticle != null) {
			this.priceOfArticle = new float[priceOfArticle.length];
			this.priceOfArticle = Arrays.copyOf(priceOfArticle, priceOfArticle.length);
		} else {
			this.priceOfArticle = null;
		}
		nbOfStores++;
	}

	//Override / Implements methods
	
	@Override
	public int compareTo(ClothesStore o) {
		return super.compareTo(o);
	}

	@Override
	public float calculatePrice() {
		int sum = 0;
		for( float x : this.priceOfArticle) {
			sum+=x;
		}
		return sum;
	}

	@Override
	public int hashCode() {
		return Objects.hash(super.hashCode(), this.name, this.style, this.nbOfWorkers, this.priceOfArticle);
	}

	@Override
	public boolean equals(Object obj) {
		if(this == obj) return true;
		if(obj == null || getClass() != obj.getClass()) return false;
		ClothesStore c = (ClothesStore) obj;
		return super.equals(c) && this.name.equals(c.name) && 
				this.style.equals(c.style) && Integer.compare(this.nbOfWorkers, c.nbOfWorkers) == 0 
				&& Arrays.compare(this.priceOfArticle, c.priceOfArticle) == 0;
	}

	@Override
	public ClothesStore clone() throws CloneNotSupportedException {
		return new ClothesStore(this.getAddress(), this.getOwner(), this.getArea(), this.getName(), 
				this.getStyle(), this.getNbOfWorkers(), this.getPriceOfArticle());
	}

	@Override
	public String toString() {
		return "Store: " + this.getName() + ", owned by " + this.getOwner() + ", address: " + this.getAddress();
 	}
	
	//Writing in binary files
	public void saveBinaryStore() {
		boolean append = true;
		try(DataOutputStream dos = new DataOutputStream(new BufferedOutputStream(new FileOutputStream("stores.bin", append)))) {
			dos.writeUTF(this.getAddress());
			dos.writeUTF(this.getOwner());
			dos.writeDouble(this.getArea());
			dos.writeUTF(this.getName());
			dos.writeUTF(this.getStyle().name());
			dos.writeInt(this.getNbOfWorkers());
			
			if(this.getPriceOfArticle() != null) {
				dos.writeBoolean(true);
				dos.writeInt(this.getPriceOfArticle().length);
				for(float x : this.getPriceOfArticle()) {
					dos.writeFloat(x);
				}
			} else {
				dos.writeBoolean(false);
			}
			dos.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	//Reading from binary files
	public ClothesStore readBinaryStore() {
		ClothesStore x = new ClothesStore();
		try (DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream("store.bin")))) {
			String address = dis.readUTF();
			String owner = dis.readUTF();
			double area = dis.readDouble();
			String name = dis.readUTF();
			String styleName = dis.readUTF();
			Products style = Products.valueOf(styleName);
			int nbOfWorkers = dis.readInt();

			float[] priceOfArticle = null;
			boolean ok = dis.readBoolean();
			if (ok) {
				int length = dis.readInt();
				priceOfArticle = new float[length];
				for (int i = 0; i < length; i++) {
					priceOfArticle[i] = dis.readFloat();
				}
			}

			x.setAddress(address);
			x.setOwner(owner);
			x.setArea(area);
			x.setName(name);
			x.setStyle(style);
			x.setNbOfWorkers(nbOfWorkers);
			
			if (ok) {
				x.setPriceOfArticle(priceOfArticle);
			}

		} catch (IOException e) {
			e.printStackTrace();
		}
		return x;
	}
	
	public static List<ClothesStore> readAllStores(String fileName) {
		List<ClothesStore> list = new ArrayList<>();

		try (DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream(fileName)))) {
			while (dis.available() > 0) {
				String address = dis.readUTF();
				String owner = dis.readUTF();
				double area = dis.readDouble();
				String name = dis.readUTF();
				Products style = Products.valueOf(dis.readUTF());
				int nbOfWorkers = dis.readInt();

				float[] prices = null;
				boolean hasPrices = dis.readBoolean();
				if (hasPrices) {
					int n = dis.readInt();
					prices = new float[n];
					for (int i = 0; i < n; i++) {
						prices[i] = dis.readFloat();
					}
				}

				ClothesStore cs = new ClothesStore(address, owner, area, name, style, nbOfWorkers, prices);
				list.add(cs);
			}

		} catch (IOException e) {
			e.printStackTrace();
		}

		return list;
	}
	
	//Writing in *.txt files
	public void saveTextStore(String fileName) {
		try (BufferedWriter writer = new BufferedWriter(new FileWriter(fileName))) {
			writer.write(this.getAddress());
			writer.newLine();

			writer.write(this.getOwner());
			writer.newLine();

			writer.write(Double.toString(this.getArea()));
			writer.newLine();

			writer.write(this.getName());
			writer.newLine();

			writer.write(this.getStyle().name());
			writer.newLine();

			writer.write(Integer.toString(this.getNbOfWorkers()));
			writer.newLine();

			if (this.getPriceOfArticle() != null) {
				writer.write(Integer.toString(this.getPriceOfArticle().length));
				writer.newLine();
				for (float price : this.getPriceOfArticle()) {
					writer.write(Float.toString(price));
					writer.newLine();
				}
			} else {
				writer.write("0");
				writer.newLine();
			}

		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	
	//Reading from *.txt files
	public static ClothesStore readTextStore(String fileName) {
		ClothesStore cs = new ClothesStore();

		try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
			String address = reader.readLine();
			String owner = reader.readLine();
			double area = Double.parseDouble(reader.readLine());
			String name = reader.readLine();
			Products style = Products.valueOf(reader.readLine());
			int nbOfWorkers = Integer.parseInt(reader.readLine());

			int nrPrices = Integer.parseInt(reader.readLine());
			float[] prices = null;
			if (nrPrices > 0) {
				prices = new float[nrPrices];
				for (int i = 0; i < nrPrices; i++) {
					prices[i] = Float.parseFloat(reader.readLine());
				}
			}

			cs.setAddress(address);
			cs.setOwner(owner);
			cs.setArea(area);
			cs.setName(name);
			cs.setStyle(style);
			cs.setNbOfWorkers(nbOfWorkers);
			cs.setPriceOfArticle(prices);

		} catch (IOException e) {
			e.printStackTrace();
		}

		return cs;
	}
	
	//Writing/Reading from *.csv
	public void saveToCSV(String fileName) {
	    try (BufferedWriter writer = new BufferedWriter(new FileWriter(fileName, true))) {
	        writer.write(this.getAddress() + "," + this.getOwner() + "," + this.getArea() + "," +
	                     this.getName() + "," + this.getStyle().name() + "," + this.getNbOfWorkers());

	        if (this.getPriceOfArticle() != null) {
	            for (float price : this.getPriceOfArticle()) {
	                writer.write("," + price);
	            }
	        }
	        writer.newLine();
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	}

	public static ClothesStore readFromCSVLine(String line) {
	    String[] tokens = line.split(",");
	    if (tokens.length < 6) return null;

	    String address = tokens[0];
	    String owner = tokens[1];
	    double area = Double.parseDouble(tokens[2]);
	    String name = tokens[3];
	    Products style = Products.valueOf(tokens[4]);
	    int nbOfWorkers = Integer.parseInt(tokens[5]);

	    float[] prices = null;
	    if (tokens.length > 6) {
	        prices = new float[tokens.length - 6];
	        for (int i = 6; i < tokens.length; i++) {
	            prices[i - 6] = Float.parseFloat(tokens[i]);
	        }
	    }

	    return new ClothesStore(address, owner, area, name, style, nbOfWorkers, prices);
	}

	public static List<ClothesStore> readAllFromCSV(String fileName) {
	    List<ClothesStore> stores = new ArrayList<>();
	    try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
	        String line;
	        while ((line = reader.readLine()) != null) {
	            ClothesStore cs = readFromCSVLine(line);
	            if (cs != null) {
	                stores.add(cs);
	            }
	        }
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	    return stores;
	}
	
	//Writing/Reading form *.txt, all the fields are on the same line
	public void saveToSingleLineText(String fileName) {
	    try (BufferedWriter writer = new BufferedWriter(new FileWriter(fileName, true))) {
	        writer.write(this.getAddress() + " | " + this.getOwner() + " | " + this.getArea() + " | " +
	                     this.getName() + " | " + this.getStyle().name() + " | " + this.getNbOfWorkers());

	        if (this.getPriceOfArticle() != null) {
	            for (float price : this.getPriceOfArticle()) {
	                writer.write(" | " + price);
	            }
	        }
	        writer.newLine();
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	}

	public static ClothesStore readFromSingleLineText(String line) {
	    String[] tokens = line.split(" \\| ");
	    if (tokens.length < 6) return null;

	    String address = tokens[0];
	    String owner = tokens[1];
	    double area = Double.parseDouble(tokens[2]);
	    String name = tokens[3];
	    Products style = Products.valueOf(tokens[4]);
	    int nbOfWorkers = Integer.parseInt(tokens[5]);

	    float[] prices = null;
	    if (tokens.length > 6) {
	        prices = new float[tokens.length - 6];
	        for (int i = 6; i < tokens.length; i++) {
	            prices[i - 6] = Float.parseFloat(tokens[i]);
	        }
	    }

	    return new ClothesStore(address, owner, area, name, style, nbOfWorkers, prices);
	}

	public static List<ClothesStore> readAllFromSingleLineText(String fileName) {
	    List<ClothesStore> stores = new ArrayList<>();
	    try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
	        String line;
	        while ((line = reader.readLine()) != null) {
	            ClothesStore cs = readFromSingleLineText(line);
	            if (cs != null) {
	                stores.add(cs);
	            }
	        }
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	    return stores;
	}

}
