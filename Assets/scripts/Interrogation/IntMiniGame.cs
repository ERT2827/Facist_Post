using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.ComponentModel.Design;

public class IntMiniGame : MonoBehaviour
{
    public enum GameType
    {
        type,
        hold,
        press
    }

    public List<string> TypeList = new List<string>();

    public Slider Timer;
    public TextMeshProUGUI kbText;
    List<int> minigameSelect = new List<int>();
    public string typeReferece;
    public bool typing = false;
    public bool holding = false;
    public bool pressing = false;
    public int Success = 0;
    public bool holdTrigger;
    bool releaseTrigger;
    public GameObject holdText;
    public TextMeshProUGUI instructions;
    public TextMeshProUGUI lSelectText;
    public TextMeshProUGUI dSelectText;
    public TextMeshProUGUI rSelectText;
    public TextMeshProUGUI unscrText;
    private bool ticking;
    public GameObject typingObj;
    public GameObject pressObj;
    public string[] selections = new string[3];
    public char pressCorrect;

    private void Start()
    {
        minigameSelect.Clear();
        minigameSelect.Add(2);
        minigameSelect.Add(1);
        minigameSelect.Add(0);


        RandomMinigame();
    }

    private void Update()
    {
        if (typing && Timer.value > 0)
        {

            foreach (char c in Input.inputString)
            {
                if (c == '\b')
                {
                    if (kbText.text.Length != 0)
                    {
                        kbText.text = kbText.text.Substring(0, kbText.text.Length - 1);
                    }
                }
                else
                {
                    if (kbText.text.Length < 7)
                    {
                        kbText.text += c;

                        if (kbText.text.ToLower() == typeReferece.ToLower())
                        {
                            typing = false;
                            StopAllCoroutines();
                            Timer.value = Timer.maxValue;
                            Success += 1;
                            kbText.text = "";
                            RandomMinigame();
                        }
                    }
                }
            }

        }
        else if (typing)
        {
            StopAllCoroutines();
            RandomMinigame();
        }

        if (holding && holdTrigger)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartTimerR(Random.Range(3, 6));
            }
        }
        else if (holding && Input.GetKeyUp(KeyCode.Space))
        {
            Release(releaseTrigger);
        }

        if (pressing && Timer.value > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && TestPress('l'))
            {
                StopAllCoroutines();
                Success++;
                pressing = false;
                RandomMinigame();
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && TestPress('d'))
            {
                StopAllCoroutines();
                Success++;
                pressing = false;
                RandomMinigame();
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) && TestPress('r'))
            {
                StopAllCoroutines();
                Success++;
                pressing = false;
                RandomMinigame();
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) && !TestPress('r') || Input.GetKeyDown(KeyCode.LeftArrow) && !TestPress('l') ||
                Input.GetKeyUp(KeyCode.DownArrow) && !TestPress('d'))
            {
                StopAllCoroutines();
                pressing = false;
                RandomMinigame();
            }


        }

    }


    public void TypingGame()
    {
        holding = false;
        pressing = false;

        if (holdText.activeSelf == true) { holdText.SetActive(false); }
        if (pressObj.activeSelf == true) { pressObj.SetActive(false); }
        typingObj.SetActive(true);

        instructions.text = "UNSCRAMBLE the following text:";
        typeReferece = TypeList[Random.Range(0, TypeList.Count)].ToLower();
        unscrText.text = typeReferece.Substring(0, 1).ToUpper() + typeReferece.Substring(1, typeReferece.Length - 1).ToLower();
        List<char> scrText = new List<char>();
        foreach (char c in unscrText.text)
        {
            scrText.Add(c);
        }
        unscrText.text = "";
        var count = scrText.Count;
        var last = count - 1;
        for (var i = 0; i < last; i++)
        {
            var rng = Random.Range(i, count);
            var temp = scrText[i];
            scrText[i] = scrText[rng];
            scrText[rng] = temp;
        }
        foreach (char c in scrText)
        {
            unscrText.text += c;
        }

        typing = true;
        StartTimer(0.5f * scrText.Count);

    }

    public void HoldingGame()
    {
        pressing = false;
        typing = false;
        Timer.value = 0;
        holdText.SetActive(true);
        if (pressObj.activeSelf == true) { pressObj.SetActive(false); }
        if (typingObj.activeSelf == true) { typingObj.SetActive(false); }
        instructions.text = "Hold the SPACEBAR until the text turns green";
        holdTrigger = true;
        holding = true;
    }

    void StartTimer(float time)
    {
        Timer.maxValue = time;
        Timer.value = time;

        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        if (Timer.value == Timer.maxValue)
        {
            yield return new WaitForSeconds(1f);
        }

        ticking = true;

        while (Timer.value > 0 && ticking)
        {
            Timer.value -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    public void PressingGame()
    {
        holding = false;
        typing = false;

        if (holdText.activeSelf == true) { holdText.SetActive(false); }
        pressObj.SetActive(true);
        if (typingObj.activeSelf == true) { typingObj.SetActive(false); }
        instructions.text = "Press the ARROW KEY with the correct response";
        selections[0] = "Everything's dandy, sir.";
        selections[1] = "I'm a stone cold criminal.";
        selections[2] = "You won't take me alive!";

        for (var i = 0; i < 3; i++)
        {
            var rng = Random.Range(i, 3);
            var temp = selections[i];
            selections[i] = selections[rng];
            selections[rng] = temp;
        }

        for (var i = 0; i < 3; i++)
        {
            if (selections[i] == "Everything's dandy, sir.")
            {
                switch (i)
                {
                    case 0:
                        pressCorrect = 'l';
                        break;
                    case 1:
                        pressCorrect = 'd';
                        break;
                    case 2:
                        pressCorrect = 'r';
                        break;
                }
            }
        }

        lSelectText.text = selections[0];
        dSelectText.text = selections[1];
        rSelectText.text = selections[2];

        StartTimer(4);
        pressing = true;
    }

    void RandomMinigame()
    {
        if (minigameSelect.Count > 0)
        {
            int rng = Random.Range(0, minigameSelect.Count);

            rng = minigameSelect[rng];

            switch (rng)
            {
                case 0:
                    //HoldingGame();
                    TypingGame();
                    break;
                case 1:
                    //TypingGame();
                    //HoldingGame();
                    PressingGame();
                    break;
                case 2:
                    //TypingGame();
                    HoldingGame();
                    break;
                default:
                    break;
            }

            minigameSelect.Remove(rng);
        }
        else
        {
            if (Success >= 2)
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Lose");
            }
        }
    }

    void Release(bool ready)
    {
        StopAllCoroutines();
        Timer.value = Timer.maxValue;
        if (ready) { Success++; }
        holding = false;
        RandomMinigame();
    }

    void StartTimerR(float time)
    {
        holdTrigger = false;
        Timer.maxValue = time;
        Timer.value = 0;

        StartCoroutine(TickR());
    }

    IEnumerator TickR()
    {
        while (Timer.value < Timer.maxValue)
        {
            Timer.value += Time.deltaTime * 4;
            yield return new WaitForEndOfFrame();
        }

        holdText.GetComponent<TextMeshProUGUI>().color = Color.green;

        releaseTrigger = true;
        Timer.maxValue = 1.5f;
        Timer.value = Timer.maxValue;
        holdText.GetComponent<TextMeshProUGUI>().text = "LET GO";

        while (Timer.value > 0)
        {
            Timer.value -= Time.deltaTime * 250;
            holdText.transform.localScale = Vector3.one * 1.3f;
            yield return new WaitForSeconds(0.2f);
            Timer.value -= Time.deltaTime * 250;
            holdText.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(0.3f);
        }


        if (Timer.value <= 0)
        {
            releaseTrigger = false;
        }

    }

    bool TestPress(char btn)
    {
        if (btn == pressCorrect)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
