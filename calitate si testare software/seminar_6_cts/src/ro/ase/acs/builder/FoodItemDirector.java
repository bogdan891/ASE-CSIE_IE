package ro.ase.acs.builder;

import java.time.LocalDate;

public class FoodItemDirector {
    private FoodItemBuilder foodItemBuilder;
    public FoodItem create (String name, double price, LocalDate bestBefore) {
        foodItemBuilder = new FoodItemBuilder();
        foodItemBuilder.addName(name).addPrice(price).addBestBefore(bestBefore);
        return foodItemBuilder.build();
    }
}
