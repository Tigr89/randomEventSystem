using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    [Header("Setup start variables")]
    public TMP_InputField wealthInput;  private int _wealth;
    public TMP_InputField supplyInput;  private int _supply;
    public TMP_InputField repInput;     private int _rep;

    public Button startButton;
    private gameManager gm;

    public Button testEventButton;

    // Start is called before the first frame update
    void Start()
    {
        if (startButton != null) startButton.onClick.AddListener(StartGame);
        if (testEventButton != null) testEventButton.onClick.AddListener(TriggerEventRoller);
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    void StartGame()
    {
        //Call on function to check that the player has input correct
        if (UpdateVariables())
        {
            gm.ChangeScene();
        }
        else Debug.Log("Error! Couldn't start the game.");
    }

    void TriggerEventRoller()
    {
        eventManager em = GameObject.Find("EventManager").GetComponent<eventManager>();
        if(em != null) em.EventRoller();
    }

    bool UpdateVariables()
    {
        //Check whether the input in the inputfields are integers. If all return true, update the variables and then launch the game!
        if (int.TryParse(wealthInput.text, out _wealth) && int.TryParse(supplyInput.text, out _supply) && int.TryParse(repInput.text, out _rep)){

            //Supply should be represented by a 0-100 percentage. 
            if (_supply > 100) _supply = 100;
            if (_supply < 0) _supply = 0;

            //Reputation will allow for a maximum value of 100 and a minimum value of -100.
            if (_rep > 0 && _rep > 100) _rep = 100;
            if (_rep < 0 && _rep < -100) _rep = -100;

            //Update the variables in the GameMaster.
            gm.wealth = _wealth; 
            gm.supply = _supply;
            gm.reputation = _rep;
            return true;
        }
        else
        {
            Debug.Log("Error! One or more invalid inputs in the inputfields.");
            return false;
        }
    }
}
