using UnityEngine;


public class TakeObject : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform _position;
    [SerializeField] private int _power;
    [SerializeField] private int _takeLength;

    private GameObject _mainObject;
    private bool _flagFollow;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _mainObject = GameObject.FindGameObjectWithTag("Player");
        _flagFollow = false;
    }

    private void Update()
    {
        if ((_mainObject.transform.position - transform.position).magnitude < _takeLength)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                _flagFollow = true;
            }
        }
        if (_flagFollow == true)
        {          
            if (Input.GetKeyUp(KeyCode.F))
            {   
                GetComponent<Rigidbody>().AddForce((_position.position - _mainObject.transform.position) * _power);
                _flagFollow = false;
            }
            else
            {

                transform.position = _position.position;
                GetComponent<Rigidbody>().rotation = _mainObject.transform.rotation;
            }
        }
    }

    #endregion
}
