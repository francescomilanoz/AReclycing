using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameUIcontroller : MonoBehaviour
{
    bool menuflag;
    public bool isAudioActive;
    public bool isVibrationActive;

    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite vibrationOn;
    public Sprite vibrationOff;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        menuflag = true;
        isAudioActive = true;
        isVibrationActive = true;
        panel.SetActive(menuflag);

    }
    public void EXITtoHome()
    {
        SceneManager.LoadScene("HOMEui");
        Time.timeScale = 1;
    }
    public void Arcade()
    {
        SceneManager.LoadScene("ARCADE");

    }
    public void PRACTICE()
    {
        SceneManager.LoadScene("PRACTICE");

    }
    public void exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        menuflag = !menuflag;
        panel.SetActive(menuflag);
        if(menuflag)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResetGame()
    {
        GameObject.Find("ManoMotionCanvas").GetComponent<ManomotionUIManagment>().secondsRemaining = 120;
        ManomotionManager.Instance.SetCurrentPoints(0);
        StartCoroutine(GameObject.Find("ManoMotionCanvas").GetComponent<ManomotionUIManagment>().UpdateRemainingTime());
        
    }

    public void changeAudio()
    {
        isAudioActive = !isAudioActive;
        //GameObject.Find("ChangeAudio").GetComponent<Image>().image = soundOn;
    }

    public void changeVibration()
    {
        isVibrationActive = !isVibrationActive;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
