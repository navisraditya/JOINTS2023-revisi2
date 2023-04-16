using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject sceneObject;
    SceneHandler sceneHandler;
    void Start()
    {
        sceneObject = GameObject.FindWithTag("SceneHandler");
        sceneHandler = sceneObject.GetComponent<SceneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void nextScene(){
        sceneHandler.loadNextLevel();
    }

    public void loadMainMenu(){
        Debug.Log("masuk main menu");
        sceneHandler.restartMainMenu();
    }

    public void QuitGame(){
        sceneHandler.QuitGame();
    }

    public void loadPreviousScene(){
        sceneHandler.PreviousScene();
    }
}
