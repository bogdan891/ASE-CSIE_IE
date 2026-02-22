package ro.ase.acs.classes;

import ro.ase.acs.interfaces.Taxable;

public class Car extends Vehicle implements Taxable {
    private String producer;
    private int productionYear;
    private EngineType engineType;
    private static final float VAT_VALUE = 0.21F;
    private static final float TAX_VALUE = 0.05F;

    public Car() {
        super();
    }

    public Car(String producer, int productionYear, String color, float price) {
        super(price, color);
        this.producer = producer;
        this.productionYear = productionYear;
    }

    public String getProducer() {
        return producer;
    }

    public void setProducer(String producer) {
        this.producer = producer;
    }

    public int getProductionYear() {
        return productionYear;
    }

    public void setProductionYear(int productionYear) {
        this.productionYear = productionYear;
    }

    public EngineType getEngineType() {
        return engineType;
    }

    public void setEngineType(EngineType engineType) {
        this.engineType = engineType;
    }

    @Override
    public float computeFinalPrice() {
        return (float) ((1 + VAT_VALUE) * this.getPrice());
    }

    @Override
    public float computeTax() {
        return (1 + TAX_VALUE) * this.getPrice();
    }

    @Override
    public boolean isTaxabel() {
        return Taxable.super.isTaxabel();
    }
}
