using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{ 
    public GameObject patrolPath;
    public GameObject[] pathPoints;
    [Tooltip("The amount of time the GameObject will wait once it reaches the next pathpoint in its path. Enter two numbers to create a random range.")]
    public float[] timeBetweenPathPoints = new float[2];
    public float moveSpeed;
    private float actualSpeed;
    public bool loopingPatrol;
    public bool inInteraction;

    // Start is called before the first frame update
    void Start()
    {
        int pathCount = patrolPath.transform.childCount;
        pathPoints = new GameObject[pathCount];

        for(int i = 0; i < pathCount; i++)
        {
            pathPoints[i] = patrolPath.transform.GetChild(i).gameObject;
        }

        StartCoroutine(Patrol());
    }

    // Update is called once per frame
    void Update()
    {
        

        if (inInteraction)
        {
            actualSpeed = 0;
        }
        else actualSpeed = moveSpeed;
    }

    public IEnumerator Patrol()
    {
        int patrolIndex = 0;

        while (true)
        {
            if (transform.position == pathPoints[patrolIndex].transform.position)
            {
                patrolIndex++;
                if (timeBetweenPathPoints[1] > timeBetweenPathPoints[0]) yield return new WaitForSeconds(Random.Range(timeBetweenPathPoints[0], timeBetweenPathPoints[1]));
                else yield return new WaitForSeconds(timeBetweenPathPoints[0]);
            }

            if (pathPoints.Length != 0 && patrolIndex < pathPoints.Length)
            {
                transform.position = Vector2.MoveTowards(transform.position, pathPoints[patrolIndex].transform.position, actualSpeed * Time.deltaTime);
            }

            if(patrolIndex >= pathPoints.Length)
            {
                if (loopingPatrol == true) patrolIndex = 0;
                else break;
            }
            yield return null;
        }
        yield return null;
    }
}
