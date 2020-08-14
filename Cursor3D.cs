#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public class Cursor3D : EditorWindow
{

    [MenuItem("Window/3DCursor/Enable #Y")]
    public static void Enable()
    {
        SceneView.duringSceneGui += OnScene;
    }

    [MenuItem("Window/3DCursor/Disable #%Y")]
    public static void Disable()
    {
        SceneView.duringSceneGui -= OnScene;
    }

    [MenuItem("Window/3DCursor/Reset #X")]
    public static void ResetPivot()
    {
        var scene = SceneView.lastActiveSceneView;
        scene.pivot = Vector3.zero;
    }

    private static void OnScene(SceneView obj)
    {
        var scene = SceneView.lastActiveSceneView;
        Handles.color = Handles.selectedColor;
        Handles.SphereHandleCap(0, scene.pivot, Quaternion.identity,.2f, EventType.Repaint);
        scene.Repaint();
    }

}

#endif