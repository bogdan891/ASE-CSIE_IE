package csie.ase.utils;

import java.io.FileOutputStream;
import java.io.IOException;
import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;

import csie.ase.classes.Airplane;
import csie.ase.classes.AirplaneExpense;

public class FileManager {

    public static void main(String[] args) {

     // Avion 1
        List<AirplaneExpense> expenses1 = Arrays.asList(
            new AirplaneExpense("kerosene", 900),
            new AirplaneExpense("insurance", 200),
            new AirplaneExpense("flightcrew", 3000)
        );
        Airplane a1 = new Airplane(1, "AirSecure", 1200, 800, expenses1, LocalDateTime.of(2025, 6, 9, 10, 0));

        // Avion 2
        List<AirplaneExpense> expenses2 = Arrays.asList(
            new AirplaneExpense("kerosene", 1100),
            new AirplaneExpense("insurance", 250),
            new AirplaneExpense("flightcrew", 3300)
        );
        Airplane a2 = new Airplane(2, "SkySafe", 1500, 950, expenses2, LocalDateTime.of(2025, 6, 10, 11, 30));

        // Avion 3
        List<AirplaneExpense> expenses3 = Arrays.asList(
            new AirplaneExpense("kerosene", 700),
            new AirplaneExpense("insurance", 180),
            new AirplaneExpense("flightcrew", 2500)
        );
        Airplane a3 = new Airplane(3, "BlueWings", 1000, 600, expenses3, LocalDateTime.of(2025, 6, 8, 9, 15));

        // Scriem în fișier
        try (FileOutputStream fos = new FileOutputStream("airplanes1.bin")) {
            IO.serialize(a1, fos);
        } catch (IOException e) {
            e.printStackTrace();
        }
        
        try (FileOutputStream fos = new FileOutputStream("airplanes2.bin")) {
            IO.serialize(a2, fos);
        } catch (IOException e) {
            e.printStackTrace();
        }
        
        try (FileOutputStream fos = new FileOutputStream("airplanes3.bin")) {
            IO.serialize(a3, fos);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
