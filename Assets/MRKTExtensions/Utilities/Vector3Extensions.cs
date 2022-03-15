using System;
using System.Collections.Generic;
using UnityEngine;

namespace MRTKExtensions.Utilities
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Finds closest point on line segment
        /// <see href="https://gamedev.stackexchange.com/questions/172001/how-to-detect-least-distance-to-line-segments-calculation"/>
        /// <returns></returns>
        public static Vector3 GetClosestPointOnLineSegment(this Vector3 point, Vector3 segmentStart, Vector3 segmentEnd)
        {
            // Shift the problem to the origin to simplify the math.    
            var wander = point - segmentStart;
            var span = segmentEnd - segmentStart;

            // Compute how far along the line is the closest approach to our point.
            var t = Vector3.Dot(wander, span) / span.sqrMagnitude;

            // Restrict this point to within the line segment from start to end.
            t = Mathf.Clamp01(t);

            // Return this point.
            return segmentStart + t * span;
        }
        
        public static int GetClosestLineSegmentIndex(this Vector3 point, List<Vector3> lineSegments)
        {
            var closestIndex = -1;
            var closestSquaredRange = Mathf.Infinity;

            for (var i = 1; i < lineSegments.Count; i++)
            {
                var closestPoint = point.GetClosestPointOnLineSegment(lineSegments[i - 1], lineSegments[i]);

                var squaredRange = (point - closestPoint).sqrMagnitude;

                if (squaredRange < closestSquaredRange)
                {
                    closestSquaredRange = squaredRange;
                    closestIndex = i - 1;
                }
            }
            return closestIndex;
        }
        
        public static Vector3 GetClosestPointOnLineSegment(this Vector3 point, List<Vector3> lineSegments, int index)
        {
            return point.GetClosestPointOnLineSegment(lineSegments[index], lineSegments[index + 1]);
        }
        
        public static Tuple<Vector3,Vector3> GetClosestLineSegment(this Vector3 point, List<Vector3> lineSegments)
        {
            var closestIndex = point.GetClosestLineSegmentIndex(lineSegments);
            return new Tuple<Vector3, Vector3>(lineSegments[closestIndex], lineSegments[closestIndex + 1]);
        }
        
        
        public static Vector3 GetClosestPointOnLineSegments(this Vector3 point, List<Vector3> lineSegments)
        {
            var lineSegment = point.GetClosestLineSegment(lineSegments);
            return point.GetClosestPointOnLineSegment(lineSegment.Item1, lineSegment.Item2);
        }


        public static float DistanceTraveledAlongPath(this Vector3 point, List<Vector3> lineSegments)
        {
            var closestIndex = point.GetClosestLineSegmentIndex(lineSegments);
            return point.DistanceTraveledAlongPath(lineSegments, closestIndex);
        }

        public static float DistanceTraveledAlongPath(this Vector3 point, List<Vector3> lineSegments, int segmentIndex)
        {
            float distance = 0;
            if (lineSegments.Count > 1)
            {
                for (var i = 0; i < segmentIndex; i++)
                {
                    distance += Vector3.Distance(lineSegments[i], lineSegments[i + 1]);
                }

                distance += Vector3.Distance(lineSegments[segmentIndex], point);
            }
            return distance;
        }
        
        public static float TotalLength(this List<Vector3> lineSegments)
        {
            float length = 0;
            if (lineSegments.Count > 1)
            {
                for (var i = 0; i < lineSegments.Count - 1; i++)
                {
                    length += Vector3.Distance(lineSegments[i],lineSegments[i + 1]);
                }
            }

            return length;
        }
    }
}
