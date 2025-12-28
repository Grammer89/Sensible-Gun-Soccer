using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _direction;
    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _rb;
    private Vector2 _lastdirection;
    private PlayerAnimation _animParam;
    private LifeController _lifeController;
    private bool _isDeath;
    public bool _kill;
    public bool _goal;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        //Setting come default Idle Down
        _lastdirection.y = -0.01f;
        _animParam = GetComponent<PlayerAnimation>();
        _animParam.SetPlayerSpeed(_lastdirection);

        _lifeController = GetComponent<LifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDeath) return;

        if (!_lifeController.IsAlive())
        {
            _animParam.SetPlayerIsDeath(true);
            _isDeath = true;
            SetDirection(Vector2.zero);
            GetComponent<Gun>().enabled = false;
            return;
        }

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        //Gestione Direzione nulla
        Vector2 Direction = new Vector2(_horizontal, _vertical);

        if (Direction == Vector2.zero)
        {
            Direction = _lastdirection;
        }
        else
        {
            _lastdirection = Direction;
        }

        SetDirection(Direction);

        //Gestione Animazione Movimento Player
        _animParam.SetPlayerSpeed(Direction);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (_speed * Time.deltaTime));
    }

    //Getter
    public Vector2 GetDirection() => _direction;

    //Setter
    private void SetDirection(Vector2 Direction)
    {

        if (Direction.magnitude > 1)
        {
            Direction = Direction / Direction.magnitude;
        }
        _direction = Direction;
    }



}
