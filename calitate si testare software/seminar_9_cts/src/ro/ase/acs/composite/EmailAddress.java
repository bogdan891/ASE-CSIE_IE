package ro.ase.acs.composite;

import java.util.Collection;
import java.util.List;

public class EmailAddress implements EmailReceiver{
    private String address;

    public EmailAddress(String address) {
        this.address = address;
    }

    @Override
    public void receive(String message) {
        System.out.println(address + ": " + message);
    }

    @Override
    public void addReceiver(EmailReceiver emailReceiver) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void deleteReceiver(EmailReceiver emailReceiver) {
        throw new UnsupportedOperationException();
    }

    @Override
    public Collection<EmailReceiver> getReceiver() {
        throw  new UnsupportedOperationException();
    }
}
