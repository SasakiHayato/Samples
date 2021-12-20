using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deviation
{
    public Vector3 GetDir { get; private set; } = Vector3.zero;

    public void Predict(Transform shooter, Transform currentTarget, Vector3 beforePos)
    {
        Vector3 myPos = shooter.position;
        Vector3 tPos = currentTarget.position;
        Vector3 prePos = tPos + beforePos;

        Vector3 cForward = (tPos - myPos).normalized;
        Vector3 pForward = (prePos - tPos).normalized;
        float rad = Vector3.Dot(cForward, pForward);

        GetDir = pForward;
    }
}
