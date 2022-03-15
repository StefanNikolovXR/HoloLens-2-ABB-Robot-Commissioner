using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinMaxSpeed : MonoBehaviour
{
    public GameObject j1speedarc, j2speedarc, j3speedarc, j4speedarc, j5speedarc, j6speedarc;
    public GameObject j1speedarc_inner, j2speedarc_inner, j3speedarc_inner, j4speedarc_inner, j5speedarc_inner, j6speedarc_inner;
    public float j1rot, j2rot, j3rot, j4rot, j5rot, j6rot;
    public float j1max, j2max, j3max, j4max, j5max, j6max;
    public float j1min_sent, j2min_sent, j3min_sent, j4min_sent, j5min_sent, j6min_sent;
    public float j1max_sent, j2max_sent, j3max_sent, j4max_sent, j5max_sent, j6max_sent;
    public RPMAxisMonitoring rpm;

    public FinalAxisValues final;

    public void AdjustSpeed()
    {
        j1rot = final.asp_j1min * 1.44f;
        j2rot = final.asp_j2min * 1.44f;
        j3rot = final.asp_j3min * 1.44f;
        j4rot = final.asp_j4min * 1.125f;
        j5rot = final.asp_j5min * 1.125f;
        j6rot = final.asp_j6min * 0.857f;

        j1max = final.asp_j1max * 1.44f;
        j2max = final.asp_j2max * 1.44f;
        j3max = final.asp_j3max * 1.44f;
        j4max = final.asp_j4max * 1.125f;
        j5max = final.asp_j5max * 1.125f;
        j6max = final.asp_j6max * 0.857f;

        j1speedarc.transform.localEulerAngles = new Vector3(0, 180, -90 + j1rot);
        j2speedarc.transform.localEulerAngles = new Vector3(0, 180, -90 + j2rot);
        j3speedarc.transform.localEulerAngles = new Vector3(0, 180, -90 + j3rot);
        j4speedarc.transform.localEulerAngles = new Vector3(0, 180, -90 + j4rot);
        j5speedarc.transform.localEulerAngles = new Vector3(0, 180, -90 + j5rot);
        j6speedarc.transform.localEulerAngles  = new Vector3(0, 180, -90 + j6rot);

        j1speedarc_inner.transform.localEulerAngles = new Vector3(0, 180, -90 + j1rot);
        j2speedarc_inner.transform.localEulerAngles = new Vector3(0, 180, -90 + j2rot);
        j3speedarc_inner.transform.localEulerAngles = new Vector3(0, 180, -90 + j3rot);
        j4speedarc_inner.transform.localEulerAngles = new Vector3(0, 180, -90 + j4rot);
        j5speedarc_inner.transform.localEulerAngles = new Vector3(0, 180, -90 + j5rot);
        j6speedarc_inner.transform.localEulerAngles = new Vector3(0, 180, -90 + j6rot);

        j1speedarc.GetComponent<Shaper2D>().arcDegrees = j1max - j1rot;
        j2speedarc.GetComponent<Shaper2D>().arcDegrees = j2max - j2rot;
        j3speedarc.GetComponent<Shaper2D>().arcDegrees = j3max - j3rot;
        j4speedarc.GetComponent<Shaper2D>().arcDegrees = j4max - j4rot;
        j5speedarc.GetComponent<Shaper2D>().arcDegrees = j5max - j5rot;
        j6speedarc.GetComponent<Shaper2D>().arcDegrees = j6max - j6rot;

        j1speedarc_inner.GetComponent<Shaper2D>().arcDegrees = j1max - j1rot;
        j2speedarc_inner.GetComponent<Shaper2D>().arcDegrees = j2max - j2rot;
        j3speedarc_inner.GetComponent<Shaper2D>().arcDegrees = j3max - j3rot;
        j4speedarc_inner.GetComponent<Shaper2D>().arcDegrees = j4max - j4rot;
        j5speedarc_inner.GetComponent<Shaper2D>().arcDegrees = j5max - j5rot;
        j6speedarc_inner.GetComponent<Shaper2D>().arcDegrees = j6max - j6rot;
    }
}
