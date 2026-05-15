package ro.ase.acs.decorator;

public class CarWithSportSeats extends AbstractCarDecorator{
    private String seatProducer;

    public String getSeatProducer() {
        return seatProducer;
    }

    public void setSeatProducer(String seatProducer) {
        this.seatProducer = seatProducer;
    }

    public CarWithSportSeats(Vehicle vehicle) {
        super(vehicle);
    }
}
