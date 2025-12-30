using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private List<Bullet> _listBullet;
    [SerializeField] private List<Bullet> _listGun;
    private void Awake()
    {

        for (int i = 0; i < _listGun.Count; i++)
        {
            _listGun[i].SetDeltaTime(0f);
        }

  
    }
    void Update()
    {
        if (_listGun.Count != 0)
        {
            CanIShoot();
        }

    }

    //Functionality
    public void AddListGun(Bullet bulletGun)
    {
        Bullet bullet = bulletGun;
        bool ammoNotFound = false;
        for (int i = 0; i < _listGun.Count; i++)
        {
            if (_listGun[i].GetBulletAmmo() != bulletGun.GetBulletAmmo())
            {
                ammoNotFound = true;
            }

        }
        if (ammoNotFound)
        {
           Debug.Log( bullet.GetMinDist());
            _listGun.Add(bullet);
        }
    }

    public void CanIShoot()
    {

        for (int i = 0; i < _listGun.Count; i++)
        {

            if (Time.time - _listGun[i].GetDeltaTime() > _listGun[i].GetFireRate())
            {
                for (int j = 0; j < _listGun.Count; j++)
                {
                    if (_listGun[j].GetBulletAmmo() == _listGun[i].GetBulletAmmo())
                    {

                        Shoot(_listBullet[j]);
                        _listGun[i].SetDeltaTime(Time.time);
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
            Debug.Log(bullet.GetBulletAmmo() + " check Shoot : " + checkShoot + "BulletMinDist" + bullet.GetMinDist());
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
