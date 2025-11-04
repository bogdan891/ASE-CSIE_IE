package csie.ase.UDP;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

import csie.ase.classes.Bus;
import csie.ase.utils.FuelType;
import csie.ase.utils.*;

public class ClientUDP {
	 public static void main(String[] args) {

	        DatagramSocket socket;
	        try {
	            socket = new DatagramSocket();

	            Bus bus = new Bus("Mercedes", "B123XYZ", FuelType.DIESEL, "Citaro", "R1", 101, 3, new float[]{2.1f, 3.4f, 5.0f});

	            String csvData = CSV.toCSV(bus);
	            byte[] buf = csvData.getBytes();

	            InetAddress dstAddr = InetAddress.getByName("localhost");
	            int dstPort = 8333;

	            DatagramPacket packet = new DatagramPacket(buf, buf.length, dstAddr, dstPort);
	            socket.send(packet);

	            byte[] bufResp = new byte[256];

	            DatagramPacket packetRecvFromServer = new DatagramPacket(bufResp, bufResp.length);
	            socket.receive(packetRecvFromServer);

	            String modifiedCSV = new String(packetRecvFromServer.getData(), 0, packetRecvFromServer.getLength());
	            Bus modifiedBus = CSV.fromCSV(modifiedCSV);
	            System.out.println("Bus primit înapoi de la server:\n" + modifiedBus);

	        } catch (IOException e) {
	            e.printStackTrace();
	        }

	    }
}
