using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class storyStats : MonoBehaviour
{
    private gameManager gm;
    [SerializeField] private TMP_Text wealthInfo;
    [SerializeField] private TMP_Text supplyInfo;
    [SerializeField] private TMP_Text repInfo;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        UpdateStoryStats();


    }

    void UpdateStoryStats()
    {
        if (wealthInfo != null) wealthInfo.text = "Wealth: " + gm.wealth;
        if (supplyInfo != null) supplyInfo.text = "Supply: " + gm.supply;
        if (repInfo != null) repInfo.text = "Reputation: " + gm.reputation;
    }
}
