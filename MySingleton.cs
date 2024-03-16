using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton
{
   public static string currentDirection = "?";
    private static Room[] theRooms = new Room[2];
    private static int numRooms = 0;
    public static Room theCurrentRoom = null;
    //public static Dungeon theDungeon = MySingleton.generateDungeon;

        public static Dungeon generateDungeon()
    {
        Room r1 = new Room("R1");
        Room r2 = new Room("R2");
        Room r3 = new Room("R3");
        Room r4 = new Room("R4");
        Room r5 = new Room("R5");
        Room r6 = new Room("R6");

        r1.addExit("north", r2);
        r1.addExit("north", r2);
        r1.addExit("north", r2);
        r1.addExit("north", r2);
        r1.addExit("north", r2);
        r1.addExit("north", r2);
        r1.addExit("north", r2);
        r1.addExit("north", r2);
        r1.addExit("north", r2);


        Dungeon theDungeon = new Dungeon("the cross");
        theDungeon.setStartRoom(r1);
        //MySingleton.thePlayer = new Player("Mike");
        //theDungeon.addPlayer(MySingleton.thePlayer);
        return theDungeon;

    }

    public static void addRoom(Room r)
    {
        MySingleton.theRooms[numRooms] = r;
        MySingleton.numRooms++;
    }
}
