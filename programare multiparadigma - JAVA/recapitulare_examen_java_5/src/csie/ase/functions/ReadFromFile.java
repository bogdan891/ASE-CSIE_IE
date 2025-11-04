package csie.ase.functions;

import csie.ase.ro.classes.MobilePhone;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class ReadFromFile {
	
	 private static MobilePhone parseLineToMobilePhone(String line) {
	        String[] parts = line.split(",");
	        if (parts.length == 5) {
	            String model = parts[0];
	            String manufacturer = parts[1];
	            double price = Double.parseDouble(parts[2]);
	            int batteryLevel = Integer.parseInt(parts[3]);
	            boolean is5G = Boolean.parseBoolean(parts[4]);

	            return new MobilePhone(model, manufacturer, price, batteryLevel, is5G);
	        }
	        return null;
	    }

    
    public static MobilePhone readMobilePhoneFromTextFile(String fileName) {
        try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
            String line = br.readLine();
            if (line != null) {
                return parseLineToMobilePhone(line);
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static List<MobilePhone> readMobilePhoneListFromTextFile(String fileName) {
        List<MobilePhone> phones = new ArrayList<>();
        try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = br.readLine()) != null) {
                MobilePhone phone = parseLineToMobilePhone(line);
                if (phone != null) {
                    phones.add(phone);
                }
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
        return phones;
    }
}
