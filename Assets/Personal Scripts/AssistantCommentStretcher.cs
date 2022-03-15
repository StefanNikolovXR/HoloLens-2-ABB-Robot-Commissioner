using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Examples.Experimental.Demos;

    public class AssistantCommentStretcher : MonoBehaviour
{
    public GameObject Doodad;

    public TextMeshPro Message;


    IEnumerator Wait1Second()
    {
        yield return new WaitForSeconds(1);
        Message.text = "Hello! My name is ABB-Chan and I will be your virtual assistant during commissioning!";
    }

        public void SpawnandStretch ()
    {
        Doodad.SetActive(true);
        
        Doodad.GetComponent<WidgetElasticDemo>().ToggleInflate();

        StartCoroutine(Wait1Second());

        
    }
}
