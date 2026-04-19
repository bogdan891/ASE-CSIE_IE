package ro.ase.acs.main;

import ro.ase.acs.builder.FoodItem;
import ro.ase.acs.builder.FoodItemBuilder;
import ro.ase.acs.prototype.*;

import java.time.LocalDate;

public class Main {
    public static void main(String[] args) {
        BuildingBlock block1 = new WoodBlock();
        block1.setX(5);
        block1.setY(15);
        block1.setZ(25);
        block1.render();

        try {
            BuildingBlock block2 = (BuildingBlock) block1.clone();
            block2.render();
        } catch (CloneNotSupportedException e) {
            throw new RuntimeException(e);
        }

        BuildingBlock block3 = new StoneBlock();
        block3.setX(5);
        block3.setY(15);
        block3.setZ(25);
        block3.render();

        try {
            BuildingBlock block4 = (BuildingBlock) block3.clone();
            block4.render();
        } catch (CloneNotSupportedException e) {
            throw new RuntimeException(e);
        }

        PrototypeCollection collection = new PrototypeCollection();
        BuildingBlock block5 = collection.getBlock(BlockType.STONE);
        block5.setX(5);
        block5.setY(15);
        block5.setZ(25);
        block5.render();

        FoodItem.Builder builder = new FoodItem.Builder();
        FoodItem cola = builder
                .addName("Coca-Cola")
                .addPrice(5.5)
                .addProducer("Coca-Cola Company")
                .addBestBefore(LocalDate.of(2026, 12, 31))
                .addIsVegan(true)
                .addIsGlutenFree(true)
                .build();

        System.out.println(cola);

        FoodItemBuilder foodItemBuilder = new FoodItemBuilder();
        foodItemBuilder.addName("Coca-Cola")
                .addPrice(5.5)
                .addProducer("Coca-Cola Company")
                .addBestBefore(LocalDate.of(2026, 12, 31))
                .addIsVegan(true)
                .addIsGlutenFree(true);
        FoodItem cola2 = foodItemBuilder.build();
        System.out.println(cola2);
    }
}