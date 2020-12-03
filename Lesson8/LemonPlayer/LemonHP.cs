using TMPro;
using UnityEngine;


public class LemonHP : MonoBehaviour
{
    #region Fields

    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private GameObject _text;
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private float _displayImageDuration = 1f;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    private float _timer;
    private float _hp;
    private bool _isDamaged;
    private bool _isHealed;

    #endregion


    #region Properties

    public bool IsDamaged
    {
        set => _isDamaged = value;
    }
    
    public bool IsHealed
    {
        set => _isHealed = value;
    }

    #endregion


    #region UnityMethods

    void Start()
    {
        _text = Instantiate(_text, transform.position + Vector3.right / 2 + Vector3.up, Quaternion.identity);
        _hp = 100;
    }

    void Update()
    {   
        if (_isDamaged)
        {
            _hp -= _damage * Time.deltaTime;
            _isDamaged = false;
            if (_hp < 0)
            {
                EndLevel(exitBackgroundImageCanvasGroup);
            }
        }
        if (_isHealed)
        {
            _hp = Mathf.Round(_hp);
            _hp = 100 > _hp ? _hp + _heal : 100;
            _isHealed = false;
        }
        _text.GetComponent<TextMeshPro>().text = Mathf.RoundToInt(_hp).ToString();
        _text.transform.position = transform.position + Vector3.right / 2 + Vector3.up;
        _text.transform.rotation = Quaternion.identity;
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
