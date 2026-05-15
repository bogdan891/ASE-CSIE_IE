package ro.ase.acs.flyweight;

public class CustomCharacter implements TextCharacter {
    private byte[] image;
    private char asciiCode;

    public CustomCharacter(byte[] image, char asciiCode) {
        this.image = image;
        this.asciiCode = asciiCode;
    }

    @Override
    public void display(CharacterPosition position) {
        System.out.println(asciiCode + " " + position.getLine() + " " + position.getColumn());
    }
}
