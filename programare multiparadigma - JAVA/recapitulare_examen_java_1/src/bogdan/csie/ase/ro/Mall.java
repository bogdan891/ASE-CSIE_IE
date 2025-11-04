package bogdan.csie.ase.ro;

import java.util.ArrayList;
import java.util.List;

public class Mall {
	private String name;
	private List<ClothesStore> stores;
	
	
	//Getters & Setters
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public List<ClothesStore> getStores(){
		List<ClothesStore> storesCopy = new ArrayList<>();
		for (ClothesStore store : this.stores) {
			try {
				storesCopy.add(store.clone());
			} catch (CloneNotSupportedException e) {
				e.printStackTrace(); 
			}
		}
		return storesCopy;
	}
	
	public void setStores(List<ClothesStore> stores) {
		this.stores = new ArrayList<>();
		for (ClothesStore store : stores) {
			try {
				this.stores.add(store.clone());
			} catch (CloneNotSupportedException e) {
				e.printStackTrace();
			}
		}
	}
	
	//Constructors
	
	public Mall() {
		this.name= "N/A";
		this.stores = new ArrayList<>();
	}
	
	public Mall(String name, List<ClothesStore> stores) {
		this.name = name;
		this.stores = new ArrayList<>();
		for (ClothesStore store : stores) {
			try {
				this.stores.add(store.clone());
			} catch (CloneNotSupportedException e) {
				e.printStackTrace();
			}
		}
	}
	
	//Methods
	public void addStore(ClothesStore x) {
		this.stores.add(x);
	}
	
	public void removeStore(String name) {
		this.stores.removeIf(x -> x.getName().equals(name));
	}
	
	public ClothesStore getStoreByName(String name) {
		return this.stores.stream()
			.filter(x -> x.getName().equals(name))
			.findFirst()
			.orElse(null);
	}
	
	public float totalRevenue() {
		float total = 0;
		for (ClothesStore store : this.stores) {
			total += store.calculatePrice();
		}
		return total;
	}
	
	public List<ClothesStore> getStoresByType(Products productType){
		return this.stores.stream().filter(x -> x.getStyle() == productType).toList();
	}
}
