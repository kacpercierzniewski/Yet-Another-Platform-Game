using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject options;
    public GameObject levelMenu;
    public GameObject informationText;
    public AudioSource music;
    public AudioSource sfx;
    public Button[] buttons;
    float informationLifeTime=4;
    int progress = 1;
    public Slider[] sliders;
    void Awake() {
        setMusicVolume(PlayerPrefs.GetFloat("music volume"));
        sliders[0].value = (PlayerPrefs.GetFloat("music volume"));
        setSfxVolume(PlayerPrefs.GetFloat("sfx volume"));
        sliders[1].value = (PlayerPrefs.GetFloat("sfx volume"));
         progress = PlayerPrefs.GetInt("Progress");
        if (progress == 2) {
            buttons[2].interactable = true;
        }
   

    }
  

    private void Update()
    {
        if (informationText.activeSelf)
        {
            informationLifeTime -= Time.deltaTime;
            Debug.Log(informationLifeTime);

            if (informationLifeTime<0)
            {
                informationText.SetActive(false);
                buttons[1].interactable = true;
                informationLifeTime = 5;
            }
        }
    }
    public void goToMainMenu() {
        mainMenu.SetActive(true);
        options.SetActive(false);
        levelMenu.SetActive(false);
    }
    public void goToMainMenuFromGame() {
        SceneManager.LoadScene("Menu");
    }
    public void goToOptions() {
        options.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void loadLevel1() {
        SceneManager.LoadScene("level 1");
    }
    public void loadLevel2() {
        if (progress > 1)
            SceneManager.LoadScene("level 2");
        else
        {
            informationText.SetActive(true);
            buttons[1].interactable = false;
        }
    }
    public void quit() {
        Application.Quit();
    }
    public void setMusicVolume(float value) {
        music.volume = value;
        PlayerPrefs.SetFloat("music volume", value);
        PlayerPrefs.Save();


    }
    public void setSfxVolume(float value) {
        sfx.volume = value;
        PlayerPrefs.SetFloat("sfx volume", value);
        PlayerPrefs.Save();


    }
    public void goToLevelMenu()
    {
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);


    }






}
