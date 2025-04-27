using UnityEngine;

public class RoomChanger : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraChanger cameraChanger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x != transform.position.x)
            {
                if (collision.transform.position.x < transform.position.x)
                {
                    cameraChanger.ChangeCameraPosition(nextRoom);
                }
                else
                {
                    cameraChanger.ChangeCameraPosition(previousRoom);
                }
            }
            else
            {
                if (collision.transform.position.y < transform.position.y)
                {
                    cameraChanger.ChangeCameraPosition(nextRoom);
                }
                else
                {
                    cameraChanger.ChangeCameraPosition(previousRoom);
                }
            }
        }
    }
}