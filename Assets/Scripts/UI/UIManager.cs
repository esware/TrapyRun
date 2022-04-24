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
    private static int level = 1;

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
        level++;
    }

    void ActivePanel()
    {
        if (GameManager.Instance.IsFail)
        {
            gameOverPanel.SetActive(true);
        }
        else if (GameManager.Instance.IsWin)
        {
            finishPanel.SetActive(true);
        }
        else if (GameManager.Instance.IsStart)
        {
            startPanel.SetActive(false);
        }
        
    }

    private void Update()
    {
        ActivePanel();
        levelText.text = "Level "+level;
        
    }
}
