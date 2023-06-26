using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerCollectables : MonoBehaviour
{
    private int points = 0;
    //public int getGems { get {return gems;}];

    //[SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Collectables"))
        {
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            points += 1;
            SkillTree.Instance.PointsLeft = points;
            //Debug.Log("Gems: " + gems);
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
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            //points += 1;
            Player.Instance.currentHealth += 10;
            //pointsText.text = "Gems: " + points;
        }
    }

    //private void CompleteLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    private void OnDisable()
    {
        PlayerPrefs.SetInt("PlayerLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("GemsCount", points);
    }
}
