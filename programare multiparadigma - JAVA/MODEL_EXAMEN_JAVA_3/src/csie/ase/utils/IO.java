package csie.ase.utils;

import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;

import csie.ase.classes.*;

public class IO {
	public static void serialize(List<AirPlane> x, OutputStream outputStream) {
		try(ObjectOutputStream out = new ObjectOutputStream(outputStream)){
			out.writeObject(x);
			out.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	@SuppressWarnings("unchecked")
	public static List<AirPlane> deserialize(InputStream inputStream){
		List<AirPlane> list = new ArrayList<AirPlane>();
		try(ObjectInputStream in = new ObjectInputStream(inputStream)){
				Object obj = in.readObject();
				if(obj instanceof List) {
					list = (List<AirPlane>) obj;
				}
		} catch (IOException | ClassNotFoundException e) {
			e.printStackTrace();
		}
		return list;
	}
}
