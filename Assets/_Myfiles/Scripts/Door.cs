using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject openDoorPos;
    [SerializeField] private GameObject closeDoorPos;

    public void OpenDoor() 
    {
        transform.rotation = openDoorPos.transform.rotation;
    }

    public void CloseDoor() 
    {
        transform.rotation = closeDoorPos.transform.rotation;
    }
}
