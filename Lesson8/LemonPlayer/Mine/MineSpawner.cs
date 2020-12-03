using System.Collections.Generic;
using UnityEngine;


public class MineSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;
    [SerializeField] private int _mineQuantity;

    private Queue<GameObject> Queue;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Queue = new Queue<GameObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Queue.Count < _mineQuantity)
            {
                Queue.Enqueue(Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation));
            }
            else
            {
                Destroy(Queue.Peek());
                Queue.Dequeue();
                Queue.Enqueue(Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation));
            }
        }      
    }

    #endregion
}
