using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotates this GameObject at a set speed
public class SunRotation : MonoBehaviour
{
    [SerializeField]
    GameParameters _gameParams;
    [SerializeField]
    RuntimeVariables _runtimeVars;

    [SerializeField]
    Transform _sunSprite;

    // Start is called before the first frame update
    void Start()
    {
        float radius = _gameParams.SunRadiusOffset + _gameParams.EarthRadius;
        _sunSprite.position = Vector2.right * radius;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = _gameParams.SunSpeed;
        transform.Rotate(0f, 0f, speed);
        _runtimeVars.SunPosition = _sunSprite.transform.position;
    }
}
