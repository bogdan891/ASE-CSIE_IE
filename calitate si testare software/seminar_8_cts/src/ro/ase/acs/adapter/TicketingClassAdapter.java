package ro.ase.acs.adapter;

public class TicketingClassAdapter extends BusTicketing implements AbstractTrainTicketing {
    @Override
    public void buyTicket(int coachNumber, int seatNumber) {
        super.reserveSeat();
    }
}
