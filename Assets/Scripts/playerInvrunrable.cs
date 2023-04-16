using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInvrunrable : MonoBehaviour
{

    float invrunrableDuration = 0f;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        invrunrableDuration -= Time.deltaTime;
        if(invrunrableDuration <= 0){
            invrunrableDuration = 0;
        }

    }

    public bool isInvrunrable(){
        return invrunrableDuration > 0;
    }

    public void setInvrunrableDuration(float val){
        if(val > invrunrableDuration){
            invrunrableDuration = val;
        }
    }
}
