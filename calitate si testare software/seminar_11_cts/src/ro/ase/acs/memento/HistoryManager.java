package ro.ase.acs.memento;

import java.util.Stack;

public class HistoryManager {
    private Stack<Video> history = new Stack<>();

    public void commit(Video video) {
        history.push(video);
    }

    public Video pull() {
        return history.pop();
    }
}
