using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> rooms;
    [SerializeField] private GameObject player;

    private int currentRoomIndex = 0;

    private void Start()
    {
        // Initialize the rooms by disabling all rooms except the first one
        for (int i = 1; i < rooms.Count; i++)
        {
            rooms[i].SetActive(false);
        }
    }

    private void Update()
    {
        // Press the "N" key to switch to the next room
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchToNextRoom();
        }
    }

    private void SwitchToNextRoom()
    {
        // Deactivate the current room
        rooms[currentRoomIndex].SetActive(false);

        // Update the current room index
        currentRoomIndex = (currentRoomIndex + 1) % rooms.Count;

        // Activate the next room
        rooms[currentRoomIndex].SetActive(true);

        // Teleport the player to the new room
        player.transform.position = rooms[currentRoomIndex].transform.position + Vector3.up * 2;
    }
}
