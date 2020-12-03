using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpeningDoorsAnimation : MonoBehaviour
{
    #region Fields

    private Animator _mainAnimator;

    private bool _isButtonPressed;

    #endregion


    #region Properties

    public bool IsButtonPressed
    {
        set => _isButtonPressed = value;
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _mainAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isButtonPressed)
        {
            _mainAnimator.SetTrigger("IsMoving");
            _isButtonPressed = false;
        }
    }

    #endregion
}
