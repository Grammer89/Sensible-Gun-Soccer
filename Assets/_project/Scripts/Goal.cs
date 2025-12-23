using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Utilities._playerTag);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Utilities._soccerBallTag))
        {
            _player.GetComponent<PlayerController>()._goal = true;
        }
    }
}
