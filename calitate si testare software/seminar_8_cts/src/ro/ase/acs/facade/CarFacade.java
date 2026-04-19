package ro.ase.acs.facade;

public class CarFacade {
    private Engine engine = new Engine();
    private BrakingSystem brakingSystem = new BrakingSystem();
    private LightsSystem lightsSystem = new LightsSystem();

    public void start() {
        engine.start();
        brakingSystem.releaseAllBrakes();
        lightsSystem.turnOnLowBeam();
    }

    public void park() {
        engine.stop();
        brakingSystem.applyRearBrakes();
        lightsSystem.turnOffAllLights();
    }

    public void emrgencyBrake() {
        brakingSystem.applyFrontBrakes();
        brakingSystem.applyRearBrakes();
        lightsSystem.turnOnBrakeLights();
        lightsSystem.turnOnHazardLights();
    }
}
