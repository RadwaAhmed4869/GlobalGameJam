using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public void pause()
    {
        Time.timeScale = 0;
    }
    public void unPause()
    {
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.GetFloat("musicVolume", 0.5f);
            Load();

        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        save();
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume" , volumeSlider.value);
    }


}
