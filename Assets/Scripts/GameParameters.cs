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

    // the fudge factor for determining if the cloud is blocking the sun
    // from 0 to 1 (should be around 0.05)
    public float CloudBlockageOffset;
}
