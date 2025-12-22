using UnityEngine;


public class Utilities : MonoBehaviour
{
    public enum EnemyType
    {
        Goalkeaper = 0,
        Defender = 1,
        Midfielder = 2,
        Forward = 3,
    }

    public enum BulletAmmo
    {
        Bazooka = 0,
        Mitra = 1,
        Elettroshock = 2,
        Cartellini = 3,

        BulletEnemyGoalkeaper = 20,
        BulletEnemyDefender = 21,
        BulletEnemyMidfielder = 22,
        BulletEnemyForward = 23,
    }
    //Tag
    public const string _enemyTag = "Enemy";
    public const string _playerTag = "Player";
    public const string _bulletPlayerTag = "BulletPlayer";
    public const string _bulletEnemyTag = "BulletEnemy";
    public const string _gunTag = "GunTag";

    //Stati Enemies
    public const string _playerFarState = "PlayerFar";
    public const string _playerInRadarState = "PlayerInRadar";
    public const string _playerNearState = "PlayerNear";
    public const string _playerLoseState = "PlayerLose";
    public const string _playerKillOrVictoryState = "PlayerKillOrVictory";
}
