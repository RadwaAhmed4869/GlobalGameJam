using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSHield : MonoBehaviour
{
    public static bool shielded;
    [SerializeField] private GameObject Shield;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private int shieldTime;
    [SerializeField] private float shieldCoolDown = 5f;


    private int timer;
    private int counter = 0;
    private bool isNextClick;
    
    private void Start()
    {
        shielded = false;
        isNextClick = true;
        timer = shieldTime;
    }
    int testTime;
    private void Update()
    {
        //Debug.Log("animation "+anim["health"].time);
        //Debug.Log("Time.time    "+Time.time);
        counter++;
        //testTime = int.Parse(Time.time);
        CheckShield();
        if (counter == 2*60)
        {
            if (timer > 0 && shielded)
            {
                timer--;
                timerText.text = "Shield Timer: " + timer.ToString();
            }
            //Debug.Log(timer);
            //ShowTextTimer(timer);
            //counter = 0;
        }
        if(counter == 2*60) { counter = 0; }

        //anim["health"].time = 10f;
        //anim["health"].speed = 1;
        
    }
    void CheckShield()
    {
        if (Input.GetKeyDown(KeyCode.E) && !shielded && isNextClick)
        {
            Shield.SetActive(true);
            shielded = true;
            isNextClick = false;
            Invoke("NoShield", shieldTime);
            Invoke("CheckNextClick", shieldCoolDown+shieldTime);
            
        }

    }

    void CheckNextClick()
    {
        isNextClick = true;
    }
    void NoShield()
    {
        Shield.SetActive(false);
        shielded = false;
        timer = shieldTime;
        timerText.text = " ";
        
    }
    
}
