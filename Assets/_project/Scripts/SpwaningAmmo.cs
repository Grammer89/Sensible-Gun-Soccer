using System.Collections.Generic;
using UnityEngine;

public class SpwaningAmmo : MonoBehaviour
{
    [SerializeField] private List<Bullet> _ammoPrefabList = new List<Bullet>();
    private LifeController _lifeController;

    private void Awake()
    {
        _lifeController = GetComponent<LifeController>();
    }

    private void FixedUpdate()
    {
        if (!_lifeController.IsAlive())
        {
            SpawningAmmo();
        }
    }
    public void SpawningAmmo()
    {
        if (_ammoPrefabList.Count > 0)
        {
            Bullet ammoPrefab = Instantiate(_ammoPrefabList[Random.Range(0, _ammoPrefabList.Count)]);
            Vector2 newDirection = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1);
            ammoPrefab.transform.position = newDirection;
            GetComponent<SpwaningAmmo>().enabled = false;
        }
    }
}
