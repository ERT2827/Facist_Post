using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Playerdata {
    // Currency
    public int slips = 0;

    // Resources
    public int playerHun = 100;
    public int playerHP = 100;
    public int playerCom = 100;
    public bool Alive = true;
    public string dName;
    public int dogHun = 100;
    public int dogHP = 100;
    public int dogCom = 100;

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
    
    public Playerdata(saveManager Player){
    
        slips = Player.slips;

        // Resources

        /*playerHun = Player.playerHun;
        playerHP = Player.playerHP;
        playerCom = Player.playerCom;
        Alive = Player.Alive;
        dName = Player.dName;
        dogHun = Player.dogHun;
        dogHP = Player.dogHP;
        dogCom = Player.dogCom;*/

        // Level unlocks
        level1Complete = Player.level1Complete;
        bestSlip1 = Player.bestSlip1; 

        level2Complete = Player.level2Complete;
        bestSlip1 = Player.bestSlip2;

        level3Complete = Player.level3Complete;
        bestSlip1 = Player.bestSlip3;

        level4Complete = Player.level4Complete;
        bestSlip1 = Player.bestSlip4;

        level5Complete = Player.level5Complete;
        bestSlip1 = Player.bestSlip5;

        level6Complete = Player.level6Complete;
        bestSlip1 = Player.bestSlip6;

        level7Complete = Player.level7Complete;
        bestSlip1 = Player.bestSlip7;


        replaying = Player.replaying;

        lastSlips = Player.lastSlips; //This tracks the number of slips from the end of the last level.

    }

    public Playerdata(ResourceManager resourceManager)
    {
        playerHun = resourceManager.playerHunger;
        playerHP = resourceManager.playerHealth;
        playerCom = resourceManager.playerComfort;
        Alive = resourceManager.dogAlive;
        dName = resourceManager.dogName;
        dogHun = resourceManager.dogHunger;
        dogHP = resourceManager.dogHealth;
        dogCom = resourceManager.dogComfort;
    }

}
