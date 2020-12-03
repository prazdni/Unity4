using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _timer;

    private PickableObjects _pickableItem;

    private bool _isBuffed;

    private float _time;

    private float _previousNumber;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _time = -1;
        _isBuffed = false;
    }

    private void Update()
    {
        if (_time > 0)
        {
            switch (_pickableItem)
            {
                case PickableObjects.None:
                    break;
                case PickableObjects.Health:
                    break;
                case PickableObjects.Speed:
                    SpeedPickUp();
                    break;
                case PickableObjects.Jump:
                    JumpPickUp();
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable") && !_isBuffed)
        {
            switch (other.GetComponent<PickableItem>().Effect)
            {
                case PickableObjects.None:
                    break;
                case PickableObjects.Health:
                    Destroy(other.gameObject);
                    _isBuffed = true;
                    _time = _timer;
                    GetComponent<LemonHP>().IsHealed = true;
                    break;
                case PickableObjects.Speed:
                    Destroy(other.gameObject);
                    _isBuffed = true;
                    _time = _timer;
                    _previousNumber = GetComponent<LemonMovement>().Speed;
                    _pickableItem = PickableObjects.Speed;
                    SpeedPickUp();
                    break;
                case PickableObjects.Jump:
                    Destroy(other.gameObject);

                    _isBuffed = true;
                    _time = _timer;

                    _previousNumber = GetComponent<LemonMovement>().Jump;
                    _pickableItem = PickableObjects.Jump;

                    JumpPickUp();
                    break;
                default:
                    break;
            }
        }
    }

    #endregion


    #region Methods

    private void SpeedPickUp()
    {
        _time -= Time.deltaTime;

        if (_time > 0)
        {
            GetComponent<LemonMovement>().Speed = 10;
        }
        else
        {
            _isBuffed = false;
            GetComponent<LemonMovement>().Speed = _previousNumber;
        }  
    }

    private void JumpPickUp()
    {
        _time -= Time.deltaTime;

        if (_time > 0)
        {
            GetComponent<LemonMovement>().Jump = 10;
        }
        else
        {
            _isBuffed = false;
            GetComponent<LemonMovement>().Jump = _previousNumber;
        }
    }

    #endregion
}
