using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInteraction : MonoBehaviour
{
    [SerializeField]
    GameParameters _gameParams;

    private Vector3 _dragOffset;

    // Start s called before the first frame update
    void Start()
    {
        float radius = _gameParams.EarthRadius + (_gameParams.SunRadiusOffset * _gameParams.CloudNormalizedRadius);
        transform.position = ProjectOnRadius(Vector3.right, radius);
    }

    void OnMouseDown(){
        _dragOffset = transform.position - GetMousePosition();
    }

    void OnMouseDrag()
    {
        float radius = _gameParams.EarthRadius + (_gameParams.SunRadiusOffset * _gameParams.CloudNormalizedRadius);
        var mouse = GetMousePosition() + _dragOffset;
        var cloud = ProjectOnRadius(mouse, radius);
        transform.position = cloud;
    }

    Vector3 GetMousePosition(){
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }

    Vector3 ProjectOnRadius(Vector3 point, float radius){
        var center = transform.parent.position;
        var direction = (point - center).normalized;
        return direction * radius;
    }
}
