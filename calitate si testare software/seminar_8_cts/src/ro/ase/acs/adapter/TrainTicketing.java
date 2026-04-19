package ro.ase.acs.adapter;

public class TrainTicketing implements AbstractTrainTicketing {
    private static final int NUMBER_OF_COACHES = 5;
    private static final int NUMBER_OF_SEATS_PER_COACH = 100;

    @Override
    public void buyTicket(int coachNumber, int seatNumber) {
        boolean isCoachNumberValid = coachNumber >= 1 && coachNumber <= NUMBER_OF_COACHES;
        boolean isSeatNumberValid = seatNumber >= 1 && seatNumber <= NUMBER_OF_SEATS_PER_COACH;
        if (isCoachNumberValid && isSeatNumberValid) {
            System.out.println("Ticket issued for coach: " + coachNumber + ", seat: " + seatNumber);
        } else {
            throw new IllegalArgumentException("Invalid seat number");
        }
    }
}
