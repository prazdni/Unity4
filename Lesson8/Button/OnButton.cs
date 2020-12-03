using UnityEngine;


public class OnButton : MonoBehaviour
{
    #region Fields

    [SerializeField] private OpeningDoorsAnimation[] _animateObject;

    private Color _color;

    private bool _isAnimated;

    #endregion


    #region UnityMethods

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;

        _isAnimated = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CubeToThrow") && _isAnimated)
        {
            _isAnimated = false;

            GetComponent<MeshRenderer>().material.color = Color.blue;

            for (int i = 0; i < _animateObject.Length; i++)
            {
                _animateObject[i].IsButtonPressed = true;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CubeToThrow"))
        {
            _isAnimated = true;

            GetComponent<MeshRenderer>().material.color = Color.red;

            for (int i = 0; i < _animateObject.Length; i++)
            {
                _animateObject[i].IsButtonPressed = true;

            }
        }
    }


    #endregion
}
