using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public enum Room {
        House,
        Garden,
        Basement,
    }
    
    public Room activeRoom;

    private GameObject house;
    private GameObject garden;
    private GameObject basement;

    // Start is called before the first frame update
    void Start()
    {
        house = GameObject.Find("House");
        garden = GameObject.Find("Garden");
        basement = GameObject.Find("Basement");

        ActivateRoom(Room.House);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("House")) {
            ActivateRoom(Room.House);
        } else if (other.CompareTag("Garden")) {
            ActivateRoom(Room.Garden);
        } else if (other.CompareTag("Basement")) {
            ActivateRoom(Room.Basement);
        }
        Debug.Log("thingy did");
    }

    void ActivateRoom(Room room) {
        // Deactivate all rooms
        house.SetActive(false);
        garden.SetActive(false);
        basement.SetActive(false);

        // Activate the specified room
        if (room == Room.House) {
            house.SetActive(true);
        } else if (room == Room.Garden) {
            garden.SetActive(true);
        } else if (room == Room.Basement) {
            basement.SetActive(true);
        }

        // Update the active room
        activeRoom = room;
    }
}
