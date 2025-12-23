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

    public enum StatusElettroshock
    {
        None = 0,
        Shocked = 1,
    }
    public enum BulletAmmo
    {
        Laser = 0,
        Mitra = 1,
        Elettroshock = 2,
        Cartellini = 3,

        BulletEnemyGoalkeaper = 20,
        BulletEnemyDefender = 21,
        BulletEnemyMidfielder = 22,
        BulletEnemyForward = 23,
    }
    //BulletName
    public const string _bulletElettroshock = "BulletElettroShock";

    //Tag
    public const string _enemyTag = "Enemy";
    public const string _playerTag = "Player";
    public const string _bulletPlayerTag = "BulletPlayer";
    public const string _bulletEnemyTag = "BulletEnemy";
    public const string _gunTag = "GunTag";
    public const string _soccerBallTag = "SoccerBall";

    //Stati Enemies
    public const string _playerFarState = "PlayerFar";
    public const string _playerInRadarState = "PlayerInRadar";
    public const string _playerNearState = "PlayerNear";
    public const string _playerLoseState = "PlayerLose";
    public const string _playerKillOrVictoryState = "PlayerKillOrVictory";

    //Stati Player
    public const string _playerXspeed = "xSpeed";
    public const string _playerYspeed = "ySpeed";
    public const string _playerIsDeath = "isDeath";

    //Stati Tifoseria Home
    public const string _playerLose = "playerLose";

    //Stati Tifoseria Away
    public const string _playerWinState = "playerWin";
    public const string _playerKillState = "playerKill";
}
