using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgStuff : MonoBehaviour
{
    [Header("Money")]
    
    public int slips = 0;

    [Header("Level Unlocks")]

    // Level unlocks
    public bool level1Complete = false;
    public int bestSlip1 = 0; //This will save the best score that you've gotten on a given day to go back in a replay.

    public bool level2Complete = false;
    public int bestSlip2 = 0;
    
    public bool level3Complete = false;
    public int bestSlip3 = 0;
    
    public bool level4Complete = false;
    public int bestSlip4 = 0;
    
    public bool level5Complete = false;
    public int bestSlip5 = 0;

    public bool level6Complete = false;
    public int bestSlip6 = 0;

    public bool level7Complete = false;
    public int bestSlip7 = 0;

    /* This is for determining whether players are
    replaying the level or continuing from a previous one. */

    public bool replaying = false;

    public int lastSlips = 0; //This tracks the number of slips from the end of the last level.

    private void Start() {
    }

    public void saveUs(){
        SaveData.SavePlayer(this);
    }

    public void loadUs(){
        Playerdata data = SaveData.LoadPlayer();
        
        slips = data.slips;

        // Level unlocks
        level1Complete = data.level1Complete;
        bestSlip1 = data.bestSlip1; 

        level2Complete = data.level2Complete;
        bestSlip1 = data.bestSlip2;

        level3Complete = data.level3Complete;
        bestSlip1 = data.bestSlip3;

        level4Complete = data.level4Complete;
        bestSlip1 = data.bestSlip4;

        level5Complete = data.level5Complete;
        bestSlip1 = data.bestSlip5;

        level6Complete = data.level6Complete;
        bestSlip1 = data.bestSlip6;

        level7Complete = data.level7Complete;
        bestSlip1 = data.bestSlip7;


        replaying = data.replaying;

        lastSlips = data.lastSlips; //This tracks the number of slips from the end of the last level.

    }

    public void resetprogress(){
        slips = 0;

        level1Complete = false;
        bestSlip1 = 0; 

        level2Complete = false;
        bestSlip2 = 0;
    
        level3Complete = false;
        bestSlip3 = 0;
    
        level4Complete = false;
        bestSlip4 = 0;
    
        level5Complete = false;
        bestSlip5 = 0;

        level6Complete = false;
        bestSlip6 = 0;

        level7Complete = false;
        bestSlip7 = 0;

    /* This is for determining whether players are
    replaying the level or continuing from a previous one. */

        replaying = false;

        lastSlips = 0; //This tracks the number of slips from the end of the last level.
    

        saveUs();
    }
}
