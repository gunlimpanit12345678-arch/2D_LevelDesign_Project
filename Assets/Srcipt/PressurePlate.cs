using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public DoorController door;
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger 2D!");

        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            door.OpenDoor();
            Destroy(gameObject);
        }
    }
}
