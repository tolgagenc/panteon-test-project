using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject startPnl;

    // Start is called before the first frame update
    void Start()
    {
        if ( !PlayerPrefs.HasKey("Level") )
        {
            PlayerPrefs.SetInt("Level", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startPnl.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void NextScene()
    {
        if (PlayerPrefs.GetInt("Level")+1 >= SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        }
        Prefrences.isFinish = false;
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
    public void Replay()
    {
        Prefrences.isFinish = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void startScene()
    {
        startPnl.SetActive(false);
    }
}
