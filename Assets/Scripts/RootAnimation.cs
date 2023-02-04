using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject IgnoredEdge;
    [SerializeField]
    Animation anim;
    [SerializeField]
    Transform parent;
    [SerializeField]
    GameObject player;

    bool rootSpawned =false;
    float animTime = -1;

    Camera mainCamera;
    Vector3 mousePos;
    int RootDamage = 45;

    float timer = -1f;
    void Start(){
         mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if(timer>0){
            timer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !rootSpawned && !anim.IsPlaying("root animation")){
            parent.position = new Vector3(player.transform.position.x , parent.position.y , parent.position.z);
            rootSpawned = true;
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            parent.LookAt(new Vector3(mousePos.x , mousePos.y , 0));
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
            timer = 1f;
        }else if (timer <= 0 && rootSpawned && !anim.IsPlaying("root animation")){
            rootSpawned = false;
            anim["root animation"].speed = -0.5f;

            anim["root animation"].time = anim["root animation"].length;    
            if (animTime != -1){
                anim["root animation"].time = animTime;
                animTime = -1;
            }


            anim.Play("root animation");
        }
        if(anim["root animation"].speed == -1 && !anim.IsPlaying("root animation")){
            parent.rotation = new Quaternion(0,0,0,0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        Debug.Log(gameObject.name);
        Debug.Log(collider2D.name);
        if(anim["root animation"].speed == 1  && !collider2D.gameObject.Equals(IgnoredEdge)  && collider2D.tag == "ScreenEdge"){
            animTime = anim["root animation"].time;
            anim.Stop("root animation");
        }
        //Do Damage To Enemey
        if(collider2D.tag == "Enemy"){
            //collider2D.GetComponent<Enemey>().Damaged(RootDamage);
        }



    }
}
