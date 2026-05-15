package ro.ase.acs.decorator;

public final class Car implements Vehicle{
    private String producer;
    private double price;

    public String getProducer() {
        return producer;
    }

    public void setProducer(String producer) {
        this.producer = producer;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    @Override
    public void start() {
        System.out.println("Car engine ON!");
    }

    @Override
    public void stop() {
        System.out.println("Car engine OFF!");
    }
}
