/* 
/// Copyright (c) 2015 Sirawat Pitaksarit, Exceed7 Experiments LP 
/// http://www.exceed7.com/introloop
*/

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(IntroloopAudio))]
public class IntroloopAudioEditor : Editor {

    private int selected = 0;
    public override void OnInspectorGUI()
    {
        SerializedObject so = this.serializedObject;
        SerializedProperty volume = so.FindProperty("volume");
        SerializedProperty audioClip = so.FindProperty("audioClip");
        SerializedProperty introBoundary = so.FindProperty("introBoundary");
        SerializedProperty loopingBoundary = so.FindProperty("loopingBoundary");
        SerializedProperty nonLooping = so.FindProperty("nonLooping");
        SerializedProperty loopWholeAudio = so.FindProperty("loopWholeAudio");

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(audioClip);
        if(audioClip.objectReferenceValue == null)
        {
            EditorGUILayout.HelpBox("Attach an audio clip!",MessageType.Warning);
        }
        EditorGUILayout.PropertyField(volume);
        EditorGUILayout.Space();
        if(loopWholeAudio.boolValue == true)
        {
            selected = 1;
        }
        else if(nonLooping.boolValue == true)
        {
            selected = 2;
        }
        else
        {
            selected = 0;
        }
        selected = GUILayout.SelectionGrid(selected,new string[]{"Introloop","Loop","Non looping"},3,EditorStyles.miniButton);
        switch(selected)
        {
            case(0):
            {
                loopWholeAudio.boolValue = false;
                nonLooping.boolValue = false;
                break;
            }
            case(1):
            {
                loopWholeAudio.boolValue = true;
                nonLooping.boolValue = false;
                break;
            }
            case(2):
            {
                loopWholeAudio.boolValue = false;
                nonLooping.boolValue = true;
                break;
            }
        }

        EditorGUI.BeginDisabledGroup(selected != 0);
        EditorGUILayout.BeginHorizontal();
        float halfWidth = Screen.width/2f;
        EditorGUILayout.LabelField("Intro Boundary",GUILayout.Width(halfWidth-12));
        EditorGUILayout.LabelField("Looping Boundary",GUILayout.Width(halfWidth+12));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(introBoundary,new GUIContent(""));
        EditorGUILayout.PropertyField(loopingBoundary,new GUIContent(""));
        EditorGUILayout.EndHorizontal();
        if(selected == 0)
        {
            if(loopingBoundary.floatValue - introBoundary.floatValue < 1)
            {
                EditorGUILayout.HelpBox("Set both boundaries to be more far apart!",MessageType.Error);
            }
        }
        EditorGUI.EndDisabledGroup();


        if(EditorGUI.EndChangeCheck())
        {
            if(introBoundary.floatValue > loopingBoundary.floatValue)
            {
                loopingBoundary.floatValue = introBoundary.floatValue;
            }
            so.ApplyModifiedProperties();
        }
    }
}
