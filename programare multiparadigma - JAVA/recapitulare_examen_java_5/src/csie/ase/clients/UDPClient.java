package csie.ase.clients;

import java.io.ByteArrayOutputStream;
import java.io.ObjectOutputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

import csie.ase.ro.classes.MobilePhone;

public class UDPClient {
	public static void main(String[] args) {
		try (DatagramSocket clientSocket = new DatagramSocket()) {

			InetAddress serverAddress = InetAddress.getByName("localhost");
			int port = 9876;

			// Obiectul de trimis
			MobilePhone phone = new MobilePhone("iPhone 15", "Apple", 6999.99);

			// Serializare obiect
			ByteArrayOutputStream baos = new ByteArrayOutputStream();
			ObjectOutputStream oos = new ObjectOutputStream(baos);
			oos.writeObject(phone);
			oos.flush();

			byte[] sendData = baos.toByteArray();
			DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, serverAddress, port);
			clientSocket.send(sendPacket);

			// Răspuns de la server
			byte[] receiveData = new byte[1024];
			DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
			clientSocket.receive(receivePacket);

			String response = new String(receivePacket.getData(), 0, receivePacket.getLength());
			System.out.println("Server response: " + response);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
