using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _direction;
    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _rb;
    private Vector2 _lastdirection;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
