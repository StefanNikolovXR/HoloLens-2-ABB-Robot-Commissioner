using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;

public class ToggleSafeZoneDataTable : MonoBehaviour
{
    public Follow follow;
    public SolverHandler solver;

    public void ToggleZone()
    {
        follow.enabled = true;
        solver.enabled = true;
    }
}
