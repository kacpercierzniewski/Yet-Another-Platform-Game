using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {
    public GameObject wholeMenu;
    public GameObject mainMenu;
    public GameObject options;
    public GameObject levelMenu;
    public GameObject informationText;
    public AudioSource music;
    public AudioSource sfx;
    public Button[] buttons;
    int progress = 1;
    public Slider[] sliders;
    void Awake() {
        setMusicVolume(PlayerPrefs.GetFloat("music volume"));
        sliders[0].value = (PlayerPrefs.GetFloat("music volume"));
        setSfxVolume(PlayerPrefs.GetFloat("sfx volume"));
        sliders[1].value = (PlayerPrefs.GetFloat("sfx volume"));
        //      progress = PlayerPrefs.GetInt("Progress");
        if (progress == 2) {
            buttons[2].interactable = true;
        }
   

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!wholeMenu.activeSelf)
                wholeMenu.SetActive(true);
            else
                wholeMenu.SetActive(false);
        }
    }

    public void goToMainMenu() {
        mainMenu.SetActive(true);
        options.SetActive(false);
        levelMenu.SetActive(false);
    }
    public void goToStartMenuFromGame() {
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
            informationText.SetActive(true);
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
    IEnumerator Wait()
    {

        if (informationText.activeSelf)
        {
            buttons[1].interactable = false;
            yield return new WaitForSeconds(5f);
            informationText.SetActive(false);
            buttons[1].interactable = true;

        }

    }





}
