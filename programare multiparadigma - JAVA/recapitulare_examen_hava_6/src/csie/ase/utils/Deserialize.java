package csie.ase.utils;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.Socket;
import java.util.List;

import csie.ase.classes.*;

public class Deserialize {
	@SuppressWarnings("unchecked")
	public static List<Bus> deserializeFromServer(Socket socket){
		try {
			ObjectInputStream in  = new ObjectInputStream(socket.getInputStream());
			Object obj = in.readObject();
			if (obj instanceof List<?>) {
				return (List<Bus>) obj;
			} else {
				return null;
			}
		} catch (IOException | ClassNotFoundException e) {
			e.printStackTrace();
			return null;
		}
	}
}
