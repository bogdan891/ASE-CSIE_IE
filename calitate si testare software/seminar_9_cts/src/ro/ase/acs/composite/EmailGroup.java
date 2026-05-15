package ro.ase.acs.composite;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class EmailGroup implements EmailReceiver{
    private List<EmailReceiver> receivers = new ArrayList<>();

    @Override
    public void receive(String message) {
        for (EmailReceiver e : receivers) {
            e.receive(message);
        }
    }

    @Override
    public void addReceiver(EmailReceiver emailReceiver) {
        receivers.add(emailReceiver);
    }

    @Override
    public void deleteReceiver(EmailReceiver emailReceiver) {
        receivers.remove(emailReceiver);
    }

    @Override
    public Collection<EmailReceiver> getReceiver() {
        return List.copyOf(receivers);
    }
}
