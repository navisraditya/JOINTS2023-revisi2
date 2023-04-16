using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barbWireController : MonoBehaviour
{
    Animator animatorWire;
    Animator animatorCrack;
    // Start is called before the first frame update
    void Start()
    {
        animatorWire = transform.Find("wire").gameObject.GetComponent<Animator>();
        animatorCrack = transform.Find("crack").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            waveDone();
        }
    }

    public void waveDone(){
        animatorWire.SetTrigger("isDestroy");
        animatorCrack.SetTrigger("isDestroy");
        Destroy(gameObject, 0.4f);
    }
}
