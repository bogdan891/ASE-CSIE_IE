package ro.ase.acs.observer;

public class YoutubeSubscriber implements  Observer{
    @Override
    public void receiverNotification(String message) {
        System.out.println("\uD83D\uDD14 " + message);
    }
}
