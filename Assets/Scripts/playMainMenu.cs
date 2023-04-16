using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMainMenu : MonoBehaviour
{

    AudioSource audioSource;
    bool isCek = false;
    // Start is called before the first frame update
    void Start()
    {   
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        if(!isCek){
            audioSource.Play();
            isCek = true;
        }
    }
}
