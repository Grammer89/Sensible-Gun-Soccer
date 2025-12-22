using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp;

    //Constructor
    public LifeController()
    { }
    //Getter
    public float GetHp() => _hp;

    //Setter
    public void SetHp(int hp)
    { _hp = hp; }

    //Functionality
    public void TakeDamage(int damage)
    {
        _hp = Mathf.Max(0, _hp - Mathf.Abs(damage));
    }

    public void AddHp(int hp)
    { _hp += hp; }
    public bool IsAlive()
    {
        if (_hp > 0)
        { return true; }
        else
        {
            return false;
        }
    }

}
