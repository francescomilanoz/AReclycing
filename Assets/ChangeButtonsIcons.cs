using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeButtonsIcons : MonoBehaviour
{

    public Sprite volumeOffSprite;
    public Sprite volumeOnSprite;
    public Button volumeButton;

    public Sprite vibrationOffSprite;
    public Sprite vibrationOnSprite;
    public Button vibrationButton;

    public void changeVolumeButton()
    {
        volumeButton = GameObject.Find("ChangeAudio").GetComponent<Button>();
        if (volumeButton.image.sprite == volumeOnSprite)
            volumeButton.image.sprite = volumeOffSprite;
        else
        {
            volumeButton.image.sprite = volumeOnSprite;
        }
    }

    public void changeVibrationButton()
    {
        vibrationButton = GameObject.Find("ChangeVibration").GetComponent<Button>();
        if (vibrationButton.image.sprite == vibrationOnSprite)
            vibrationButton.image.sprite = vibrationOffSprite;
        else
        {
            vibrationButton.image.sprite = vibrationOnSprite;
        }
    }
}
