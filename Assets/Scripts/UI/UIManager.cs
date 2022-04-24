using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour ,IUIManager
{
    [SerializeField] private GameObject gameOverPanel = null;
    [SerializeField] private GameObject finishPanel = null;
    [SerializeField] private GameObject startPanel = null;
    [SerializeField] private GameObject EndGamePanel = null;
    [SerializeField] private Text levelText = null;
    public static int level = 0;
    private int levelCounter=1;

    private void Start()
    {
        startPanel.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ResetGameButton()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(level);
    }

    void ActivePanel()
    {
        if (GameManager.Instance.IsFail)
        {
            gameOverPanel.SetActive(true);
        }
        else if (GameManager.Instance.IsWin)
        {
            if (level ==2)
            {
                EndGamePanel.SetActive(true);
            }
            else
            {
                finishPanel.SetActive(true);
            }
        }
        else if (GameManager.Instance.IsStart)
        {
            startPanel.SetActive(false);
        }
        
    }

    private void Update()
    {
        ActivePanel();
        levelCounter = level + 1;
        levelText.text = "Level "+levelCounter;

    }
}
