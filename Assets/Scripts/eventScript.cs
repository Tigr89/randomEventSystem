using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class eventScript : MonoBehaviour
{
    [Header("Event Information")]
    public string eventName;
    [TextArea(3, 10)]
    public string eventDescription;
    public int eventWeight;
    public bool repeatable;
    public bool hasRun;

    [Header("Event Actions")]
    public GameObject[] gameObjectsToActivate;
    public GameObject[] gameObjectsToInactivate;
    public TMP_Text eventTextArea;

    private void Start()
    {
        eventTextArea = GameObject.Find("EventTextArea").GetComponent<TMP_Text>();
        
    }

    private void OnEnable()
    {
        //ActivateEvent();
        UpdateEventText();
        hasRun = true;
        
    }

    //Did not end up using this one, but the purpose of it is to change things in the game world.
    public void ActivateEvent()
    {
        //Check if there are any game objects that should activate and then loop through them.
        if(gameObjectsToActivate.Length != 0)
        {
            for(int i = 0; i < gameObjectsToActivate.Length; i++)
            {
                gameObjectsToActivate[i].SetActive(true);
            }
        }

        //Same as above but for deactivation!
        if(gameObjectsToInactivate.Length != 0)
        {
            for(int i = 0; i < gameObjectsToInactivate.Length; i++)
            {
                gameObjectsToInactivate[i].SetActive(false);
            }
        }


    }

    public void UpdateEventText()
    {
        if(eventTextArea != null) eventTextArea.text = eventDescription;
    }

    public bool CheckConditions()
    {
        if (eventWeight == 0) return true;


        return false;
    }
}
