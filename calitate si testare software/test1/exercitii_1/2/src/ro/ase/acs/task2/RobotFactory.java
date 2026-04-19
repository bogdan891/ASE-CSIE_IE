package ro.ase.acs.task2;

public class RobotFactory {
    public Robot createRobot(RobotType type) {
        return switch(type) {
            case DIGGER -> new Digger();
            case FLYER -> new Flyer();
            case TRANSPORTER -> new Transporter();
        };
    }
}
