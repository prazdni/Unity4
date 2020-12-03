using UnityEngine;


public class Life : MonoBehaviour
{
    #region Fields

    [SerializeField] int _speed;

    private GameObject _mainObject;
    private GameObject _connectedObject;
    private Vector3 _distance;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _mainObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _distance = _mainObject.transform.position - gameObject.transform.position;
        transform.LookAt(_mainObject.transform);
        transform.position += _distance * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<LemonHP>().IsHealed = true;
            Destroy(gameObject);
            _connectedObject = GameObject.FindGameObjectWithTag("UnityChan");
            _connectedObject.GetComponent<LookAtCharacter>().Touched = true;
        }
    }

    #endregion
}
