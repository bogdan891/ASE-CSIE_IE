package ro.ase.acs.builder;

import java.time.LocalDate;

public class FoodItem {
    private String name;
    private double price;
    private double discount;
    private String producer;
    private LocalDate bestBefore;
    private boolean isGlutenFree;
    private boolean isVegan;

    private FoodItem() {
    }

    FoodItem(String name, double price, double discount, String producer, LocalDate bestBefore,
             boolean isGlutenFree, boolean isVegan) {
        this.name = name;
        this.price = price;
        this.discount = discount;
        this.producer = producer;
        this.bestBefore = bestBefore;
        this.isGlutenFree = isGlutenFree;
        this.isVegan = isVegan;
    }

    public String getName() {
        return name;
    }

    public double getPrice() {
        return price;
    }

    public double getDiscount() {
        return discount;
    }

    public String getProducer() {
        return producer;
    }

    public LocalDate getBestBefore() {
        return bestBefore;
    }

    public boolean isGlutenFree() {
        return isGlutenFree;
    }

    public boolean isVegan() {
        return isVegan;
    }

    @Override
    public String toString() {
        return "FoodItem [name=" + name + ", price=" + price + ", discount=" + discount +
                ", producer=" + producer + ", bestBefore=" + bestBefore +
                ", isGlutenFree=" + isGlutenFree + ", isVegan=" + isVegan + "]";
    }

    public static class Builder {
        private FoodItem foodItem = new FoodItem();
        public Builder addName(String name) {
            foodItem.name = name;
            return this;
        }

        public Builder addPrice(Double price) {
            foodItem.price = price;
            return this;
        }

        public Builder addDiscount(Double discount) {
            foodItem.discount = discount;
            return this;
        }

        public Builder addProducer(String producer) {
            foodItem.producer = producer;
            return this;
        }

        public Builder addBestBefore(LocalDate bestBefore) {
            foodItem.bestBefore = bestBefore;
            return this;
        }

        public Builder addIsGlutenFree(Boolean isGlutenFree) {
            foodItem.isGlutenFree = isGlutenFree;
            return this;
        }

        public Builder addIsVegan(Boolean isVegan) {
            foodItem.isVegan = isVegan;
            return this;
        }

        public FoodItem build() {
            FoodItem copy = foodItem;
            foodItem = new FoodItem();
            return copy;
        }
    }
}
