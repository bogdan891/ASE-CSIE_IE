package csie.ase.functions;

import csie.ase.ro.classes.MobilePhone;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;

public class Save2File {
    public static void saveMobilePhoneToTextFile(MobilePhone phone, String fileName) {
        try (BufferedWriter bw = new BufferedWriter(new FileWriter(fileName, true))) {
            bw.write(phone.getModel() + "," +
                     phone.getManufacturer() + "," +
                     phone.getPrice() + "," +
                     phone.getBatteryLevel() + "," +
                     phone.isIs5G());
            bw.newLine();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void saveListToTextFile(List<MobilePhone> phones, String fileName) {
        try (BufferedWriter bw = new BufferedWriter(new FileWriter(fileName))) {
            for (MobilePhone phone : phones) {
                bw.write(phone.getModel() + "," +
                         phone.getManufacturer() + "," +
                         phone.getPrice() + "," +
                         phone.getBatteryLevel() + "," +
                         phone.isIs5G());
                bw.newLine();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
