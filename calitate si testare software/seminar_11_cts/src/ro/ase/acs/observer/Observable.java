package ro.ase.acs.observer;

import java.util.List;
import java.util.Vector;

public abstract class Observable {
    private List<Observer> observers = new Vector<>();

    public void subscribe(Observer observer) {
        observers.add(observer);
    }

    public void unsubscribe(Observer observer) {
        observers.remove(observer);
    }

    public void notifyObserver(String message) {
        observers.forEach(x -> x.receiverNotification(message));
    }
}
