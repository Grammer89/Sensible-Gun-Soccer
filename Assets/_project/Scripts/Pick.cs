using UnityEngine;

public class Pick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Utilities._playerTag))
        {
            Bullet bullet = gameObject.GetComponent<Bullet>();
            Gun gun = other.gameObject.GetComponent<Gun>();
            if (gun != null)
            {
                gun.AddListGun(bullet);
            }

            Destroy(gameObject);

        }
    }
}
