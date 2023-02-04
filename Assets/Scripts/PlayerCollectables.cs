using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerCollectable : MonoBehaviour
{
    private int gems = 0;
    //public int getGems { get {return gems;}];

    [SerializeField] private TMP_Text gemsText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectables"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            gems += 5;
            //Debug.Log("Gems: " + gems);
            gemsText.text = "Gems: " + gems;
        }

        //if (collision.gameObject.CompareTag("FinishFlag"))
        //{
        //    CompleteLevel();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Drops"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            gems += 5;
            gemsText.text = "Gems: " + gems;
        }
    }

    //private void CompleteLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    private void OnDisable()
    {
        PlayerPrefs.SetInt("PlayerLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("GemsCount", gems);
    }
}
