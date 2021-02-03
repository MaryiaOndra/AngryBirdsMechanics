using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRendererComp;

    void Start()
    {
        lineRendererComp = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed) 
    {
        Vector3[] points = new Vector3[100];

        for (int i = 0; i < points.Length; i++)
        {
            float _time = i * 0.1f;
            points[i] = origin + speed * _time + Physics.gravity * _time * _time / 2f;
        }

        lineRendererComp.SetPositions(points);
    }
}
