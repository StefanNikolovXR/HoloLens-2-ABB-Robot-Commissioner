using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class CreateSphereOnIndex : MonoBehaviour
{

    public GameObject CreateRobotTarget;

    
    public void OnHoldClick()
    {
        foreach (var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        {
          
            if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
            {
                foreach (var p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                   
                        continue;
                    }
                    if (p.Result != null)
                    {
                        var startPoint = p.Position;  

                        Instantiate(CreateRobotTarget);

                        CreateRobotTarget.transform.position = startPoint;
                       
                    }

                }
            }
        }
    }
}