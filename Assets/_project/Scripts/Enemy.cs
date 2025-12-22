
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] Utilities.EnemyType _enemyType;
    [SerializeField] float _minDistToAtt;
    [SerializeField] float _speed;

    private GameObject _player;
    private AnimatorEnemiesHandler _animParam;
    private LifeController _lifePlayer;
    // Start is called before the first frame update
    private void Awake()
    {

        _player = GameObject.FindGameObjectWithTag(Utilities._playerTag);
        _animParam = GetComponent<AnimatorEnemiesHandler>();
        _lifePlayer = _player.GetComponent<LifeController>();
    }


    // Update is called once per frame
    void Update()
    {
        //Check Se il player è morto => Victory
        if (!_lifePlayer.IsAlive())
        {
            _animParam.SetPlayerLose(true);
            return;
        }

        //Movimento Enemy to Player
        if (DistanceToShootOk())
        {
            float step = _speed * Time.deltaTime;

            //transform.position = Vector2.Lerp(transform.position, _player.transform.position, step);
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, step);

        }

    }

    public bool DistanceToShootOk()
    {
        float distancePlayerEnemy = Vector2.Distance(_player.transform.position, transform.position);

        if ((distancePlayerEnemy <= _minDistToAtt) & (distancePlayerEnemy > 1.5f))
        {
            _animParam.SetPlayerInRadar(true); //Enemy Run
            return true;
        }
        else if ((distancePlayerEnemy <= _minDistToAtt) & (distancePlayerEnemy <= 1.5f))
        {
            _animParam.SetPlayerNear(true); //Enemy Attack
            return true;
        }
        else
        {
            _animParam.SetPlayerFar(true); //Idle Enemy
            return false;
        }
    }

    public Vector2 GetDirectionPlayer()
    {
        PlayerController playerController = _player.GetComponent<PlayerController>();
        return playerController.transform.position;
    }

}
