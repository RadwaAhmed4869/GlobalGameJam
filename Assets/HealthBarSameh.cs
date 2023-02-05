using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSameh : MonoBehaviour
{
    //public float maxHealth = 100f;
    //public float currentHealth = 50f;

    //[SerializeField] SpriteMask spriteMask;
    [SerializeField] Transform maskTransform;

    void Start()
    {
        //spriteMask = GetComponent<SpriteMask>();
        maskTransform = maskTransform.transform;
    }

    void Update()
    {
        float fillAmount = Player.Instance.currentHealth / Player.Instance.maxHealth;
        maskTransform.localScale = new Vector2(1f, 1 - fillAmount);
        //Debug.Log(fillAmount);
    }
}
