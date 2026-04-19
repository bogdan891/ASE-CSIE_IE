package ro.ase.acs;

public class Main {
    public static void main(String[] args) {
        /**
         * Compania decide să deschidă fabrici în două regiuni: China și Germania.
         * Deși ambele produc telefoane, standardele de calitate diferă:
         * fabrica din China folosește ecrane LCD,
         * iar cea din Germania folosește OLED.
         * Se dorește o structură în care procesul de "Lansare Telefon" să fie general,
         * dar decizia concretă privind tipul de ecran și
         * baterie folosit să fie lăsată la latitudinea
         * fiecărei fabrici în parte (subclasele).
         */

        PhoneFactory germany = new GermanyFactory();
        Phone p1  = germany.createPhone();
        p1.show();

        PhoneFactory china = new ChinaFactory();
        Phone p2 = china.createPhone();
        p2.show();
    }
}
