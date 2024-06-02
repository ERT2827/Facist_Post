using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

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
    public GameObject holdText;
    public TextMeshProUGUI instructions;
    public TextMeshProUGUI lSelectText;
    public TextMeshProUGUI dSelectText;
    public TextMeshProUGUI rSelectText;
    public TextMeshProUGUI unscrText;
    private bool ticking;

    private void Start()
    {
        minigameSelect.Clear();
        minigameSelect.Add(0);
        minigameSelect.Add(1);
        minigameSelect.Add(2);


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
                            ticking = false;
                            Timer.value = Timer.maxValue;
                            Success += 1;
                            kbText.text = "";
                            RandomMinigame();
                        }
                    }
                }
            }

        }
    }


    public void TypingGame()
    {
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
        for (var i = 0; i < last; ++i)
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
        StartTimer(5);

    }

    public void HoldingGame()
    {

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

    }

    void RandomMinigame()
    {
        int rng = Random.Range(0, minigameSelect.Count);

        rng = minigameSelect[rng];

        switch (rng)
        {
            case 0:
                TypingGame();
                break;
            case 1:
                TypingGame();
                // PressingGame();
                break;
            case 2:
                TypingGame();
                //HoldingGame();
                break;
            default:
                break;
        }

        minigameSelect.Remove(rng);
    }
}
