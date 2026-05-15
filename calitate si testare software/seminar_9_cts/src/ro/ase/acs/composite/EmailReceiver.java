package ro.ase.acs.composite;

import java.util.Collection;

public interface EmailReceiver {
    void receive(String message);
    void addReceiver(EmailReceiver emailReceiver);
    void deleteReceiver(EmailReceiver emailReceiver);
    Collection<EmailReceiver> getReceiver();
}
