using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private bool amMoving = false;

    public GameObject amAtMiddleOfRoom;

    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);
    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);
    }



    // Start is called before the first frame update
    void Start()
    {
        this.turnOffExits();

        if (!MySingleton.currentDirection.Equals("?"))
        {
            if (MySingleton.currentDirection.Equals("North"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                //MySingleton.addRoom(MySingleton.addRoom(4));




            }
            else if (MySingleton.currentDirection.Equals("South"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                //MySingleton.addRoom(MySingleton.addRoom(4));

            }
            else if (MySingleton.currentDirection.Equals("East"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                //MySingleton.addRoom(MySingleton.addRoom(4));

            }
            else if (MySingleton.currentDirection.Equals("West"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                //MySingleton.addRoom(MySingleton.addRoom(4));

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("Room1");

        }
        else if (other.CompareTag("MiddleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            print("at middle of the room");
            this.amMoving = false;
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.amAtMiddleOfRoom.transform.position, 0.0f * Time.deltaTime);
        }



    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);
        }

        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }
        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }

    }
}