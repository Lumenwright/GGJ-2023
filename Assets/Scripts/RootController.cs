using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    [SerializeField] float distanceBeforeGrowing;
    [SerializeField] GameObject rootHolder;
    [SerializeField] GameObject rootGrowthPoint;

    const string state_young = "Young";
    const string state_old = "Old";
    private string rootState;

    private GameObject invisibleRoot;
    private string invisibleRoot_Tag = "Player";

    private float x1, y1, x2, y2, distance, angle;  //math parameters


    // Start is called before the first frame update
    void Start()
    {
        invisibleRoot = GameObject.FindGameObjectWithTag(invisibleRoot_Tag);
        rootState = state_young;
        x1 = rootGrowthPoint.transform.position.x;
        y1 = rootGrowthPoint.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceForSpawning();
    }

    void CheckDistanceForSpawning()
    {
        x2 = invisibleRoot.transform.position.x;
        y2 = invisibleRoot.transform.position.y;

        CalculateNewRootAngleRotation();  //calculate distance between invisible root and active root; and angle

        if (rootState.Equals(state_young) && distance > distanceBeforeGrowing)
        {
            SpawnRoot();
        }
    }

    void CalculateNewRootAngleRotation()
    {
        float tempAngle;

        float xDifferential = x2 - x1;
        float yDifferential = y2 - y1;

        distance = Mathf.Sqrt(Mathf.Pow(xDifferential, 2) + Mathf.Pow(yDifferential, 2));  //pythagorean theorem
        tempAngle = Mathf.Acos(Mathf.Abs(x2 - x1) / distance) * Mathf.Rad2Deg;

        if (yDifferential > 0)
        {
            angle = tempAngle;  //first quadrant

            if (xDifferential < 0)
            {
                angle = 180 - tempAngle;  //second quadrant
            }
        }
        if (yDifferential < 0)
        {
            angle = -tempAngle; //fourth quandrant

            if (xDifferential < 0)
            {
                angle = -180 + tempAngle;  //third quadrant
            }
        }
    }

    void SpawnRoot()
    {
        rootState = state_old;

        GameObject newRoot = Instantiate(rootHolder, new Vector3(x1, y1, 0), Quaternion.identity);
        newRoot.transform.Rotate(0, 0, angle);
    }
}
