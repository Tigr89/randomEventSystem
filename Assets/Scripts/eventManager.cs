using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    public GameObject[] eventList;
    private gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the GameManager
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();

        //Populate the eventlist with all the events
        eventList = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            eventList[i] = transform.GetChild(i).gameObject;
            eventList[i].GetComponent<eventScript>().hasRun = false; //Have to run this code because the objects are active by default, and so they run their "OnEnable()" function.
            eventList[i].SetActive(false);
        }
    }

    public void EventRoller()
    {
        //Don't fire the function if the eventList is empty!
        if (eventList.Length == 0) return;
        ResetEvents();

        //Filter for highest event weight
        int targetWeight = 0;
        foreach(GameObject eventInstance in eventList)
        {
            //Check whether the conditions in the event are met. If true, set the event weight.
            if (eventInstance.GetComponent<eventScript>().CheckConditions())
            {
                int weight = eventInstance.GetComponent<eventScript>().eventWeight;
                if (weight > targetWeight) targetWeight = weight;
            }
        }

        //Filter events based on their event weight
        List<GameObject> validEvents = new List<GameObject>();
        while (validEvents.Count == 0)
        {
            foreach (GameObject eventInstance in eventList)
            {
                eventScript script = eventInstance.GetComponent<eventScript>();

                //First check if the weight matches the highest value and then check whether or not the event can repeat or not. 
                if (script.eventWeight == targetWeight && (script.repeatable == true || script.hasRun == false))
                {
                    validEvents.Add(eventInstance);
                }
            }

            //If 0 events are stored, lower the targetWeight and do the forloop again!
            if (validEvents.Count == 0) targetWeight--;
        }
        
        

        //Pick a random event!
        GameObject selectedEvent = validEvents[Random.Range(0, validEvents.Count)];
        selectedEvent.SetActive(true);
    }

    public void ResetEvents()
    {
        for(int i = 0; i < eventList.Length; i++)
        {
            eventList[i].SetActive(false);
        }
    }
}
