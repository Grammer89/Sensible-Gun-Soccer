using UnityEngine;

public class AnimatorPlayerHandler : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void SetPlayerSpeed(Vector2 direction)
    {
        _animator.SetFloat(Utilities._playerXspeed, direction.x);
        _animator.SetFloat(Utilities._playerYspeed, direction.y);
    }

    public void SetPlayerIsDeath(bool death)
    {
        _animator.SetBool(Utilities._playerIsDeath, death);

    }

    public bool GetPlayerIsDeath()
    {
        return _animator.GetBool(Utilities._playerIsDeath);
    }
}
