package ro.ase.acs.memento;

public class VideoEditor {
    private Video video;
    private HistoryManager historyManager;

    public VideoEditor() {
        this.video = new Video("untitled.mp4");
        this.video.setLength(0);
        this.historyManager = new HistoryManager();
    }

    public void edit(int length) {
        this.video.setLength(this.video.getLength() + length);
    }

    public void save() {
        try {
            this.historyManager.commit((Video) this.video.clone());
        } catch (CloneNotSupportedException e) {
            throw new RuntimeException(e);
        }
    }

    public void undo() {
        this.video = this.historyManager.pull();
    }

    @Override
    public String toString() {
        return this.video.getTitle() + ": " + this.video.getLength() + "s";
    }
}