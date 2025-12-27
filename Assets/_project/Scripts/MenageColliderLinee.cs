using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenageColliderLinee : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Utilities._bulletPlayerTag) ||
            collision.gameObject.CompareTag(Utilities._bulletEnemyTag))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Utilities._bulletPlayerTag) ||
           other.gameObject.CompareTag(Utilities._bulletEnemyTag))
        {
            Destroy(other.gameObject);
        }
    }
}
