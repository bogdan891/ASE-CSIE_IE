package ro.ase.acs.memento;

import java.io.Serializable;

public class Video implements Cloneable {
    private String title;
    private int length;

    public Video(String title) {
        this.title = title;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public int getLength() {
        return length;
    }

    public void setLength(int length) {
        this.length = length;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Video copy = (Video) super.clone();
        copy.title = this.title;
        copy.length = this.length;
        return copy;
    }
}
