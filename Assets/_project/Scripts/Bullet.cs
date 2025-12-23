using UnityEngine;

public class
    Bullet : MonoBehaviour
{
    [SerializeField] private Utilities.BulletAmmo _bulletAmmo;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeSpan;
    [SerializeField] private float _fireRate;
    private float _deltaTime;

    private Rigidbody2D _rb;
    private LifeController _lifeController;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //Getter
    public Utilities.BulletAmmo GetBulletAmmo() => _bulletAmmo;
    public int GetDamage() => _damage;
    public float GetSpeed() => _speed;
    public float GetLifeSpan() => _lifeSpan;
    public float GetFireRate() => _fireRate;
    public float GetDeltaTime() => _deltaTime;

    //Setter
    public void SetDeltaTime(float deltaTime)
    { _deltaTime = deltaTime; }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Gestione Danno Proiettile Enemy
        if (other.gameObject.CompareTag(Utilities._playerTag) & gameObject.CompareTag(Utilities._bulletEnemyTag))
        {
            _lifeController = other.gameObject.GetComponent<LifeController>();

            if (_lifeController != null)
            {
                _lifeController.TakeDamage(_damage);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        //Gestione Danno Proiettile Player
        else if (other.gameObject.CompareTag(Utilities._enemyTag) & gameObject.CompareTag(Utilities._bulletPlayerTag))
        {
            _lifeController = other.gameObject.GetComponent<LifeController>();

            if (gameObject.name.Contains(Utilities._bulletElettroshock))  // CS0642
            {
                other.gameObject.GetComponent<Enemy>().SetStatusShocked();
            }
            if (_lifeController != null)
            {
                _lifeController.TakeDamage(_damage);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        else if ((other.gameObject.CompareTag(Utilities._bulletPlayerTag) & gameObject.CompareTag(Utilities._bulletEnemyTag)) ||
                 (other.gameObject.CompareTag(Utilities._bulletEnemyTag) & gameObject.CompareTag(Utilities._bulletPlayerTag)))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }


    }

    public void SetMovementBullet(Vector2 direction)
    {
        // il bullet avrà la direzione normalizzata del player con la velocità _speed
        _rb.velocity = direction.normalized * _speed;
    }

}
