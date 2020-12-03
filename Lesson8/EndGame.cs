using UnityEngine;


public class EndGame : MonoBehaviour
{
    #region Fields

    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;

    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private float _displayImageDuration = 1f;

    private float _timer;
    private bool _isPlayerAtExit;

    #endregion

    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player") && gameObject.GetComponent<EndGame>().enabled)
        {
            _isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup);
        }
    }

    #endregion


    #region Methods

    private void EndLevel(CanvasGroup imageCanvasGroup)
    {
        _timer += Time.deltaTime;
        imageCanvasGroup.alpha = _timer / _fadeDuration;

        if (_timer > _fadeDuration + _displayImageDuration)
        {
            Application.Quit();
        }
    }

    #endregion
}
