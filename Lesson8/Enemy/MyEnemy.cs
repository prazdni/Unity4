using TMPro;
using UnityEngine;


public class MyEnemy : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _hpText;
    [SerializeField] private int _health;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _hpText = Instantiate(_hpText, transform.position + Vector3.right / 2 + Vector3.up, Quaternion.identity);
        _hpText.GetComponent<TextMeshPro>().text = _health.ToString();
    }

    private void Update()
    {
        _hpText.transform.position = transform.position + Vector3.right / 2 + Vector3.up;
        _hpText.GetComponent<TextMeshPro>().text = _health.ToString();
    }

    #endregion


    #region Methods

    public void Hurt(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(_hpText);
        Destroy(gameObject);
    }

    #endregion
}
