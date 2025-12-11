using UnityEngine;

public class DragZoneTrigger : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Draggable"))
        {
            Debug.Log("cest good");
            door.SetActive(false);
        }
    }
}