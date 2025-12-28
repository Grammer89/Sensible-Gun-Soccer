using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameObject _player;
    private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Utilities._playerTag);
        _playerAnimation = _player.GetComponent<PlayerAnimation>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Utilities._soccerBallTag))
        {
            _player.GetComponent<PlayerController>()._goal = true;
            _playerAnimation.SetPlayerGoal(true);

        }
    }
}
