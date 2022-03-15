using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUISAnimationStates : MonoBehaviour
{
    private Animator anim;
    public GameObject LUIS;

    void Start()
    {
        anim = LUIS.GetComponent<Animator>();
    }

    public void CommandSuccessful()
    {
        anim.SetBool("CommandAccepted", true);
    }
}
