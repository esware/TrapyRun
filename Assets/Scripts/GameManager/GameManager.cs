using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isFail;
    private bool isWin;
    private bool isStart;
    public bool IsFail
    {
        get => isFail;
        set => isFail = value;
    }
    public bool IsWin
    {
        get => isWin;
        set => isWin = value;
    }

    public bool IsStart
    {
        get => isStart;
        set => isStart = value;
    }

    private void Awake()
    {
        isStart = false;
        isFail = false;
        isWin = false;
    }
}
