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
    [SerializeField] private GameObject FinishPanel = null;
    [SerializeField] private Text levelText = null;
    public static int sceneCount = 0;
    static int level = 1;

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
        SceneManager.LoadScene(++sceneCount);
        level++;
        if(sceneCount == 2)
        {
            finishPanel.SetActive(true);
        }
    }

    void ActivePanel()
    {
        if (GameManager.Instance.isFail)
        {
            gameOverPanel.SetActive(true);
        }
        else if (GameManager.Instance.isWin)
        {
            finishPanel.SetActive(true);
        }
        else if (GameManager.Instance.isStart)
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
