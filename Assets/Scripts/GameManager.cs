using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Image winUI;
    [SerializeField] Image loseUI;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        winUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);

        if(Time.timeScale != 1)
            Time.timeScale = 1;
    }

    public void HideWinUI()
    {
        winUI.gameObject.SetActive(false);
    }

    public void ShowWinUI()
    {
        winUI.gameObject.SetActive(true);
    }

    public void HideLoseUI()
    {
        loseUI.gameObject.SetActive(false);
    }

    public void ShowLoseUI()
    {
        loseUI.gameObject.SetActive(true);
    }

}
