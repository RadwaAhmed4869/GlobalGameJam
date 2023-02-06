using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDamage : MonoBehaviour
{
    public bool isBossDie;
    void Update()
    {
        DamageCage();
    }

    void DamageCage()
    {
        if (isBossDie)
        {
            this.transform.localPosition += new Vector3(0,-1*Time.deltaTime, 0);
            if(this.transform.localScale.x>0 && this.transform.localScale.y > 0 && this.transform.localScale.z > 0)
            {
                this.transform.localScale += new Vector3(-0.5f * Time.deltaTime, -0.5f * Time.deltaTime, -0.5f * Time.deltaTime);
            }
        }
    }
}
