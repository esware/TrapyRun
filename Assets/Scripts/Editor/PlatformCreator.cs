using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEditor;

public class PlatformCreator : EditorWindow
{
    private GameObject objectPrefab; 
    private int platformWidth;
    private int platformHeight;

    [MenuItem("Tools/PlatformCreator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(PlatformCreator));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn New Object",EditorStyles.boldLabel);

        objectPrefab = EditorGUILayout.ObjectField("Object Prefab", objectPrefab, typeof(GameObject), false) as GameObject;
        platformHeight = EditorGUILayout.IntField("Platform Height", platformHeight);
        platformWidth = EditorGUILayout.IntField("Platform Width", platformWidth);

        if (GUILayout.Button("Create Platform"))
        {
            CreatePlatform();
        }
    }

    private void CreatePlatform()
    {
        if (objectPrefab == null)
        {
            Debug.LogError("Error : Please assign an object to be spawned");
            return;
        }

        GameObject parentObj = new GameObject();
        parentObj.name = "Platform";
        
        for (int i = 0; i < platformWidth; i++)
        {
            for (int j = 0; j < platformHeight; j++)
            {
                var spawnedObject = Instantiate(objectPrefab, Vector3.zero + new Vector3(i, 0, j),
                    quaternion.identity);
                objectPrefab = spawnedObject;
                objectPrefab.transform.parent = parentObj.transform;
            }
        }
        
        
    }
}
