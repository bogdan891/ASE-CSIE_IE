package recapitulare_java_4;

import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeSet;
import java.util.stream.Collectors;

public class ProgMain {

	public static void main(String[] args) {
//		Car polo = new Car("Volksvagen", 2015, 240, "Polo", 15000);
//		Car c1 = new Car("Toyota", 2010, 180.5f, "Corolla", 15000.0f);
//		Car c2 = new Car("Honda", 2015, 200.0f, "Civic", 18000.0f);
//		polo.save2File("cars.txt");
//		c1.save2File("cars.txt");
//		c2.save2File("cars.txt");
//		
//		try {
//			Car copy = polo.clone();
//			copy.save2File("cars.txt");
//		} catch (CloneNotSupportedException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
		
		List<Car> cars = new ArrayList<>();
		
		try (DataInputStream dis = new DataInputStream(new BufferedInputStream(new FileInputStream("cars.txt")))) {
			while(dis.available() > 0) {
				 String manufacturer = dis.readUTF();
			     int year = dis.readInt();
			     float maxSpeed = dis.readFloat();
			     String model = dis.readUTF();
			     float price = dis.readFloat();

			     Car car = new Car();
			     car.setManufacturer(manufacturer);
			     car.setYear(year);
			     car.setMaxSpeed(maxSpeed);
			     car.setModel(model);
			     car.setPrice(price);
			     cars.add(car);
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
//		for (Iterator<Car> c = cars.iterator(); c.hasNext();) {
//			Car carTemp = c.next();
//			System.out.println(carTemp.toString());
//		}
		
//		Set<Car> carSet = new TreeSet<>(cars);
//
//		System.out.println("Set-ul de Car:");
//		for (Car car : carSet) {
//		    System.out.println(car);
//		}
		
		// 1. Lambda Expression simplă: Afișare cu forEach
        System.out.println("=== Toate mașinile ===");
        cars.forEach(car -> System.out.println(car)); // Lambda cu un parametru

        // 2. Filtrare cu Streams: Mașini cu preț sub 25000
        List<Car> masiniIeftine = cars.stream()
            .filter(c -> c.getPrice() < 25000) // Lambda expression pentru filtru
            .toList();
        System.out.println("\n=== Mașini sub 25000$ ===");
        masiniIeftine.forEach(System.out::println); // Method reference

        // 3. Sortare cu Streams: După an (crescător) și preț (descrescător)
        List<Car> masiniSortate = cars.stream()
            .sorted((c1, c2) -> { // Comparator cu lambda
                int cmp = Integer.compare(c1.getYear(), c2.getYear());
                return cmp != 0 ? cmp : Float.compare(c2.getPrice(), c1.getPrice());
            })
            .toList();
        System.out.println("\n=== Sortate după an și preț ===");
        masiniSortate.forEach(c -> System.out.println(c));

        // 4. Transformare cu map: Listă de modele
        List<String> modele = cars.stream()
            .map(Car::getModel) // Method reference
            .toList();
        System.out.println("\n=== Modele de mașini ===");
        modele.forEach(model -> System.out.println(model));

        // 5. Colectare în TreeSet (sortare naturală)
        Set<Car> setSortat = cars.stream()
            .collect(Collectors.toCollection(TreeSet::new));
        System.out.println("\n=== TreeSet sortat natural ===");
        setSortat.forEach(System.out::println);

        // 6. Grupare după producător
        Map<String, List<Car>> masiniDupaProducator = cars.stream()
            .collect(Collectors.groupingBy(Car::getManufacturer));
        System.out.println("\n=== Mașini grupate după producător ===");
        masiniDupaProducator.forEach((producator, lista) -> {
            System.out.println(producator + ":");
            lista.forEach(System.out::println);
        });

        // 7. Filtru + Sumă cu reduce
        double sumaPreturiToyota = cars.stream()
            .filter(c -> "Toyota".equals(c.getManufacturer()))
            .mapToDouble(Car::getPrice)
            .sum();
        System.out.printf("\n=== Suma prețuri Toyota: %.2f$ ===", sumaPreturiToyota);
    
	}
}
