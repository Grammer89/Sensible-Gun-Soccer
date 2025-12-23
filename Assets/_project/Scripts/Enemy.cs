using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Utilities.EnemyType _enemyType;
    [SerializeField] private Utilities.StatusElettroshock _statusElettroshock;
    [SerializeField] float _minDistToAtt;
    [SerializeField] float _speed;

    static GameObject _player;
    private AnimatorEnemiesHandler _animParam;
    private LifeController _lifePlayer;
    private LifeController _lifeEnemy;

    float _timeToChangeStatus;
    // Start is called before the first frame update
    private void Awake()
    {
        _animParam = GetComponent<AnimatorEnemiesHandler>();
        _lifeEnemy = GetComponent<LifeController>();

        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag(Utilities._playerTag);
        }
        _lifePlayer = _player.GetComponent<LifeController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!_lifeEnemy.IsAlive() || (_player.GetComponent<PlayerController>()._goal))
        {
            _animParam.SetPlayerKillOrVictory(true);
            GetComponent<Gun>().enabled = false;

            _player.GetComponent<PlayerController>()._kill = true;

            return;
        }

        //Check Se il player è morto => Victory
        if (!_lifePlayer.IsAlive())
        {
            _animParam.SetPlayerLose(true);
            GetComponent<Gun>().enabled = false;
            return;
        }

        if (_statusElettroshock == Utilities.StatusElettroshock.None)
        {
            //Movimento Enemy to Player
            if (DistanceToShootOk())
            {
                float step = _speed * Time.deltaTime;

                //transform.position = Vector2.Lerp(transform.position, _player.transform.position, step);
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, step);

            }
        }

    }

    private void FixedUpdate()
    {
        if (_statusElettroshock == Utilities.StatusElettroshock.Shocked)
        {
            _timeToChangeStatus += Time.deltaTime;
        }
        if (_timeToChangeStatus > 5f)
        {
            _timeToChangeStatus = 0f;
            _statusElettroshock = Utilities.StatusElettroshock.None;
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

    public GameObject GetPlayer()
    {
        if (_player != null)
        {
            return _player;
        }
        return null;
    }

    public void SetStatusShocked()
    {
        _statusElettroshock = Utilities.StatusElettroshock.Shocked;
    }

}
