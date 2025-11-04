package csie.ase.threadpool;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class UDPPacketHandler implements Runnable {
	private final DatagramPacket packet;
	private final DatagramSocket serverSocket;

	public UDPPacketHandler(DatagramPacket packet, DatagramSocket socket) {
		this.packet = packet;
		this.serverSocket = socket;
	}

	@Override
	public void run() {
		try {
			String receivedText = new String(packet.getData(), 0, packet.getLength());
			System.out.println("Text primit de la client (în " + 
			Thread.currentThread().getName() + "): " + receivedText);

			String response = "Am primit telefonul: " + receivedText;
			byte[] responseData = response.getBytes();

			InetAddress clientAddress = packet.getAddress();
			int clientPort = packet.getPort();

			DatagramPacket responsePacket = new DatagramPacket(responseData, 
					responseData.length, clientAddress, clientPort);
			serverSocket.send(responsePacket);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}