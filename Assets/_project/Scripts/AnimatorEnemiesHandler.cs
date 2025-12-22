using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEnemiesHandler : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void SetPlayerFar(bool playerFar)
    {
        RefreshAllState();
        _animator.SetBool(Utilities._playerFarState, playerFar);
    }
    public void SetPlayerInRadar(bool playerInRadar)
    {
        RefreshAllState();
        _animator.SetBool(Utilities._playerInRadarState, playerInRadar);
    }
    public void SetPlayerNear(bool playerNear)
    {
        RefreshAllState();
        _animator.SetBool(Utilities._playerNearState, playerNear);
    }
    public void SetPlayerLose(bool playerLose)
    {
        RefreshAllState();
        _animator.SetBool(Utilities._playerLoseState, playerLose);
    }
    public void SetPlayerKillOrVictory(bool playerKillOrVictory)
    {
        RefreshAllState();
        _animator.SetBool(Utilities._playerKillOrVictoryState, playerKillOrVictory);
    }
    public void RefreshAllState()
    {
        _animator.SetBool(Utilities._playerFarState, false);
        _animator.SetBool(Utilities._playerInRadarState, false);
        _animator.SetBool(Utilities._playerNearState, false);
        _animator.SetBool(Utilities._playerLoseState, false);
        _animator.SetBool(Utilities._playerKillOrVictoryState, false);
    }

}
