using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    [SerializeField] float distanceBeforeGrowing;
    [SerializeField] GameObject rootHolder;
    [SerializeField] List<GameObject> roots;

    //[SerializeField] string invisibleRoot_Tag;
    [SerializeField] float distanceToEarthSurface;

    [SerializeField] GameObject endGameCanvas;

    [SerializeField]
    float distanceFromCenter;

    [SerializeField]
    GameObject mushroom;

    private GameObject activeRoot;
    private GameObject rootGrowthPoint;

    const string state_young = "Young";
    const string state_old = "Old";
    private string rootState;

    [SerializeField] GameObject invisibleRoot;
    private float x1, y1, x2, y2, distance, angle;  //math parameters

    private int randomRoot;
    private int randomFlip;

    public GameParameters GameParameters;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRoot();
    }

    void InitializeRoot()
    {
        rootState = state_young;

        randomRoot = Random.Range(0, roots.Count);

        randomFlip = Random.Range(0, 2);

        for(int i = 0; i < roots.Count; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        activeRoot = gameObject.transform.GetChild(randomRoot).gameObject;

        activeRoot.SetActive(true);

        if(randomFlip == 0)
        {
            activeRoot.transform.Rotate(new Vector3(0, 180, 0));
        }

        rootGrowthPoint = activeRoot.transform.GetChild(0).gameObject;

        x1 = rootGrowthPoint.transform.position.x;
        y1 = rootGrowthPoint.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceForSpawning();
        CheckEndGame();
    }

    void CheckEndGame()
    {
        Vector3 startPoint = new Vector3(0, 0, 0);
        float earthRadius = GameParameters.EarthRadius;
        distanceFromCenter = Vector3.Distance(startPoint, rootGrowthPoint.transform.position);


        if (distanceFromCenter > earthRadius)
        {
            endGameCanvas.SetActive(true);
            //endGameCanvas.GetComponent<Canvas>().enabled = true;

            GameObject endShroom = Instantiate(mushroom, new Vector3(x1, y1, 0), Quaternion.identity);
            endShroom.transform.Rotate(new Vector3(0, 0, 90));
            enabled = false;
        }

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
