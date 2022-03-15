using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;

public class UntoggleButtons : MonoBehaviour
{
    public ToggleASPTable toggle_sst, toggle_asp, toggle_tsp, toggle_apo, toggle_tpo, toggle_tor, toggle_general;

    public void ToggleGeneral()
    {
        toggle_tsp.IsToggled();
        toggle_apo.IsToggled();
        toggle_tpo.IsToggled();
        toggle_tor.IsToggled();
        toggle_asp.IsToggled();
        toggle_sst.IsToggled();
    }

    public void ToggleSST()
    {
        toggle_asp.IsToggled();
        toggle_tsp.IsToggled();
        toggle_apo.IsToggled();
        toggle_tpo.IsToggled();
        toggle_tor.IsToggled();
        toggle_general.IsToggled();
    }

    public void ToggleASP()
    {
        toggle_tsp.IsToggled();
        toggle_apo.IsToggled();
        toggle_tpo.IsToggled();
        toggle_tor.IsToggled();
        toggle_sst.IsToggled();
        toggle_general.IsToggled();
    }

    public void ToggleTSP()
    {
        toggle_sst.IsToggled();
        toggle_asp.IsToggled();
        toggle_apo.IsToggled();
        toggle_tpo.IsToggled();
        toggle_tor.IsToggled();
        toggle_general.IsToggled();
    }

    public void ToggleAPO()
    {
        toggle_sst.IsToggled();
        toggle_tsp.IsToggled();
        toggle_asp.IsToggled();
        toggle_tpo.IsToggled();
        toggle_tor.IsToggled();
        toggle_general.IsToggled();
    }

    public void ToggleTPO()
    {
        toggle_sst.IsToggled();
        toggle_tsp.IsToggled();
        toggle_apo.IsToggled();
        toggle_asp.IsToggled();
        toggle_tor.IsToggled();
        toggle_general.IsToggled();
    }

    public void ToggleTOR()
    {
        toggle_sst.IsToggled();
        toggle_tsp.IsToggled();
        toggle_apo.IsToggled();
        toggle_tpo.IsToggled();
        toggle_asp.IsToggled();
        toggle_general.IsToggled();
    }
}
