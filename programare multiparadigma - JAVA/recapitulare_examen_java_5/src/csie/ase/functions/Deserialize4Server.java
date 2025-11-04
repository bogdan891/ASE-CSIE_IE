package csie.ase.functions;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.Socket;
import java.util.List;

import csie.ase.ro.classes.*;

public class Deserialize4Server {
	public static MobilePhone deserialize4Server(Socket socket) {
		try(ObjectInputStream in = new ObjectInputStream(socket.getInputStream())){
			Object obj = in.readObject();
			if(obj instanceof MobilePhone) {
				return (MobilePhone) obj;
			} else {
				return null;
			}
		} catch (IOException | ClassNotFoundException e) {
			e.printStackTrace();
			return null;
		}
	}
	
	@SuppressWarnings("unchecked")
	public static List<MobilePhone> deserializeListFromServer(Socket socket) {
		try {
			ObjectInputStream in = new ObjectInputStream(socket.getInputStream());
			Object obj = in.readObject();
			if (obj instanceof List<?>) {
				return (List<MobilePhone>) obj;
			} else {
				return null;
			}
		} catch (IOException | ClassNotFoundException e) {
			e.printStackTrace();
			return null;
		}
	}
}
