using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    public Text timeText;

    [SerializeField]
    private Package package;
    public Package Package { get => package; }

    private void Update()
    {
        if (package == null)
        {
            Destroy(gameObject);
        }

        timeText.text = "Deliver By: " + Package.timerText.text;
    }
}
