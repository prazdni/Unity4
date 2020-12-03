using UnityEngine;


public class TakeKey : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _gameEnding;
    [SerializeField] private GameObject _spawner;
    [SerializeField] private Transform _spawnPlace;

    private GameObject _mainObject;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _mainObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if ((_mainObject.transform.position - transform.position).magnitude < 1)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Destroy(gameObject);
                Instantiate(_spawner, _spawnPlace.position, Quaternion.identity);
                _gameEnding.GetComponent<EndGame>().enabled = true;
            }
        }
    }

    #endregion
}
