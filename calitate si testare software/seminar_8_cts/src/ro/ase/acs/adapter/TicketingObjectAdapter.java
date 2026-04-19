package ro.ase.acs.adapter;

public class TicketingObjectAdapter implements AbstractTrainTicketing{
    private final AbstractBusTicketing abstractBusTicketing;

    public TicketingObjectAdapter(AbstractBusTicketing abstractBusTicketing) {
        this.abstractBusTicketing = abstractBusTicketing;
    }

    @Override
    public void buyTicket(int coachNumber, int seatNumber) {
        abstractBusTicketing.reserveSeat();
    }
}
