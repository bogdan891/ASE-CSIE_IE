package ro.ase.acs.main;

import ro.ase.acs.memento.VideoEditor;
import ro.ase.acs.observer.YouTubeChannel;
import ro.ase.acs.observer.YoutubeSubscriber;
import ro.ase.acs.state.VendingMachine;
import ro.ase.acs.template.PartMover;
import ro.ase.acs.template.RoboticArm;

public class Main {
    public static void main(String[] args) {
        System.out.println();
        System.out.println("========== OBSERVER ==========");
        System.out.println();

        YouTubeChannel youTubeChannel = new YouTubeChannel("Recorder");
        YoutubeSubscriber subscriber1 = new YoutubeSubscriber();
        YoutubeSubscriber subscriber2 = new YoutubeSubscriber();

        youTubeChannel.subscribe(subscriber1);
        youTubeChannel.subscribe(subscriber2);

        youTubeChannel.uploadVideo("Investigatie jurnalistica 1");

        youTubeChannel.unsubscribe(subscriber1);

        youTubeChannel.uploadVideo("Investigatie jurnalistica 2");

        /*
        (!) DE AICI IN COLO NU MAI ESTE MATERIE CARE INTRA LA TESTUL 2 (!)
        */

        System.out.println();
        System.out.println("========== STATE ==========");
        System.out.println();

        VendingMachine vendingMachine = new VendingMachine();
        vendingMachine.inputMoney(7);
        vendingMachine.buyProduct(5);

        System.out.println();
        System.out.println("========== MEMENTO ==========");
        System.out.println();

        VideoEditor videoEditor = new VideoEditor();
        videoEditor.edit(65);
        videoEditor.save();
        System.out.println(videoEditor);
        videoEditor.edit(5);
        System.out.println(videoEditor);
        videoEditor.undo();
        System.out.println(videoEditor);

        System.out.println();
        System.out.println("========== TEMPLATE METHOD ==========");
        System.out.println();

        PartMover partMover = new RoboticArm();
        partMover.transport();
    }
}