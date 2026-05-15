package ro.ase.acs.flyweight;

import java.util.HashMap;
import java.util.Map;

public class CustomCharacterFactory {
    private Map<Character, CustomCharacter> characters = new HashMap<>();

    public CustomCharacter getCharacter(char ascii) {
        if (characters.containsKey(ascii)) {
            System.out.println("Char << " + ascii + " >> reused!");
            return characters.get(ascii);
        } else {
            CustomCharacter c = new CustomCharacter(new byte[] {100, 101}, ascii);
            characters.put(ascii, c);
            return  characters.get(ascii);
        }
    }
}
