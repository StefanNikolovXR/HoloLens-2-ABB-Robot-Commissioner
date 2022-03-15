using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeDistanceEmulation : MonoBehaviour
{
    public GameObject RPMJointCalculations_Container, AccurateEuler_Container;

    public GameObject j1circlepos, j2circlepos, j3circlepos, j1circleneg, j2circleneg, j3circleneg;

    public float j1brakeval, j2brakeval, j3brakeval;

    public float j1brakedist, j2brakedist, j3brakedist;

    public float j1curr, j2curr, j3curr;

    public Vector3 j1brakevector, j2brakevector, j3brakevector;

    public bool j1dir, j2dir, j3dir;

    public void Update()
    {
        j1dir = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j1neg;
        j2dir = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j2neg;
        j3dir = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j3neg;

        j1curr = AccurateEuler_Container.GetComponent<AccurateEuler>().J1pos;
        j2curr = AccurateEuler_Container.GetComponent<AccurateEuler>().J2pos;
        j3curr = AccurateEuler_Container.GetComponent<AccurateEuler>().J3pos;


       if (j1dir) { j1brakeval = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j1vel / 5f;
            j1circlepos.GetComponent<Shaper2D>().arcDegrees = j1brakeval;
        }

        else { j1brakeval = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j1vel / -5f;
            j1circleneg.GetComponent<Shaper2D>().arcDegrees = j1brakeval;
        }

        if (j2dir) { j2brakeval = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j2vel / 5f;
            j2circlepos.GetComponent<Shaper2D>().arcDegrees = j2brakeval;
        }

        else { j2brakeval = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j2vel / -5f;
            j2circleneg.GetComponent<Shaper2D>().arcDegrees = j2brakeval;
        }

        if (j3dir) { j3brakeval = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j3vel / 5f;
            j3circlepos.GetComponent<Shaper2D>().arcDegrees = j3brakeval;
        }

        else { j3brakeval = RPMJointCalculations_Container.GetComponent<RPMJointCalculations>().j3vel / -5f;
            j3circleneg.GetComponent<Shaper2D>().arcDegrees = j3brakeval;

        }

        j1brakedist = Mathf.Abs(j1brakeval);
        j2brakedist = Mathf.Abs(j2brakeval);
        j3brakedist = Mathf.Abs(j3brakeval);


    }
}
