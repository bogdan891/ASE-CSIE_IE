package ro.ase.acs.prototype;

import java.util.HashMap;
import java.util.Map;

public class PrototypeCollection {
    private Map<BlockType, BuildingBlock> collection = new HashMap<>();

    public PrototypeCollection() {
        collection.put(BlockType.WOOD, new WoodBlock());
        collection.put(BlockType.STONE, new StoneBlock());
    }

    public BuildingBlock getBlock(BlockType type) {
        try {
            return (BuildingBlock) collection.get(type).clone();
        } catch (Exception e) {
            e.printStackTrace();
        }
        throw new IllegalArgumentException("Block " + type + " not found!");
    }
}
