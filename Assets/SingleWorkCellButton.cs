using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleWorkCellButton : MonoBehaviour
{
    public GameObject handinitialization;
    public GameObject placeanchortask;
    public StartMenu startmenu;

    public void TapSingleWorkCell()
    {
        handinitialization.SetActive(true);
        placeanchortask.SetActive(true);
        startmenu.ToggleStartMenu();
    }
}
