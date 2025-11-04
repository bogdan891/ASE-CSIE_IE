package csie.ase.ro.classes;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class SeriesHandler implements Runnable{
	private Socket clientSocket;
	
	public SeriesHandler(Socket clientSocket) {
		super();
		this.clientSocket = clientSocket;
	}

	@Override
	public void run() {
		try(DataInputStream dis = new DataInputStream(clientSocket.getInputStream());
				DataOutputStream dos = new DataOutputStream(clientSocket.getOutputStream())) {
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
			
			System.out.println("The received list:");
			receivedList.forEach(System.out::println);
			
			List<Series> myList = new ArrayList<Series>();
			receivedList.forEach(x -> {
			    if (x.getReleaseYear() >= 2005) {
			        myList.add(x);
			    }
			});
			
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
		
            dos.flush();
		} catch(IOException e) {
			e.printStackTrace();
		}
	}
}
