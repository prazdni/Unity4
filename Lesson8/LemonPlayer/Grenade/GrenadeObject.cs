using UnityEngine;


public class GrenadeObject : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _time;
    [SerializeField] private float _powerThrow;
    [SerializeField] private float _powerExplosion;
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private int _damage;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Transform _temproraryGameObject = gameObject.transform.GetChild(0);
        GetComponent<Rigidbody>().AddForce((_temproraryGameObject.position - gameObject.transform.position) * _powerThrow, ForceMode.Impulse);
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time < 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusExplosion);

            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    if (coll.gameObject.CompareTag("Enemy"))
                    {
                        coll.gameObject.GetComponent<MyEnemy>().Hurt(_damage);
                    }
                    coll.GetComponent<Rigidbody>().AddExplosionForce(_powerExplosion, transform.position, _radiusExplosion);
                }
            }

            Destroy(this.gameObject);
        }
    }

    #endregion
}
