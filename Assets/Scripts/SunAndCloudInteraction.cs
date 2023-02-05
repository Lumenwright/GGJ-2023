using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Place this at Earth center (center of rotation)
public class SunAndCloudInteraction : MonoBehaviour
{
    [SerializeField]
    GameParameters _gameParams;
    [SerializeField]
    RuntimeVariables _runtimeVars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var sunDirection = (_runtimeVars.SunPosition - transform.position).normalized;
        var cloudDirection = (_runtimeVars.CloudPosition - transform.position).normalized;
        var projection = Vector3.Dot(cloudDirection, sunDirection);
        UpdateIfSunIsBlocked(projection);
    }

    void UpdateIfSunIsBlocked(float dotProduct){

        // if the cloud is roughly blocking the sun
        if(1f - dotProduct < _gameParams.CloudBlockageOffset){
            _runtimeVars.SunIsBlockedByCloud = true;
            Debug.Log("sun is blocked");
        }
        else{
            _runtimeVars.SunIsBlockedByCloud = false;
        }
    }
}
