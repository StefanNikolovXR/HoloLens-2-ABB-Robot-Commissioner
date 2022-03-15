using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{

    public class CommandtoWalk : MonoBehaviour
    {
        public GameObject PrefabToSpawn, CommandObject;

        public void Spawn(MixedRealityPointerEventData eventData)
        {
            if (PrefabToSpawn != null)
            {
                var result = eventData.Pointer.Result;
                CommandObject.transform.position = result.Details.Point;

            }
        }
    }
}