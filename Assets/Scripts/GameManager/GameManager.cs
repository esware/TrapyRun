using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isFail = false;
    public bool isWin = false;
    public bool isStart = false;
    private void Awake()
    {
        isStart = false;
    }
}

public enum States
{
    Start,
    Fail,
    Win
}
