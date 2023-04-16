using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playEnvironment : MonoBehaviour
{
    [SerializeField] audioManager audioManager;
    bool isCek = false;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        if(!isCek){
            audioManager.playInGameAudio();
            isCek = true;
        }
    }
}
