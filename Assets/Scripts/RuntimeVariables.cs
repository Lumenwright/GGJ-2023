using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RuntimeVariables : ScriptableObject
{
    public Vector3 SunPosition;
    public Vector3 CloudPosition;
    public bool SunIsBlockedByCloud;
}
