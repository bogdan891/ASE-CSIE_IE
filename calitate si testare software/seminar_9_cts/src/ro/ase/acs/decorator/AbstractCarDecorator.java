package ro.ase.acs.decorator;

public abstract class AbstractCarDecorator implements Vehicle{
    protected Vehicle vehicle;

    public AbstractCarDecorator(Vehicle vehicle) {
        this.vehicle = vehicle;
    }

    @Override
    public void start() {
        vehicle.start();
    }

    @Override
    public void stop() {
        vehicle.stop();
    }
}
