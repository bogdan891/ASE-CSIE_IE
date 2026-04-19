package ro.ase.acs.adapter;

public class BusTicketing implements AbstractBusTicketing{
    private static final int MAXIMUM_NUMBER_OF_SEATS = 50;
    private int numberOfOccupiedSeats = 0;

    @Override
    public void reserveSeat() {
        if (numberOfOccupiedSeats < MAXIMUM_NUMBER_OF_SEATS) {
            System.out.println("Seat Reserved");
            numberOfOccupiedSeats++;
        } else {
            System.out.println("Bus is full!");
        }
    }
}
