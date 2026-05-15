package ro.ase.acs.main;

import ro.ase.acs.composite.EmailAddress;
import ro.ase.acs.composite.EmailGroup;
import ro.ase.acs.composite.EmailReceiver;
import ro.ase.acs.decorator.Car;
import ro.ase.acs.decorator.CarWithAlarm;
import ro.ase.acs.decorator.CarWithSportSeats;
import ro.ase.acs.flyweight.CharacterPosition;
import ro.ase.acs.flyweight.CustomCharacter;
import ro.ase.acs.flyweight.CustomCharacterFactory;

public class Main {
    public static void main(String[] args) {

        //Composite
        System.out.println("===== Composite =====");
        System.out.println();
        EmailReceiver group1087 = new EmailGroup();

        EmailReceiver student1 = new EmailAddress("stud1@stud.ase.ro");
        EmailReceiver student2 = new EmailAddress("stud2@stud.ase.ro");
        group1087.addReceiver(student1);
        group1087.addReceiver(student2);

        EmailReceiver seriesC = new EmailGroup();
        EmailReceiver secretariat = new EmailAddress("secretariat@csie.ase.ro");

        seriesC.addReceiver(secretariat);
        seriesC.addReceiver(group1087);

        seriesC.receive("Bursele aferente lunii aprilie au fost virate in conturi!");

        //Decorator
        System.out.println();
        System.out.println("===== Decorator =====");
        System.out.println();

        Car car = new Car();
        car.setPrice(15000);
        car.setProducer("Toyota");

        CarWithAlarm carWithAlarm = new CarWithAlarm(car);
//        carWithAlarm.start();
//        carWithAlarm.stop();

        CarWithSportSeats carWithSportSeatsAndAlarm = new CarWithSportSeats(carWithAlarm);
        carWithSportSeatsAndAlarm.start();
        carWithSportSeatsAndAlarm.stop();
        carWithSportSeatsAndAlarm.setSeatProducer("Recaro");
        System.out.println(carWithSportSeatsAndAlarm.getSeatProducer());


        //Flyweight
        System.out.println();
        System.out.println("===== Flyweight =====");
        System.out.println();

        CustomCharacterFactory factory = new CustomCharacterFactory();
        CustomCharacter character1 = factory.getCharacter('a');
        character1.display(new CharacterPosition(1,1));

        CustomCharacter character2 = factory.getCharacter('n');
        character2.display(new CharacterPosition(1,2));

        CustomCharacter character3 = factory.getCharacter('a');
        character3.display(new CharacterPosition(1,3));
    }
}