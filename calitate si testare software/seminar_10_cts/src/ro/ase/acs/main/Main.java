package ro.ase.acs.main;

import ro.ase.acs.chain.CallCentreDirector;
import ro.ase.acs.chain.CallCentreHandler;
import ro.ase.acs.chain.CallCentreManager;
import ro.ase.acs.chain.CallCentreOperator;
import ro.ase.acs.command.BurgerOrder;
import ro.ase.acs.command.Chef;
import ro.ase.acs.command.Waiter;
import ro.ase.acs.strategy.Calculator;
import ro.ase.acs.strategy.Sum;

public class Main {
    public static void main(String[] args) {
        System.out.println("========== CHAIN ==========");
        System.out.println();

        CallCentreHandler operator = new CallCentreOperator();
        CallCentreHandler manager = new CallCentreManager();
        CallCentreHandler director = new CallCentreDirector();

        // stabilim ordinea
        operator.setNextHandler(manager);
        manager.setNextHandler(director);

        // o luam de la inceput
        operator.refund(50); //operatorul o face
        operator.refund(300);

        System.out.println();
        System.out.println("========== COMMAND ==========");
        System.out.println();

        Chef chef = new Chef();
        Waiter waiter = new Waiter();
        waiter.addOrder(new BurgerOrder(chef));
        waiter.sendOrders();

        System.out.println();
        System.out.println("========== Strategy ==========");
        System.out.println();

        Calculator calculator = new Calculator();
        calculator.setOperation(new Sum());
        System.out.println("Sum:");
        double result = calculator.operate(1,2,3,4,5);
        System.out.println(result);

        calculator.setOperation(x -> x.stream().mapToInt(i -> i).average().getAsDouble());
        result = calculator.operate(1, 2, 3, 4, 5);
        System.out.println("Mean with lambda expression:");
        System.out.println(result);
    }
}