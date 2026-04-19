using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openPosition;
    public Vector3 closedPosition;
    public float speed = 2f;

    private bool isOpen = false;

    void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * speed);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}
