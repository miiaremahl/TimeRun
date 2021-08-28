using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject SettingBar;
    public GameObject PlayInterface;
    public GameObject QuitInterface;
    public GameObject GameTitle;
    public TMP_Text SettingText;



    private bool showingSettingMenu;


    public UnityEngine.XR.Interaction.Toolkit.XRController xrController;
    public UnityEngine.XR.Interaction.Toolkit.XRController xrController2;

    public AudioSource StartaudioData;


    void Start()
    {
        showingSettingMenu = false;
    }
    public void EnableSettingMenu()
    {
        xrController2.SendHapticImpulse(1.0f, 0.1f);
        xrController.SendHapticImpulse(1.0f, 0.1f);
        GameTitle.SetActive(false);
        QuitInterface.SetActive(false);
        PlayInterface.SetActive(false);
        SettingBar.SetActive(true);
        SettingText.text = "Menu";
    }

    public void ChangeSettingMenu()
    {
        if (showingSettingMenu)
        {
            DisableSettingMenu();
            showingSettingMenu = false;
        }
        else
        {
            showingSettingMenu = true;
            EnableSettingMenu();
        }
    }

    public void DisableSettingMenu()
    {
        xrController2.SendHapticImpulse(1.0f, 0.1f);
        xrController.SendHapticImpulse(1.0f, 0.1f);
        GameTitle.SetActive(true);
        QuitInterface.SetActive(true);
        PlayInterface.SetActive(true);
        SettingBar.SetActive(false);
        SettingText.text = "Settings";
    }


    public void StartGame()
    {
        xrController2.SendHapticImpulse(1.0f, 0.1f);
        xrController.SendHapticImpulse(1.0f, 0.1f);
        StartaudioData.Play(0);
        StartCoroutine(WaitToSwitch());
    }

    public void QuitGame()
    {
        xrController2.SendHapticImpulse(1.0f, 0.1f);
        xrController.SendHapticImpulse(1.0f, 0.1f);
        Debug.Log("quitting");
    }


    IEnumerator WaitToSwitch()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
