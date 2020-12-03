using UnityEngine;


public class Damager : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _player;

    #endregion


    #region Methods

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player.GetComponent<LemonHP>().IsDamaged = true;
        }
    }

    #endregion
}
