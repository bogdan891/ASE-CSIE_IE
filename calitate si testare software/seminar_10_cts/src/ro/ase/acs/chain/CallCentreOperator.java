package ro.ase.acs.chain;

public class CallCentreOperator extends CallCentreHandler {
    // private ca sa nu il ia nimeni din ext (refactor -> introduce constant)
    private static final int OPERATOR_THRESHOLD = 100;

    @Override
    public void refund(double sum) {
        if (sum <= OPERATOR_THRESHOLD) {
            System.out.println("Refund accepted by operator");
        } else {
            //tot tp trb sa verif daca exista un nextHandler!!
            if (nextHandler != null) {
                nextHandler.refund(sum);
            }
        }
    }
}
