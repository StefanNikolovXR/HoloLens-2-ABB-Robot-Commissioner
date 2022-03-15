using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateReplay;
using TMPro;

public class RecordReplaySpeed : ReplayBehaviour
{
     public GameObject j1arc, j2arc, j3arc, j4arc, j5arc, j6arc;
     public TextMeshPro j1value, j2value, j3value, j4value, j5value, j6value;
  
        [ReplayVar]
        public float j1speed, j2speed, j3speed, j4speed, j5speed, j6speed;
        public string j1text, j2text, j3text, j4text, j5text, j6text;

    void Start()
    {
        j1speed = j1arc.GetComponent<Shaper2D>().arcDegrees;
        j2speed = j2arc.GetComponent<Shaper2D>().arcDegrees;
        j3speed = j3arc.GetComponent<Shaper2D>().arcDegrees;
        j4speed = j4arc.GetComponent<Shaper2D>().arcDegrees;
        j5speed = j5arc.GetComponent<Shaper2D>().arcDegrees;
        j6speed = j6arc.GetComponent<Shaper2D>().arcDegrees;
    }

        void Update()
        {

            if (IsRecording == true)
            {
            j1speed = j1arc.GetComponent<Shaper2D>().arcDegrees;
            j2speed = j2arc.GetComponent<Shaper2D>().arcDegrees;
            j3speed = j3arc.GetComponent<Shaper2D>().arcDegrees;
            j4speed = j4arc.GetComponent<Shaper2D>().arcDegrees;
            j5speed = j5arc.GetComponent<Shaper2D>().arcDegrees;
            j6speed = j6arc.GetComponent<Shaper2D>().arcDegrees;

            j1text = j1value.text;
            j2text = j2value.text;
            j3text = j3value.text;
            j4text = j4value.text;
            j5text = j5value.text;
            j6text = j6value.text;
        }

            else if (IsReplaying == true)
            {
            j1arc.GetComponent<Shaper2D>().arcDegrees = j1speed;
            j2arc.GetComponent<Shaper2D>().arcDegrees = j2speed;
            j3arc.GetComponent<Shaper2D>().arcDegrees = j3speed;
            j4arc.GetComponent<Shaper2D>().arcDegrees = j4speed;
            j5arc.GetComponent<Shaper2D>().arcDegrees = j5speed;
            j6arc.GetComponent<Shaper2D>().arcDegrees = j6speed;

            j1value.text = j1text;
            j2value.text = j2text;
            j3value.text = j3text;
            j4value.text = j4text;
            j5value.text = j5text;
            j6value.text = j6text;
        }
        }
    }

