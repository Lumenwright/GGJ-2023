using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootHead : MonoBehaviour
{
    private Vector3 sunCenter;
    private Vector3 sunPosition;
    private float radius = 3.0f;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sunfollow();  
    }
    void Sunfollow()
    {
        Ray ray = GameObject.FindGameObjectWithTag("Sun").GetComponent<Camera>().ScreenPointToRay(_sunSprite.position);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000.0f);

        sunPosition = new Vector3(hit.point.x, hit.point.y, 0);

        direction = sunPosition - transform.position;
        direction.z = 0;

        sunCenter = direction.normalized * radius + transform.position;

        transform.LookAt(sunCenter);
    }
}
