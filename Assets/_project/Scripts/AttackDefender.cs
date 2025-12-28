using UnityEngine;

public class AttackDefender : MonoBehaviour
{
    [SerializeField] private int _damage = 2;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Utilities._playerTag))
        {
            LifeController lifePlayer = collision.gameObject.GetComponent<LifeController>();
            if (lifePlayer != null)
            {
                lifePlayer.TakeDamage(_damage);

            }

        }
    }


}

