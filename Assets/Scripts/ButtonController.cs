using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject soundON;
    public GameObject soundOFF;
    
    void Awake(){
        if(AudioListener.volume > 0 ){
            soundON.SetActive(false);
            soundOFF.SetActive(true);

        }else {
            soundON.SetActive(true);
            soundOFF.SetActive(false);
        }

    }
    public void Play(){
        SceneManager.LoadScene("Game");
    }
    public void Quit(){
        Application.Quit();

    }
    public void SoundOFF(){
        AudioListener.volume = 0;
        soundOFF.SetActive(false);
        soundON.SetActive(true);

    }
    public void SoundON(){
        AudioListener.volume = 1;
        soundOFF.SetActive(true);
        soundON.SetActive(false);

    }
}
