using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootHead : MonoBehaviour
{
    //private Vector3 sunCenter;
    //private Vector3 sunPosition;
    //private float radius = 3.0f;
    //private Vector3 direction;
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        FollowSun();
        //Sunfollow();  
    }
    /*void Sunfollow()
    {
        Ray ray = GameObject.FindGameObjectWithTag("Sun").GetComponent<Camera>().ScreenPointToRay(_sunSprite.position);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000.0f);

        sunPosition = new Vector3(hit.point.x, hit.point.y, 0);

        direction = sunPosition - transform.position;
        direction.z = 0;

        sunCenter = direction.normalized * radius + transform.position;

        transform.LookAt(sunCenter);
    }*/

    void FollowSun()
    {
        GameObject sun = GameObject.FindGameObjectWithTag("Sun");

        Vector3 directionSun = sun.transform.position - gameObject.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(directionSun.x, directionSun.y).normalized, 10.0f, LayerMask.GetMask("Sun"));

        Debug.DrawRay(transform.position, new Vector2(directionSun.x, directionSun.y).normalized * 100.0f, Color.red);
        

        if(hit.collider.gameObject.tag.Equals("Sun"))
        {
            Debug.Log(hit.collider.name);
            transform.position += moveSpeed * Time.deltaTime * directionSun.normalized;
        }

    }
}
