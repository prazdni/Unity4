using UnityEngine;


public class TextVisualizer : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _mainObject;
    [SerializeField] private CanvasGroup _text;

    [SerializeField] private float _fadeDuration = 1f;

    private float _timer = 0.0f;
    private bool _flagOut;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _flagOut = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _timer = _timer / _fadeDuration > 1 ? 1 : _timer + Time.deltaTime;
            _text.alpha = _timer / _fadeDuration;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _flagOut = true;
    }

    private void Update()
    {
        if (_flagOut)
        {
            if (_text.alpha > 0)
            {
                _timer -= Time.deltaTime;
                _text.alpha = _timer / _fadeDuration;
            }
            else
            {
                _timer = 0;
                _flagOut = false;
            }
            
        }
    }

    #endregion
}
