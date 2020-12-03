using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    #region Fields

    [SerializeField] float _back;
    [SerializeField] float _up;

    private GameObject _mainObject;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _mainObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = _mainObject.transform.position + Vector3.up * _up + Vector3.back * _back;
    }

    #endregion
}
