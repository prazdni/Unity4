using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private Transform _spawnPlace;

    [SerializeField] private int _quantity;

    private int _counter;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _counter = _quantity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (_objectToSpawn != null && _counter !=0)
            {
                _counter--;
                Instantiate(_objectToSpawn, _spawnPlace.position, _spawnPlace.rotation);
            }           
    }

    #endregion
}
