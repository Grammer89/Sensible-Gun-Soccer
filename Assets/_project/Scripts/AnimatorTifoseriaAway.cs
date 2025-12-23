using UnityEngine;


public class AnimatorTifoseriaAway : MonoBehaviour
{
    private GameObject player;
    private Animator _animParam;
    // Start is called before the first frame update
    void Awake()
    {


        player = GameObject.FindGameObjectWithTag(Utilities._playerTag);

        _animParam = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>()._kill)
        {
            player.GetComponent<PlayerController>()._kill = false;
            _animParam.SetBool(Utilities._playerKillState, true);
        }
        else if (player.GetComponent<PlayerController>()._goal)
        {
            _animParam.SetBool(Utilities._playerKillState, true);
        }
    }
}
