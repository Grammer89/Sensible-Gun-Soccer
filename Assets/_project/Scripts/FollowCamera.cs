using UnityEngine;


public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Vector3 newPosition;

    private void LateUpdate()
    {
        if (Player != null)
        {
            newPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
            transform.position = newPosition;
        }

    }
}
