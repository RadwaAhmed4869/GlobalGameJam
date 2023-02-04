using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    Image image;
    Button btn;
    [SerializeField] TMP_Text countTxt;
    [SerializeField] int maxCount;
    [SerializeField] int currentCount;
    [SerializeField] bool unlocked;
    [SerializeField] Skill childSkill;

    [SerializeField] GameObject arrowImage = null;
    [SerializeField][Range(0f, 0.25f)] float Buff1 = 0.2f;
    [SerializeField][Range(0f, 0.25f)] float Buff2 = 0.2f;
    [SerializeField][Range(0f, 0.25f)] float Buff3 = 0.2f;

    public int CurrentCount { get => currentCount; set => currentCount = value; }

    private void Awake()
    {
        image = GetComponent<Image>();
        btn = GetComponent<Button>();

        countTxt.text = $"{CurrentCount} / {maxCount}";

        if (unlocked)
        {
            Unlock();
        }
    }
    public void Lock()
    {
        Color clr = new Color(0.25f, 0.25f, 0.25f);
        btn.interactable = false;
        image.color = clr;
        countTxt.color = clr;
        if (arrowImage != null)
        {
            arrowImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.15f);
        }
        if (countTxt != null)
        {
            countTxt.color = clr;
        }
    }

    public void Unlock()
    {
        btn.interactable = true;
        image.color = Color.white;
        countTxt.color = Color.white;
        unlocked = true;
        if (arrowImage != null) 
        {
            arrowImage.GetComponent<Image>().color = Color.white;
        }
        if (countTxt != null) 
        {
            countTxt.color = Color.white;
        }
    }
    public bool Click()
    {
        if (CurrentCount < maxCount && IsUnlocked()) 
        {
            CurrentCount++;
            countTxt.text = $"{CurrentCount} / {maxCount}";

            if(CurrentCount == maxCount)
            {
                if(childSkill != null)
                {
                    childSkill.Unlock();
                    AquireBuff();
                }
            }
            return true;
        }
        return false;
    }
    public bool IsUnlocked() => unlocked;

    public void AquireBuff()
    {
        Debug.Log("Buff " + gameObject.name + " Aquired");
        Debug.Log(Buff1);
        Debug.Log(Buff2);
        Debug.Log(Buff3);
        //TODO
        
    }
}
