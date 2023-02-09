using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColletableScript : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    private int score;

    private string COIN_TAG = "coin";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(COIN_TAG))
        {
            score++;
            ScoreText.text="Score: "+score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
