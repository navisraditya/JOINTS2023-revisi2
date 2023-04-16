using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    GameObject sceneObject;
    SceneHandler sceneHandler;
    // Start is called before the first frame update
    void Start()
    {
        sceneObject = GameObject.FindWithTag("SceneHandler");
        sceneHandler = sceneObject.GetComponent<SceneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.GetKeyDown(KeyCode.F)){
            sceneHandler.loadNextLevel();
        }
        if(Input.GetKey(KeyCode.F)){
            sceneHandler.loadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(Input.GetKeyDown(KeyCode.F)){
            sceneHandler.loadNextLevel();
        }
        if(Input.GetKey(KeyCode.F)){
            sceneHandler.loadNextLevel();
        }
    }
}
