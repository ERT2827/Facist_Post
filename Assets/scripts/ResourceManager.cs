using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private bool dogAlive;
    public int money;
    public int max;
    
    public int playerHunger;
    public int playerHealth;
    public int playerComfort;
    private bool playerFed;

    private int dogHunger;    
    private string dogName;
    private int dogHealth;
    private int dogComfort;
    private bool dogFed;

    public void BuyFood(int cost)
    {
        if (money > cost)
        {
            playerFed = true;
            money -= cost;
            playerHunger += 100;
            playerComfort += 20;
        }
    }

    public void BuyDogFood(int cost)
    {
        if (money > cost)
        {
            dogFed = true;
            money -= cost;
            dogHunger += 100;
            dogComfort += 20;
        }
    }

    public void BuyHeat(int cost)
    {
        if (money > cost)
        {
            money -= cost;
            playerComfort += 40;
            dogComfort += 40;
        }
    }

    public void BuyPlayerMed(int cost)
    {
        if (money > cost)
        {
            money -= cost;
            playerHealth += 50;
        }
    }

    public void BuyDogMed(int cost)
    {
        if (money > cost)
        {
            money -= cost;
            dogHealth += 50;
        }
    }

    public void Finish()
    {
        if (playerFed == false)
        {
            playerHunger -= 40;
            playerComfort -= 10;
            dogComfort -= 10;
        }

        if (dogFed == false)
        {
            dogHunger -= 40;
            dogComfort -= 10;
            playerComfort -= 10;
        }

        PlayerSick();
        DogSick();
        playerComfort -= 20;
        dogComfort -= 20;
    }

    private void PlayerSick()
    {
        int value;
        value = Random.Range(playerComfort, 100);
        if (value <= 60 || playerComfort < 20)
        {
            playerHealth -= 40;
            playerComfort -= 10;
        }
    }

    private void DogSick()
    {
        int value;
        value = Random.Range(dogComfort, 100);
        if (value <= 60 || dogComfort < 20)
        {
            dogHealth -= 40;
            dogComfort -= 10;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dogHunger > max)
        {
            dogHunger = max;
        }
        if (playerHunger > max)
        {
            playerHunger = max;
        }
        if (dogHealth > max)
        {
            dogHealth= max;
        }
        if (playerHealth > max)
        {
            playerHealth = max;
        }
        if (dogComfort > max)
        {
            dogComfort= max;
        }
        if (playerComfort > max)
        {
            playerComfort = max;
        }
    }
}
