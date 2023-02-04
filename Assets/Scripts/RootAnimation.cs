using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAnimation : MonoBehaviour
{
    [SerializeField]
    Animation anim;
    [SerializeField]
    Transform parent;
    bool rootSpawned =false;
    float animTime = -1f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !rootSpawned && !anim.IsPlaying("root animation")){
            rootSpawned = true;

            parent.LookAt(new Vector3(Input.mousePosition.x - parent.transform.position.x * Screen.dpi, Input.mousePosition.y , 0));
            parent.up = parent.forward;

            /*
            if(Input.mousePosition.x / Screen.dpi < parent.position.x){
                parent.up = new Vector3(0 ,0 , -parent.up.z);
                Debug.Log("inverse");
            }
            
            /*
            Debug.Log("UP Vector: "+parent.up);
            Debug.Log("rotation: "+parent.rotation);
            Debug.Log("MousePosition: "+  Input.mousePosition.x / Screen.dpi);
            Debug.Log("parentLocation: "+ parent.localPosition.x);
            */


            anim["root animation"].speed = 1;
            anim.Play("root animation");
        }else if (Input.GetKeyDown(KeyCode.Mouse0) && rootSpawned && !anim.IsPlaying("root animation")){
            rootSpawned = false;
            anim["root animation"].speed = -1;

            if (animTime == -1)
                anim["root animation"].time = anim["root animation"].length;    
            else
                anim["root animation"].time = animTime;
            
            Debug.Log(animTime);
            animTime = -1;
            anim.Play("root animation");
        }
        if(anim["root animation"].speed == -1 && !anim.IsPlaying("root animation")){
            parent.rotation = new Quaternion(0,0,0,0);
        }

    }

    //private void OnTriggerEnter2D(Collider2D collider2D){
    //    Debug.Log(gameObject.name);
    //    Debug.Log(collider2D.name);
    //    anim.Stop("root animation");
    //    animTime = anim["root animation"].time;
    //}
}
