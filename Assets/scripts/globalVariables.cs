using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVariables
{
    [SerializeField] public static bool UI_Open = false;
    [SerializeField] public static int money = 0;
    [SerializeField] public static int day = 1;

    [SerializeField] public static bool dogAlive = true;
    [SerializeField] public static int playerHunger = 100;
    [SerializeField] public static int playerHealth = 100;
    [SerializeField] public static int playerComfort = 100;

    [SerializeField] public static int dogHunger = 100;
    [SerializeField] public static string dogName;
    [SerializeField] public static int dogHealth = 100;
    [SerializeField] public static int dogComfort = 100;

    [SerializeField] public static int inflation = 1;
}
