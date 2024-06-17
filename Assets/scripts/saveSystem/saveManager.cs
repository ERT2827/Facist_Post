using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveManager : MonoBehaviour
{
    [Header("Money")]
    
    public int slips = 0;

    [Header("Resources")]
    public int playerHun = 100;
    public int playerHP = 100;
    public int playerCom = 100;
    public bool Alive = true;
    public string dName;
    public int dogHun = 100;
    public int dogHP = 100;
    public int dogCom = 100;

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

    private void Awake()
    {
        loadGame();
    }

    private void Start() {
    }

    public void saveGame(){
        SaveData.SavePlayer(this);
    }

    public void loadGame(){
        Playerdata data = SaveData.LoadPlayer();
        
        slips = data.slips;

        // Resources

        playerHun = data.playerHun;
        playerHP = data.playerHP;
        playerCom = data.playerCom;
        Alive = data.Alive;
        dName = data.dName;
        dogHun = data.dogHun;
        dogHP = data.dogHP;
        dogCom = data.dogCom;

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

        playerHun = 100;
        playerHP = 100;
        playerCom = 100;
        Alive = true;
        dName = null;
        dogHun = 100;
        dogHP = 100;
        dogCom = 100;

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
    

        saveGame();
    }
}
