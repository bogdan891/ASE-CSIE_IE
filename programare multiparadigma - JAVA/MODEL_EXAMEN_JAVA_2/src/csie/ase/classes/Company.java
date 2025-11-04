package csie.ase.classes;

import java.util.ArrayList;
import java.util.List;

public class Company {
	String name;
 	List<Car> cars;
 	
 	 public Company(String name) {
         this.name = name;
         this.cars = new ArrayList<>();
     }

     public void addCar(Car car) {
         cars.add(car);
     }

     public List<Car> getCars() {
         return cars;
     }

     public double getTotalCompanyExpenses() {
         return cars.stream().mapToDouble(Car::getTotalExpenses).sum();
     }

     @Override
     public String toString() {
         return name + " - Total fleet expenses: " + getTotalCompanyExpenses() + " RON";
     }
}
