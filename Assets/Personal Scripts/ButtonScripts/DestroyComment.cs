using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComment : MonoBehaviour
{
    public GameObject comment;

    public void DestroythisComment()
    {
        Destroy(comment);
    }
}
