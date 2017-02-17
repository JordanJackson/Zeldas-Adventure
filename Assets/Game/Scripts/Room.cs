using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    [SerializeField]
    public Scene scene;

    public Room north;
    public Room east;
    public Room south;
    public Room west;

    public enum RoomDirection
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    };

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            // check if current room
            Debug.Log("Player exited.");
        }
    }
}
