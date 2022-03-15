using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Ara{
    [CustomEditor(typeof (AraTrail))]
    [CanEditMultipleObjects]
    internal class AraTrailEditor : Editor
    {
        SerializedProperty section;
        SerializedProperty space;
        SerializedProperty customSpace;
        SerializedProperty timescale;
        SerializedProperty alignment;
        SerializedProperty sorting;
        SerializedProperty thickness;
        SerializedProperty smoothness;
        SerializedProperty highQualityCorners;
        SerializedProperty cornerRoundness;

        SerializedProperty thicknessOverLength;
        SerializedProperty colorOverLength;

        SerializedProperty thicknessOverTime;
        SerializedProperty colorOverTime;

        SerializedProperty emit;
        SerializedProperty initialThickness;
        SerializedProperty initialColor;
        SerializedProperty initialVelocity;
        SerializedProperty timeInterval;
        SerializedProperty minDistance;
        SerializedProperty time;

        SerializedProperty enablePhysics;
        SerializedProperty warmup;
        SerializedProperty gravity;
        SerializedProperty inertia;
        SerializedProperty velocitySmoothing;
        SerializedProperty damping;

        SerializedProperty materials;
        SerializedProperty castShadows;
        SerializedProperty receiveShadows;
        SerializedProperty useLightProbes;

        SerializedProperty quadMapping;
        SerializedProperty textureMode;
        SerializedProperty uvFactor;
        SerializedProperty uvWidthFactor;
        SerializedProperty tileAnchor;

        public void OnEnable()
        {
            section = serializedObject.FindProperty("section");
            space = serializedObject.FindProperty("space");
            customSpace = serializedObject.FindProperty("customSpace");
            timescale = serializedObject.FindProperty("timescale");
            alignment = serializedObject.FindProperty("alignment");
            sorting = serializedObject.FindProperty("sorting");
            thickness = serializedObject.FindProperty("thickness");
            smoothness = serializedObject.FindProperty("smoothness");
            highQualityCorners = serializedObject.FindProperty("highQualityCorners");
            cornerRoundness = serializedObject.FindProperty("cornerRoundness");

            thicknessOverLength = serializedObject.FindProperty("thicknessOverLength");
            colorOverLength = serializedObject.FindProperty("colorOverLength");

            thicknessOverTime = serializedObject.FindProperty("thicknessOverTime");
            colorOverTime = serializedObject.FindProperty("colorOverTime");

            emit = serializedObject.FindProperty("emit");
            initialThickness = serializedObject.FindProperty("initialThickness");
            initialColor = serializedObject.FindProperty("initialColor");
            initialVelocity = serializedObject.FindProperty("initialVelocity");
            timeInterval = serializedObject.FindProperty("timeInterval");
            minDistance = serializedObject.FindProperty("minDistance");
            time = serializedObject.FindProperty("time");

            enablePhysics = serializedObject.FindProperty("enablePhysics");
            warmup = serializedObject.FindProperty("warmup");
            gravity = serializedObject.FindProperty("gravity");
            inertia = serializedObject.FindProperty("inertia");
            velocitySmoothing = serializedObject.FindProperty("velocitySmoothing");
            damping = serializedObject.FindProperty("damping");

            materials = serializedObject.FindProperty("materials");
            castShadows = serializedObject.FindProperty("castShadows");
            receiveShadows = serializedObject.FindProperty("receiveShadows");
            useLightProbes = serializedObject.FindProperty("useLightProbes");

            quadMapping = serializedObject.FindProperty("quadMapping");
            textureMode = serializedObject.FindProperty("textureMode");
            uvFactor = serializedObject.FindProperty("uvFactor");
            uvWidthFactor = serializedObject.FindProperty("uvWidthFactor");
            tileAnchor = serializedObject.FindProperty("tileAnchor");
        }

        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();
            //Editor.DrawPropertiesExcluding(serializedObject,"m_Script");

            EditorGUILayout.PropertyField(section);
            EditorGUILayout.PropertyField(space);
            if (space.enumValueIndex == 2)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(customSpace);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(timescale);
            EditorGUILayout.PropertyField(alignment);
            EditorGUILayout.PropertyField(sorting);
            EditorGUILayout.PropertyField(thickness);
            EditorGUILayout.PropertyField(smoothness);
            EditorGUILayout.PropertyField(highQualityCorners);
            if (highQualityCorners.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(cornerRoundness);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(thicknessOverLength);
            EditorGUILayout.PropertyField(colorOverLength);

            EditorGUILayout.PropertyField(thicknessOverTime);
            EditorGUILayout.PropertyField(colorOverTime);

            EditorGUILayout.PropertyField(emit);
            EditorGUILayout.PropertyField(initialThickness);
            EditorGUILayout.PropertyField(initialColor);
            EditorGUILayout.PropertyField(initialVelocity);
            EditorGUILayout.PropertyField(timeInterval);
            EditorGUILayout.PropertyField(minDistance);
            EditorGUILayout.PropertyField(time);

            EditorGUILayout.PropertyField(enablePhysics);
            if (enablePhysics.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(warmup);
                EditorGUILayout.PropertyField(gravity);
                EditorGUILayout.PropertyField(inertia);
                EditorGUILayout.PropertyField(velocitySmoothing);
                EditorGUILayout.PropertyField(damping);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(materials,true);
            EditorGUILayout.PropertyField(castShadows);
            EditorGUILayout.PropertyField(receiveShadows);
            EditorGUILayout.PropertyField(useLightProbes);

            EditorGUILayout.PropertyField(quadMapping);
            EditorGUILayout.PropertyField(textureMode);
            EditorGUILayout.PropertyField(uvFactor);
            EditorGUILayout.PropertyField(uvWidthFactor);
            EditorGUILayout.PropertyField(tileAnchor);

            this.serializedObject.ApplyModifiedProperties();
        }
    }
}

