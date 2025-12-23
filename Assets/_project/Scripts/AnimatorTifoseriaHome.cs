using UnityEngine;

public class AnimatorTifoseriaHome : MonoBehaviour
{
    static LifeController _lifePlayer;
    private Animator _animParam;
    // Start is called before the first frame update
    void Awake()
    {
        if (_lifePlayer == null)
        {
            GameObject player;

            player = GameObject.FindGameObjectWithTag(Utilities._playerTag);
            _lifePlayer = player.GetComponent<LifeController>();
        }
        _animParam = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_lifePlayer.IsAlive())
        {
            _animParam.SetBool(Utilities._playerLose, true);
        }
    }
}
