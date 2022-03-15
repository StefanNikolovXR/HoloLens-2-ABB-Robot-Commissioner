using MRTKExtensions.Gesture;
using UnityEngine;
using MRTKExtensions.Utilities;
using TMPro;

namespace App.Scripts
{
    public class HandRails : HandRailsBase
    {
        [SerializeField]
        private GameObject glider;

        [SerializeField]
        private TextMeshPro debugText;

        protected override void OnLocationUpdated()
        {
            glider.transform.position = PointOnLine;
            if (debugText != null)
            {
                var traveledLength = PointOnLine.DistanceTraveledAlongPath(WayPointLocations, CurrentIndex);
                var percentageTraveled = traveledLength / TotalLength * 100;
                debugText.text =
                    $"TotalLength {WayPointLocations.TotalLength():F}\nDistance traveled {traveledLength:F}\n percentage {percentageTraveled:F}";
            }
        }
    }
}
