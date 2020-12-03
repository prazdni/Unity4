using UnityEngine;


public class MineObject : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _radius;
    [SerializeField] private float _power;
    [SerializeField] private int _damage;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print(other.name);
            var enemy = other.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    print(coll.name);
                    coll.GetComponent<Rigidbody>().AddExplosionForce(_power, transform.position, _radius);
                }
            }
            Destroy(gameObject);
        }
    }

    #endregion
}
