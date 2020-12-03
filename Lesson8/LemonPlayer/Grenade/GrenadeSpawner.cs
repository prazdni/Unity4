using UnityEngine;


public class GrenadeSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _grenade;
    [SerializeField] private float _time;
    
    private float _timer;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _timer = -1;
    }

    private void Update()
    {
        _timer = _timer >= 0 ? _timer - Time.deltaTime : _timer;
        if (Input.GetKeyUp(KeyCode.R))
        {
            if ( _timer < 0)
            {
                Instantiate(_grenade, transform.position + Vector3.up * 2, transform.rotation);
                _timer = _time;
            }    
        }
    }

    #endregion
}
