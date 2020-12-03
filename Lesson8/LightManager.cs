using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light[] _corridorLights;
    [SerializeField] private Light _mainLight;

    private bool _entranceChecker;

    private void Start()
    {
        _entranceChecker = false;
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_entranceChecker)
            {

                _entranceChecker = true;

                for (int i = 0; i < _corridorLights.Length; i++)
                {
                    _corridorLights[i].gameObject.SetActive(_entranceChecker);
                }

                _mainLight.gameObject.SetActive(!_entranceChecker);
            }
            else
            {
                _entranceChecker = false;

                for (int i = 0; i < _corridorLights.Length; i++)
                {
                    _corridorLights[i].gameObject.SetActive(_entranceChecker);
                }

                _mainLight.gameObject.SetActive(!_entranceChecker);

                print(_entranceChecker);
            }
        }
    }
}
