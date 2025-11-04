package csie.ase.ro.classes;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Series implements Cloneable, Comparable<Series> {
	private String name;
	private Category type;
	private int releaseYear;
	private int nbSeasons;
	private int[] episodesPerSeason;
	
	//Getters & Setters
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public Category getType() {
		return type;
	}
	
	public void setType(Category type) {
		this.type = type;
	}
	
	public int getReleaseYear() {
		return releaseYear;
	}
	
	public void setReleaseYear(int releaseYear) {
		if(releaseYear > 1900) {
			this.releaseYear = releaseYear;
		} else {
			throw new IllegalArgumentException("The release year must be after 1900!");
		}
	}
	
	public int getNbSeasons() {
		return nbSeasons;
	}
	
	public void setNbSeasons(int nbSeasons) {
		if(nbSeasons > 0) {
			this.nbSeasons = nbSeasons;
		} else {
			throw new IllegalArgumentException("The number of seasons must be positive!");
		}
	}
	
	public int[] getEpisodesPerSeason() {
		return episodesPerSeason;
	}
	
	public void setEpisodesPerSeason(int[] durationOfEpisode) {
		if(durationOfEpisode != null) {
			this.episodesPerSeason = Arrays.copyOf(durationOfEpisode, nbSeasons);
		} else {
			this.episodesPerSeason = null;
		}
	}
	
	//Constructors
	public Series() {
		this.name = "Unknown";
		this.type = Category.UNKNOWN;
		this.releaseYear = 2000;
		this.nbSeasons = 0;
		this.episodesPerSeason = null;
	}

	public Series(String name, Category type, int releaseYear, int nbSeasons, int[] episodesPerSeason) {
		super();
		this.name = name;
		this.type = type;
		this.releaseYear = releaseYear;
		this.nbSeasons = nbSeasons;
		if(episodesPerSeason != null) {
			this.episodesPerSeason = Arrays.copyOf(episodesPerSeason, nbSeasons);
		} else {
			this.episodesPerSeason = null;
		}
	}
	
	//Clone
	@Override
	protected Series clone() throws CloneNotSupportedException {
		super.clone();
		return new Series(this.name, this.type, this.releaseYear, this.nbSeasons, this.episodesPerSeason);
	}

	//HashCode
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((name == null) ? 0 : name.hashCode());
		result = prime * result + ((type == null) ? 0 : type.hashCode());
		result = prime * result + releaseYear;
		result = prime * result + nbSeasons;
		result = prime * result + Arrays.hashCode(episodesPerSeason);
		return result;
	}

	//Equals
	@Override
	public boolean equals(Object obj) {
		super.equals(obj);
		if(this == obj) return false;
		if(obj == null || getClass() != obj.getClass()) return false;
		Series s = (Series) obj;
		return this.name.equals(s.name) && this.type.name().equals(s.type.name()) && Integer.compare(this.releaseYear, s.releaseYear) == 0
				&& Integer.compare(this.nbSeasons, s.nbSeasons) == 0 && Arrays.equals(this.episodesPerSeason, s.episodesPerSeason);
	}

	//To String
	@Override
	public String toString() {
		return this.getType().name() + " - " + this.getName() + " - " + this.getReleaseYear();
	}
	
	//Compare to
	@Override
	public int compareTo(Series other) {
		if (other == null) {
			throw new NullPointerException("Cannot compare to null");
		}
		return Integer.compare(this.releaseYear, other.releaseYear);
	}
	
	//Scrierea in fisier txt sau csv
	public void saveSeries2File(String fileName) {
		try(BufferedWriter bw = new BufferedWriter(new FileWriter(fileName, true))){
			StringBuilder sb = new StringBuilder();
			sb.append(this.name).append(",");
			sb.append(this.type.name()).append(",");
			sb.append(this.releaseYear).append(",");
			sb.append(this.nbSeasons).append(",");
			if (episodesPerSeason != null) {
				for (int i = 0; i < episodesPerSeason.length; i++) {
					sb.append(episodesPerSeason[i]);
					if (i < episodesPerSeason.length - 1) sb.append("-");
				}
			}
			bw.write(sb.toString());
			bw.newLine();

		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	//Citirea din fiser txt sau csv
	
	//Converitrea unei lini la un obiect
	public static Series fromLine(String line) {
		if (line == null || line.isEmpty()) return null;

		String[] parts = line.split(",");
		if (parts.length < 5) return null;

		String name = parts[0];
		Category type = Category.valueOf(parts[1]);
		int releaseYear = Integer.parseInt(parts[2]);
		int nbSeasons = Integer.parseInt(parts[3]);

		String[] epParts = parts[4].split("-");
		int[] episodesPerSeason = new int[epParts.length];
		for (int i = 0; i < epParts.length; i++) {
			episodesPerSeason[i] = Integer.parseInt(epParts[i]);
		}

		return new Series(name, type, releaseYear, nbSeasons, episodesPerSeason);
	}
	
	//Citirea unui singur obiect
	public static Series readFirstSeriesFromFile(String fileName) {
		try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
			String line = br.readLine();  
			if (line != null) {
				return fromLine(line); 
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		return null; 
	}
	
	//Citirea unei liste
	public static List<Series> readSeriesFromFile(String fileName) {
		List<Series> list = new ArrayList<>();
		try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
			String line;
			while ((line = br.readLine()) != null) {
				Series s = null;
				try {
					s = fromLine(line);
				} catch (Exception e) {
					e.printStackTrace();
				}
				if (s != null) list.add(s);
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		return list;
	}
}
