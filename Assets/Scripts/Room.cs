using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> interactables;

    public Transform roomWaypoint;
    public Transform fleeingPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            interactables.Add(collision.gameObject);
        }

        if(collision.tag == "NPC")
        {
            collision.GetComponent<PathFinding>().pathfinding = false;
            collision.GetComponent<NPC_Behavior>().wanderingRadius = collision.GetComponent<NPC_Behavior>().wanderingMaxRadius;
            collision.GetComponent<NPC_Behavior>().fleePoint = fleeingPoint;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "NPC")
        {
            collision.GetComponent<PathFinding>().pathfinding = true;
            collision.GetComponent<NPC_Behavior>().wanderingRadius = collision.GetComponent<NPC_Behavior>().wanderingMinRadius;
        }
    }

    public bool IsInRoom(GameObject interactable)
    {
        return interactables.Contains(interactable);
    }

}
