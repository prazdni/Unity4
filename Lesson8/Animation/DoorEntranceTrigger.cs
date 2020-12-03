using UnityEngine;


public class DoorEntranceTrigger : MonoBehaviour
{

    [SerializeField] private GameObject[] _activeButtons;
    private BoxCollider _collider;

    private bool _allActivated;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _allActivated = false;
    }

    private void Update()
    {
        _allActivated = true;

        for (int i = 0; i < _activeButtons.Length; i++)
        {
            if (_activeButtons[i].GetComponent<MeshRenderer>().material.color != Color.white)
            {
                _allActivated = false;
                break;
            }
        }

        if (_allActivated)
        {
            _collider.isTrigger = true;
        }
        else
        {
            _collider.isTrigger = false;
        }
    }


}
