package recapitulare_java_4;

import java.io.*;
import java.util.Objects;

public class Vehicle implements Cloneable, Moveable, Serializable, Comparable<Vehicle> {
    private static final long serialVersionUID = 1L;
    private String manufacturer;
    private int year;
    private float maxSpeed;

    public Vehicle() {
        this.manufacturer = "Unknown";
        this.year = 2000;
        this.maxSpeed = 0.2f;
    }

    public Vehicle(String manufacturer, int year, float maxSpeed) {
        this.manufacturer = manufacturer;
        this.year = year;
        this.maxSpeed = maxSpeed;
    }

    public String getManufacturer() {
        return manufacturer;
    }

    public void setManufacturer(String manufacturer) {
        this.manufacturer = manufacturer;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        if (year > 0) {
            this.year = year;
        } else {
            throw new IllegalArgumentException("The year cannot be negative!");
        }
    }

    public float getMaxSpeed() {
        return maxSpeed;
    }

    public void setMaxSpeed(float maxSpeed) {
        if (maxSpeed > 0) {
            this.maxSpeed = maxSpeed;
        } else {
            throw new IllegalArgumentException("Max speed must be positive!");
        }
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        Vehicle vehicle = (Vehicle) obj;
        return year == vehicle.year &&
               Float.compare(vehicle.maxSpeed, maxSpeed) == 0 &&
               Objects.equals(manufacturer, vehicle.manufacturer);
    }

    @Override
    public int hashCode() {
        return Objects.hash(manufacturer, year, maxSpeed);
    }

    @Override
    protected Vehicle clone() throws CloneNotSupportedException {
        return (Vehicle) super.clone();
    }

    @Override
    public String toString() {
        return "Vehicle [manufacturer=" + manufacturer +
               ", year=" + year +
               ", maxSpeed=" + maxSpeed + " km/h]";
    }

    @Override
    public void start() {
        System.out.println("Power On! The vehicle is moving!");
    }

    @Override
    public void stop() {
        System.out.println("Power Off! The vehicle is stopped!");
    }

    public void save2File(String fileName) {
        try (DataOutputStream dos = new DataOutputStream(
             new BufferedOutputStream(
             new FileOutputStream(fileName, true)))) {
            dos.writeUTF(manufacturer);
            dos.writeInt(year);
            dos.writeFloat(maxSpeed);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static Vehicle readFromFile(String fileName) throws IOException {
        try (DataInputStream dis = new DataInputStream(
             new BufferedInputStream(
             new FileInputStream(fileName)))) {
            return new Vehicle(
                dis.readUTF(),
                dis.readInt(),
                dis.readFloat()
            );
        }
    }

    @Override
    public int compareTo(Vehicle other) {
        int cmp = manufacturer.compareTo(other.manufacturer);
        if (cmp != 0) return cmp;
        return Integer.compare(year, other.year);
    }
}
