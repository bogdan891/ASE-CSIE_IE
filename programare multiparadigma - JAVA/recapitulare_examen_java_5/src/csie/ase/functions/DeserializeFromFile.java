package csie.ase.functions;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.List;

import csie.ase.ro.classes.*;

public class DeserializeFromFile {
	public MobilePhone deserializeFromFile(String fileName) {
		try(ObjectInputStream in = new ObjectInputStream(new FileInputStream(fileName))){
			Object obj = in.readObject();
			if(obj instanceof MobilePhone ) {
				return (MobilePhone) obj;
			} else {
				 return null;
			}
		} catch(IOException | ClassNotFoundException e) {
			e.printStackTrace();
			return null;
		}
	}
	
	 @SuppressWarnings("unchecked")
	public List<MobilePhone> deserializeList(String fileName) {
	        try (ObjectInputStream in = new ObjectInputStream(new FileInputStream(fileName))) {
	            Object obj = in.readObject();

	            if (obj instanceof List<?>) {
	                return (List<MobilePhone>) obj;
	            } else {
	                System.out.println("Obiectul din fișier nu este o listă de MobilePhone.");
	                return null;
	            }
	        } catch (IOException | ClassNotFoundException e) {
	            e.printStackTrace();
	            return null;
	        }
	    }
}
