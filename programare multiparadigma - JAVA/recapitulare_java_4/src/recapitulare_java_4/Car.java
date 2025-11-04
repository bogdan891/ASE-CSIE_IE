package recapitulare_java_4;

import java.io.*;
import java.util.Objects;

public class Car extends Vehicle implements Cloneable, Moveable, Serializable {
    private static final long serialVersionUID = 1L;

    private String model;
    private float price;

    public Car() {
        super();
        this.model = "Unknown";
        this.price = 0.2f;
    }

    public Car(String manufacturer, int year, float maxSpeed, String model, float price) {
        super(manufacturer, year, maxSpeed);
        this.model = model;
        this.price = price;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public float getPrice() {
        return price;
    }

    public void setPrice(float price) {
        if (price > 0) {
            this.price = price;
        } else {
            throw new IllegalArgumentException("The price cannot be negative!");
        }
    }

    @Override
    public Car clone() throws CloneNotSupportedException {
        Car cloned = (Car) super.clone();
        cloned.model = this.model;
        cloned.price = this.price;
        return cloned;
    }

    @Override
    public String toString() {
        return super.toString() + " The model is " + this.model + " and the starting price is " + this.price + "$.";
    }

    @Override
    public void start() {
        System.out.println("Power On! The car is moving!");
    }

    @Override
    public void stop() {
        System.out.println("Power Off! The car is stopped!");
    }

    @Override
    public void save2File(String fileName) {
        try (DataOutputStream dos = new DataOutputStream(
                new BufferedOutputStream(new FileOutputStream(fileName, true)))) {
            dos.writeUTF(getManufacturer());
            dos.writeInt(getYear());
            dos.writeFloat(getMaxSpeed());
            dos.writeUTF(model);
            dos.writeFloat(price);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static Car readFromFile(DataInputStream dis) throws IOException {
        Car c = new Car();
        c.setManufacturer(dis.readUTF());
        c.setYear(dis.readInt());
        c.setMaxSpeed(dis.readFloat());
        c.setModel(dis.readUTF());
        c.setPrice(dis.readFloat());
        return c;
    }

    // Metodă statică pentru citirea tuturor obiectelor Car dintr-un fișier
    public static java.util.List<Car> readAllFromFile(String fileName) {
        java.util.List<Car> cars = new java.util.ArrayList<>();
        try (DataInputStream dis = new DataInputStream(
                new BufferedInputStream(new FileInputStream(fileName)))) {
            while (dis.available() > 0) {
                Car c = readFromFile(dis);
                cars.add(c);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return cars;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (!(obj instanceof Car)) return false;
        if (!super.equals(obj)) return false;
        Car car = (Car) obj;
        return Float.compare(car.price, price) == 0 &&
                Objects.equals(model, car.model);
    }

    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), model, price);
    }

    public int compareTo(Car other) {
        int cmp = getManufacturer().compareTo(other.getManufacturer());
        if (cmp != 0) return cmp;
        cmp = Integer.compare(getYear(), other.getYear());
        if (cmp != 0) return cmp;
        cmp = model.compareTo(other.model);
        if (cmp != 0) return cmp;
        return Float.compare(price, other.price);
    }
}
