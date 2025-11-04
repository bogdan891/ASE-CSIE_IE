package csie.ase.functions;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.util.List;

import csie.ase.ro.classes.*;

public class Serialize2File {
	public static void serialize(MobilePhone obj, String fileName) {
		try(ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream(fileName))){
			out.writeObject(obj);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public static void serializeList(List<MobilePhone> phones, String fileName) {
	    try (ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream(fileName))) {
	        out.writeObject(phones);
	        System.out.println("Lista a fost serializată cu succes.");
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	}
}
