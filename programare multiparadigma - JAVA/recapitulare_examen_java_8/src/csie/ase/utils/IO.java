package csie.ase.utils;

import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;

import csie.ase.classes.Car;

public class IO {
	public static void serialize(Car x, OutputStream output) {
		try {
			ObjectOutputStream oos = new ObjectOutputStream(output);
			oos.writeObject(x);
			oos.flush();
			oos.close();
		} catch(IOException e) {
			e.printStackTrace();
		}
	}
	
	public static Car deserialize(InputStream input) {
		try {
			ObjectInputStream ois = new ObjectInputStream(input);
			Car x = (Car) ois.readObject();
			return x;
		} catch(IOException | ClassNotFoundException e) {
			e.printStackTrace();
		}
		return new Car();
	}
}
