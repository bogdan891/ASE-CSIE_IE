package ro.ase.acs.factorymethod.contracts;

public abstract class AbstractDocument  implements Document {
    protected String title;
    @Override
    public String getTitle() {
        return this.title;
    }

    @Override
    public void setTitle(String title) {
        this.title = title;
    }
}
