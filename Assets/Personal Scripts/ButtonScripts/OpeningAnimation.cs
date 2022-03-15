using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;

public class OpeningAnimation : MonoBehaviour
{
    public LeanEvent startinganimation, endinganimation, destroyanimation;

    void Start()
    {
        startinganimation.BeginThisTransition();
        endinganimation.BeginThisTransition();
        destroyanimation.BeginThisTransition();
    }
}
