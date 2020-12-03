using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemonAnimationController : MonoBehaviour
{

    #region Fields

    private Animator _mainAnimation;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _mainAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GetComponent<LemonMovement>().IsSpeed())
        {
           //_mainAnimation.applyRootMotion = false;
            _mainAnimation.SetBool("IsWalking", true);
        }
        else
        {
           // _mainAnimation.applyRootMotion = false;
            _mainAnimation.SetBool("IsWalking", false);
        }
        
    }

    #endregion
}
