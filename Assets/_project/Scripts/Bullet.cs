using UnityEngine;

public class
    Bullet : MonoBehaviour
{
    [SerializeField] private Utilities.BulletAmmo _bulleAmmo;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeSpan;
    [SerializeField] private float _fireRate;

    private Rigidbody2D _rb;
    private LifeController _lifeController;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //Getter
    public Utilities.BulletAmmo GetBulletAmmo() => _bulleAmmo;
    public int GetDamage() => _damage;
    public float GetSpeed() => _speed;
    public float GetLifeSpan() => _lifeSpan;
    public float GetFireRate() => _fireRate;

     private void OnCollisionEnter2D(Collision2D collision)
    {
        //Gestione Danno Proiettile
        if (collision.gameObject.CompareTag(Utilities._enemyTag) || collision.gameObject.CompareTag(Utilities._playerTag))
        {
            _lifeController = collision.gameObject.GetComponent<LifeController>();

            if (_lifeController != null)
            {
                bool alive = _lifeController.IsAlive();
                if (alive) _lifeController.TakeDamage(_damage);
                //Gestire l'animazione della morte dell'enemy/Player
            }
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        gameObject.SetActive(false);


    }

    public void SetMovementBullet(Vector2 direction )
    {
        // il bullet avrà la direzione normalizzata del player con la velocità _speed
        _rb.velocity = direction.normalized * _speed; 
    }


}
