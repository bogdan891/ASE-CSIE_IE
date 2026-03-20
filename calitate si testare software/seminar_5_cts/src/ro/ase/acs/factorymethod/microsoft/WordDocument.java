package ro.ase.acs.factorymethod.microsoft;

import ro.ase.acs.factorymethod.contracts.AbstractDocument;

public class WordDocument extends AbstractDocument {
    WordDocument(String title) {
        this.title = title;
    }

    @Override
    public void open() {
        System.out.println("Opening Word Document...");
    }
}
