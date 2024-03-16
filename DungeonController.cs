using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{

    public GameObject [] closedDoors; 
    // Start is called before the first frame update
    private string mapIndexToStringForExit(int index)
    {
        if (index == 0)
        {
            return "north";
        }
        else if (index == 1)
        {
            return "south";
        }
        else if (index == 2)
        {
            return "east";
        }
        else if (index == 3)
        {
            return "west";
        }
        else
        {
            return "?";
        }

    }
    void Start()
    {

       /* if(MySingleton.theDungeon != null)
        {
            MySingleton.generateDungeon;
        }*/

        MySingleton.theCurrentRoom = new Room("a room");
        MySingleton.addRoom(MySingleton.theCurrentRoom);//notusingyet

        int openDoorIndex = Random.Range(0, 4);
        this.closedDoors[Random.Range(0, 4)].SetActive(false);
        MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));

        for(int i = 0; i < 4; i++)
        {
            if (openDoorIndex != i)
            {
                int coinFlip = Random.Range(0, 2);
                if(coinFlip == 1)
                {
                    this.closedDoors[i].SetActive(false);

                }
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
