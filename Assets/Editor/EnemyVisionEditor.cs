using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(VisionSensor))]
public class EnemyVisionEditor : Editor
{
    void OnSceneGUI()
    {
        VisionSensor fow = (VisionSensor)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.VisionRadius);
        (Vector3 viewAngleA, Vector3 viewAngleB) = fow.GetConeBoundVectors();

        /*        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
                Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);*/

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.VisionRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.VisionRadius);


    }
}
