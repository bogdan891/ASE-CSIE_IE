package ro.ase.acs.task2;

public class TicketFactory {
    public Ticket create(TicketType type) {
        return switch (type) {
            case ELEV -> new Elev();
            case PENSIONAR -> new Pensionar();
            case TURIST -> new Turist();
        };
    }
}
