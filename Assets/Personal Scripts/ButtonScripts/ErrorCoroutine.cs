using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCoroutine : MonoBehaviour
{
    public ColorSwitcher blinker;

    void Awake()
    {
        blinker.enable = true;

        StartCoroutine(CancelBlink());
    }

    IEnumerator CancelBlink()
    {
        yield return new WaitForSeconds(2f);

        blinker.enable = false;
    }
}