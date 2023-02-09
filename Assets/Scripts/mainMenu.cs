using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public string FirstLevel;
    public string Level1;
    public string Level2;
    public string Level3;
    public GameObject optionsScreen;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(FirstLevel);
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene(Level1);

    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene(Level2);

    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene(Level3);

    }


    public void openOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void closeOptions()
    {

        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
