using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private List<Bullet> _listBullet;
    [SerializeField] private List<Bullet> _listGun;
    private List<Bullet> _internalListBullet = new List<Bullet>();
    private List<Bullet> _internalListGun = new List<Bullet>();
    private void Awake()
    {


        foreach (var bullet in _listBullet)
        {
            _internalListBullet.Add(new Bullet(bullet));
        }
        foreach (var bullet in _listGun)
        {
            _internalListGun.Add(new Bullet(bullet));
        }

    }
    void Update()
    {
        if (_internalListGun.Count != 0)
        {
            CanIShoot();
        }

    }

    //Functionality
    public void AddListGun(Bullet gun)
    {

        if (!CheckListGun(gun))
        {
            _internalListGun.Add(gun);
        }

    }

    public bool CheckListGun(Bullet gun)
    {
        bool notFound = false;
        for (int i = 0; i < _internalListGun.Count; i++)
        {
            if (_internalListGun[i].GetBulletAmmo() == gun.GetBulletAmmo())
            {
                notFound = true;
            }
        }
        return notFound;
    }
    public void CanIShoot()
    {

        for (int i = 0; i < _internalListGun.Count; i++)
        {
            if (Time.time - _internalListGun[i].GetDeltaTime() > _internalListGun[i].GetFireRate())
            {
                for (int j = 0; j < _internalListBullet.Count; j++)
                {
                    if (_internalListBullet[j].GetBulletAmmo() == _internalListGun[i].GetBulletAmmo())
                    {

                        Shoot(_listBullet[j]);
                        Debug.Log(gameObject.name + "sta modificando il deltatime");
                        _internalListGun[i].SetDeltaTime(Time.time);
                    }
                }
            }
        }
    }
    public void Shoot(Bullet bullet)
    {
        if (gameObject.CompareTag(Utilities._playerTag))

        { //Bullet Player
            ShootPlayer(bullet);
        }
        else if (gameObject.CompareTag(Utilities._enemyTag))
        {
            //Bullet Enemy
            ShootEnemy(bullet);
        }
    }

    public void ShootPlayer(Bullet bullet)
    {
        bool checkShoot = false;
        PlayerController playercontroller = gameObject.GetComponent<PlayerController>();
        if (playercontroller != null)
        {
            for (int i = 0; i < playercontroller._enemies.Length; i++)
            {

                if (bullet.MinDistOk(playercontroller._enemies[i], gameObject, bullet.GetMinDist()))
                {
                    checkShoot = true;
                    break;
                }
            }

            if (!checkShoot)
            {
                return;
            }
            Vector2 directionPlayer = playercontroller.GetDirection();

            //Istanziamo il bullet
            Bullet bulletPrefab = Instantiate(bullet);
            SpriteRenderer cardRender = bulletPrefab.GetComponent<SpriteRenderer>();

            if (bulletPrefab.GetBulletAmmo() == Utilities.BulletAmmo.Cartellini)
            {
                if (Random.Range(0, 101) > 75f)
                {
                    cardRender.color = Color.red;
                }
                else
                {
                    cardRender.color = Color.yellow;
                }
            }


            //Gestione Posizione Bullet 
            Vector2 startPosition = new Vector2(playercontroller.transform.position.x + Vector2.one.x,
                                                playercontroller.transform.position.y + Vector2.one.y);

            bulletPrefab.transform.position = startPosition;

            bulletPrefab.SetMovementBullet(directionPlayer);
            Destroy(bulletPrefab, bulletPrefab.GetLifeSpan());
        }
    }

    public void ShootEnemy(Bullet bullet)
    {

        Enemy enemy = gameObject.GetComponent<Enemy>();
        GameObject player = enemy.GetPlayer();
        if (enemy != null & player != null)
        {

            if (enemy.DistanceToShootOk())
            {
                //Vettore che va puntare il player=> Vettore Position Player - Vettore Position Bullet
                Vector2 directionPlayer = new Vector2(enemy.GetDirectionPlayer().x - gameObject.transform.position.x,
                                                      enemy.GetDirectionPlayer().y - gameObject.transform.position.y);

                //Istanziamo il bullet
                Bullet bulletPrefab = Instantiate(bullet);

                //Gestione Posizione Bullet
                bulletPrefab.transform.position = gameObject.transform.position;

                bulletPrefab.SetMovementBullet(directionPlayer);
                Destroy(bulletPrefab, bulletPrefab.GetLifeSpan());
            }
        }
    }
}
