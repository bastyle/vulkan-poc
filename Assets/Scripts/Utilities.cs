using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static bool CheckDistanceLess(Vector3 pos, Vector3 des, float v)
    {

        if (Vector3.Distance(pos, des) <= v)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static bool isSeeingTarget(Vector3 v1, Vector3 v2, Vector3 v3, float cutoff)
    {
        //v3 is a unit vector
        Vector3 T2Eheading = v2 - v1;
        T2Eheading.Normalize();
        float cosTheta = Vector3.Dot(v3, T2Eheading);
        return (cosTheta > cutoff);
    }

    
}
