using UnityEngine;
using UnityEngine.SceneManagement;


public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private GameObject _mainObject;

    [SerializeField] private float _fadeDuration = 1f;

    private float _timer = 0.0f;
    private bool _isGameOver;

    private void Start()
    {
        _isGameOver = false;
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 1f);
    }

    private void Update()
    {
        if ((_mainObject.transform.position - transform.position).magnitude < 2)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                _isGameOver = true;
            }
        }

        if (_isGameOver)
        {
            EndLevel(exitBackgroundImageCanvasGroup);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup)
    {
        print(_timer);
        _timer += Time.deltaTime;
        imageCanvasGroup.alpha = _timer / _fadeDuration;

        if (_timer > _fadeDuration)
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }

}
