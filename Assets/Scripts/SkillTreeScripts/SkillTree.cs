using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    [SerializeField] List<Skill> skills;
    [SerializeField] List<Skill> skillsUnlockedByDefault;
    [SerializeField] int pointsLeft = 10;
    [SerializeField] TMP_Text pointsLeftText;
    [SerializeField] SkillTree skillTree;

    private static SkillTree instance;
    public int PointsLeft   //Property
    { 
        get => pointsLeft;
        set
        {
            pointsLeft = value;
            UpdatePointsLeftText();
        }
    }

    public static SkillTree Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        //Debug.Log("AWAKE FROM SKILLTREE");
        this.gameObject.SetActive(false);
        Instance ??= this;
    }

    void Start()
    {
        Init();
    }

    private void Init()
    {
        UpdatePointsLeftText();
        // Lock all the skills when the game starts
        foreach (Skill skill in skills)
        {
            skill.Lock();
        }

        // Unlock default skills
        foreach (Skill skill in skillsUnlockedByDefault)
        {
            skill.Unlock();
        }
    }

    public void UpdatePointsLeftText()
    {
        pointsLeftText.text = PointsLeft.ToString();
    }

    public void TryLearnSkill(Skill skill)
    {
        if (PointsLeft > 0 && skill.Click()) 
        {
            PointsLeft--;
        }
        if (PointsLeft == 0) 
        {
            foreach (Skill s in skills) 
            {
                if (s.CurrentCount == 0)
                {
                    s.Lock();
                }
            }
        }
    }

}
