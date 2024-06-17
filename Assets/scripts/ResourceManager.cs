using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int money;
    public Text moneyText;
    public int max = 100;
    public Text billsText;

    public int inflation = 1;

    //These are the variables that need to be saved

    public bool dogAlive = true;
    public int playerHunger;
    public int playerHealth;
    public int playerComfort;
    private bool playerFed;

    public int dogHunger;    
    public string dogName;
    public int dogHealth;
    public int dogComfort;
    private bool dogFed;

    //These do not need to be saved

    public Text dogNameText;
    public Text greetText;

    public Text playerHungerText;
    public Text playerHealthText;
    public Text playerComfortText;

    public Text dogHungerText;
    public Text dogHealthText;
    public Text dogComfortText;

    public GameObject playerMedButton;
    public GameObject dogMedButton;
    public GameObject panel;

    public Text buyFoodText;
    public Text buyDogFoodText;
    public Text buyHeatText;
    public Text buyPlayerMedText;
    public Text buyDogMedText;

    

    //Purchase functions
    public void BuyFood()
    {
        int cost = 100 * inflation;
        if (money > cost)
        {
            playerFed = true;
            money -= cost;
            playerHunger += 50;
            playerComfort += 20;
        }
    }

    public void BuyDogFood()
    {
        int cost = 80 * inflation;
        if (money > cost)
        {
            dogFed = true;
            money -= cost;
            dogHunger += 50;
            dogComfort += 20;
        }
    }

    public void BuyHeat()
    {
        int cost = 50 * inflation;
        if (money > cost)
        {
            money -= cost;
            playerComfort += 40;
            dogComfort += 40;
        }
    }

    public void BuyPlayerMed()
    {
        int cost = 60 * inflation;
        if (money > cost)
        {
            money -= cost;
            playerHealth += 50;
        }
    }

    public void BuyDogMed()
    {
        int cost = 60 * inflation;
        if (money > cost)
        {
            money -= cost;
            dogHealth += 50;
        }
    }

    //End of scene function 
    public void Finish()
    {
        if (playerFed == false)
        {
            playerHunger -= 40;
            playerComfort -= 20;
            dogComfort -= 20;
        }

        if (dogFed == false)
        {
            dogHunger -= 40;
            dogComfort -= 20;
            playerComfort -= 20;
        }

        PlayerSick();
        DogSick();
        playerComfort -= 35;
        dogComfort -= 35;

        globalVariables.money = money;

        globalVariables.dogAlive = dogAlive;
        globalVariables.playerHunger = playerHunger;
        globalVariables.playerHealth = playerHealth;
        globalVariables.playerComfort = playerComfort;
        globalVariables.dogName = dogName;
        globalVariables.dogHunger = dogHunger;
        globalVariables.dogHealth = dogHealth;
        globalVariables.dogComfort = dogComfort;

        globalVariables.inflation = inflation;
    }

    //Randomly controls when health drops, based on comfort level; guaranteed health drop at low comfort levels
    private void PlayerSick()
    {
        int value;
        value = Random.Range(playerComfort, 100);
        if (value <= 90 || playerComfort < 40)
        {
            playerHealth -= 30;
            playerComfort -= 20;
            dogComfort -= 20;
        }
    }

    private void DogSick()
    {
        int value;
        value = Random.Range(dogComfort, 100);
        if (value <= 90 || dogComfort < 40)
        {
            dogHealth -= 30;
            dogComfort -= 20;
            playerComfort -= 20;
        }
    }

    //Controls the text for the player's stats
    private void PlayerText()
    {
        if (playerHunger < max)
        {
            playerHungerText.text = "You feel hungry";
        }
        else if (playerHunger < 50)
        {
            playerHungerText.text = "You feel very hungry";
        }
        else if (playerHunger < 20)
        {
            playerHungerText.text = "You are starving";
        }
        else if (playerHunger <= 0 || playerHunger >= 80)
        {
            playerHungerText.gameObject.SetActive(false);
        }

        if (playerComfort < 80)
        {
            playerComfortText.text = "You feel cold";
        }
        else if (playerComfort < 40)
        {
            playerComfortText.text = "You feel very cold";
        }
        else if (playerComfort < 20)
        {
            playerComfortText.text = "You are freezing";
        }
        else if (playerComfort <= 0 || playerComfort >= 80)
        {
            playerComfortText.gameObject.SetActive(false);
        }

        if (playerHealth < 80)
        {
            playerHealthText.text = "You are sick";
        }
        else if (playerHealth < 40)
        {
            playerHealthText.text = "You are very sick";
        }
        else if (playerHealth < 20)
        {
            playerHealthText.text = "You are dying";
        }
        else if (playerHealth <= 0 || playerHealth >= 80)
        {
            playerHealthText.gameObject.SetActive(false);
        }
    }

    //Controls the text for the dog's stats
    private void DogText()
    {
        if (dogHunger < max)
        {
            dogHungerText.text = dogName + " is hungry";
        }
        else if (dogHunger < 50)
        {
            dogHungerText.text = dogName + " is very hungry";
        }
        else if (dogHunger < 20)
        {
            dogHungerText.text = dogName + " is starving";
        }
        else if (dogHunger <= 0 || dogHunger >= 80)
        {
            dogHungerText.gameObject.SetActive(false);
        }

        if (dogComfort < 80)
        {
            dogComfortText.text = dogName + " is cold";
        }
        else if (dogComfort < 40)
        {
            dogComfortText.text = dogName + " is very cold";
        }
        else if (dogComfort < 20)
        {
            dogComfortText.text = dogName + " is freezing";
        }
        else if (dogComfort <= 0 || dogComfort >= 80)
        {
            dogComfortText.gameObject.SetActive(false);
        }

        if (dogHealth < 80)
        {
            dogHealthText.text = dogName + " is sick";
        }
        else if (dogHealth < 40)
        {
            dogHealthText.text = dogName + " is very sick";
        }
        else if (dogHealth < 20)
        {
            dogHealthText.text = dogName + " is dying";
        }
        else if (dogHealth <= 0 || dogHealth >= 80)
        {
            dogHealthText.gameObject.SetActive(false);
        }
    }

    //Controls the Greeting text and other start of scene functions
    private void Greeting()
    {
        if (dogHealth == max)
        {
            greetText.text = dogName + " greets you enthusiastically as you enter";
        }else if (dogHealth < max)
        {
            greetText.text = dogName + " greets you as you enter";
        }else if (dogHealth < 80)
        {
            greetText.text = dogName + "'s tail wags as you enter";
        }else if (dogHealth < 40)
        {
            greetText.text = dogName + " whimpers as you enter";
        }else if (dogHealth < 20)
        {
            greetText.text = dogName + " barely moves as you enter";
        }else if (dogAlive == false)
        {
            greetText.text = dogName + " is dead";
        }

        if (playerHealth < 80)
        {
            playerMedButton.gameObject.SetActive(true);
        }else if (playerHealth >= 80)
        {
            playerMedButton.gameObject.SetActive(false);
        }

        if (dogHealth < 80)
        {
            dogMedButton.gameObject.SetActive(true);
        }
        else if (dogHealth >= 80)
        {
            dogMedButton.gameObject.SetActive(false);
        }

        billsText.text = "After taxes and rent, your total salary comes to §" + money;
    }

    private void Awake()
    {
        if (dogName == "")
        {
            panel.SetActive(true);
        }

        money = globalVariables.money;

        dogAlive = globalVariables.dogAlive;
        playerHunger = globalVariables.playerHunger;
        playerHealth = globalVariables.playerHealth;
        playerComfort = globalVariables.playerComfort;
        dogName = globalVariables.dogName;
        dogHunger = globalVariables.dogHunger;
        dogHealth = globalVariables.dogHealth;
        dogComfort = globalVariables.dogComfort;

        inflation = globalVariables.inflation;
    }

    void Start()
    {
        Greeting();
    }

    // Update is called once per frame
    void Update()
    {
        //keeps text fields up to date
        dogNameText.text = dogName;
        PlayerText();
        DogText();

        buyFoodText.text = "Buy Food: §" + 100 * inflation;
        buyDogFoodText.text = "Buy Dog Food: §" + 80 * inflation;
        buyHeatText.text = "Buy Heat: §" + 50 * inflation;
        buyPlayerMedText.text = "Buy Medicine: §" + 60 * inflation;
        buyDogMedText.text = "Buy Dog Medicine: §" + 60 * inflation;

        moneyText.text = "Remaining Balance: §" + money.ToString();
        
        //Unalives dog
        if (dogHealth <= 0)
        {
            dogAlive = false;
        }

        //Prevents runaway stat buildup
        if (dogHunger > max)
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

    //Sets the name of the dog to what the player types in text input
    public void ReadStringInput(string s)
    {
        dogName = s;
        Debug.Log(dogName);
    }
}
