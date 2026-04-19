package ro.ase.acs.prototype;

public class WoodBlock extends BuildingBlock implements Cloneable{
    private byte[] texture;

    public WoodBlock() {
        System.out.println("Loading...");
        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        texture = new byte[]{2, 3, 4};
    }

    @Override
    public void render() {
        System.out.println("Rendering wood block at " + x + "/" + y + "/" + z);
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        WoodBlock copy = (WoodBlock) super.clone();
        copy.texture = this.texture.clone();
        return copy;
    }
}
