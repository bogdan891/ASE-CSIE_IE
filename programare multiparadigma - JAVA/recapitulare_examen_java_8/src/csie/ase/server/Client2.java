package csie.ase.server;

import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.nio.file.Files;
import java.nio.file.Path;

public class Client2 {
	public static void main(String[] args) {
		final int port = 9890;
		final String path = "cars2.bin";
		try(Socket socket = new Socket("localhost", port)){
			byte[] buffer = Files.readAllBytes(Path.of(path));
			DataOutputStream dos = new DataOutputStream(socket.getOutputStream());
			dos.writeInt(buffer.length);
			dos.write(buffer);
			dos.flush();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
