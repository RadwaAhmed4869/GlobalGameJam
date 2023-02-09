using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject skillTree;
    [SerializeField] static bool GameIsPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        skillTree.SetActive(!skillTree.activeSelf);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    void Resume()
    {
        skillTree.SetActive(!skillTree.activeSelf);
        SkillTree.Instance.UpdatePointsLeftText();
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

}
