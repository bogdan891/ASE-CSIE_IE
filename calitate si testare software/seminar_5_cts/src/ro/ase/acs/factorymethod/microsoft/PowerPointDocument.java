package ro.ase.acs.factorymethod.microsoft;

import ro.ase.acs.factorymethod.contracts.AbstractDocument;

public class PowerPointDocument extends AbstractDocument {
    PowerPointDocument(String title) {
        this.title = title;
    }
    @Override
    public void open() {
        System.out.println("Opening PowerPoint Document...");
    }
}
