package csie.ase.servers;

import java.io.ByteArrayInputStream;
import java.io.ObjectInputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

import csie.ase.ro.classes.MobilePhone;

public class UDPServer {
	public static void main(String[] args) {
		try (DatagramSocket serverSocket = new DatagramSocket(9876)) {
			System.out.println("UDP Server is running on port 9876...");

			byte[] receiveData = new byte[1024];

			while (true) {
				DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
				serverSocket.receive(receivePacket);

				// Deserialize object
				ByteArrayInputStream bais = new ByteArrayInputStream(receivePacket.getData());
				ObjectInputStream ois = new ObjectInputStream(bais);
				MobilePhone phone = (MobilePhone) ois.readObject();

				System.out.println("Received: " + phone);

				// Send back confirmation
				String response = "Received phone: " + phone.getModel();
				byte[] sendData = response.getBytes();
				DatagramPacket sendPacket = new DatagramPacket(
						sendData,
						sendData.length,
						receivePacket.getAddress(),
						receivePacket.getPort()
				);
				serverSocket.send(sendPacket);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
