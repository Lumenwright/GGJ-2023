using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameParameters : ScriptableObject
{
    public float EarthRadius;
    // EarthRadius + SunRadiusOffset = SunRadius 
    // to keep Sun above Earth
    public float SunRadiusOffset;
    public float SunSpeed;
    public float CloudNormalizedRadius;
}
