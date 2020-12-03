using UnityEngine;


public class LookAtCharacter : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _objectToThrow;
    [SerializeField] private GameObject _mainObject;

    [SerializeField] private float _loveLength;

    private float _direction;
    private bool _flag;
    private bool _touched;

    #endregion


    #region Properties

    public bool Touched 
    { 
        set => _touched = value; 
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _touched = false;
        _direction = 0;
        
    }

    private void Update()
    {
        _direction = (transform.position - _mainObject.transform.position).magnitude;
        if ( _direction < _loveLength && _direction > 2)
        {
            transform.LookAt(_mainObject.transform);
            
            if (!_flag)
            {
                Instantiate(_objectToThrow, transform.position + Vector3.up, transform.rotation);
                _flag = true;
            }
            if (_touched)
            {
                Instantiate(_objectToThrow, transform.position + Vector3.up, transform.rotation);
                _touched = false;
            }
        }
    }

    #endregion
}
