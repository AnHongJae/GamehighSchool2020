using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Test : EditorWindow
{
    [MenuItem("Window/Test")]
    static void Init()
    {
        Test window = (Test)EditorWindow.GetWindow(typeof(Test));
        window.Show();
    }

    void OnGUI()
    {
        Handles.color = Color.black;
        Handles.DrawRectangle(0, new Vector3(200, 200,0), Quaternion.identity, 100);
        Handles.DrawSolidDisc(new Vector3(200, 200, 0), Vector3.forward, 100);
        Handles.DrawSolidDisc(new Vector3(150, 150, 0), Vector3.forward, 50);
        Handles.DrawSolidDisc(new Vector3(250, 150, 0), Vector3.forward, 50);
    }
}
