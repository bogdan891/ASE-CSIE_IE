package csie.ase.ro.classes;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class TCPClient {

	public static void main(String[] args) {
		try (Socket clientSocket = new Socket("localhost", 8333)) {
			DataInputStream dis = new DataInputStream(clientSocket.getInputStream());
			DataOutputStream dos = new DataOutputStream(clientSocket.getOutputStream());
			
			List<Series> myList = new ArrayList<>();
			myList.add(new Series("Breaking Bad", Category.DRAMA, 2008, 5, new int[]{7, 13, 13, 13, 16}));
			myList.add(new Series("Stranger Things", Category.SF, 2016, 4, new int[]{8, 9, 8, 9}));
			myList.add(new Series("Friends", Category.COMEDY, 1994, 10, new int[]{24, 24, 25, 24, 24, 25, 24, 24, 24, 18}));
			myList.add(new Series("Dark", Category.THRILLER, 2017, 3, new int[]{10, 8, 8}));
			myList.add(new Series("Rick and Morty", Category.ANIMATION, 2013, 6, new int[]{11, 10, 10, 10, 10, 10}));
			myList.add(new Series("The Office", Category.COMEDY, 2005, 9, new int[]{6, 22, 23, 14, 26, 24, 24, 24, 25}));
			
			dos.writeInt(myList.size());
			
			for(Series object : myList) {
				dos.writeUTF(object.getName());
				dos.writeUTF(object.getType().name());
				dos.writeInt(object.getReleaseYear());
				dos.writeInt(object.getNbSeasons());
				for(int x : object.getEpisodesPerSeason()) {
					dos.writeInt(x);
				}
				dos.flush();
			}
			System.out.println("The list has been sent!");
			
			int size = dis.readInt();
			List<Series> receivedList = new ArrayList<Series>();
			for(int i=0; i < size; i++) {
				String name = dis.readUTF();
				String type = dis.readUTF();
				Category value = Category.valueOf(type);
				int releaseYear = dis.readInt();
				int nbSeasons = dis.readInt();
				if(nbSeasons <= 0) {
					throw new IllegalArgumentException("The number of seasons must be positive!");
				}
				int[] episodesPerSeason = new int[nbSeasons];
	            for(int j =0; j < nbSeasons;j++) {
	                episodesPerSeason[j] = dis.readInt();
	            }

	            Series series = new Series(name, value, releaseYear, nbSeasons, episodesPerSeason);
	            receivedList.add(series);
			}
			
			System.out.println("The edited list:");
			receivedList.forEach(System.out::println);
			
			dis.close();
			dos.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
