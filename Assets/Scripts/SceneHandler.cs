using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private List<string> sceneHistory = new List<string>();  //running history of scenes
    public GameObject[] sceneArray;
    [SerializeField] public Animator transition;
    [SerializeField] float timeWait = 1f;
    bool isLoading = false;
    
    // AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        sceneArray = GameObject.FindGameObjectsWithTag("SceneHandler");
        // audioSource = GetComponent<AudioSource>();
        // memastikan hanya ada satu scene handler
        if(sceneArray.Length > 1 && sceneHistory.Count == 0){
            Destroy(gameObject);
            return;
        }
        // audioSource.volume = 0.1f;
        // audioSource.Play();
        Debug.Log("test\n");
        sceneHistory.Add(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(this.gameObject);
    }


    IEnumerator transitionScene(int newSceneIdx)
    {
        transition.SetTrigger("isCalled");
        yield return new WaitForSeconds(timeWait);
        SceneManager.LoadScene(newSceneIdx);
        sceneHistory.Add(SceneManager.GetSceneByBuildIndex(newSceneIdx).name);


    }

    IEnumerator transitionScene(string newScene)
    {
        isLoading = true;
        sceneHistory.Add(newScene);
        transition.SetTrigger("isCalled");
        yield return new WaitForSeconds(timeWait);
        SceneManager.LoadScene(newScene);
        isLoading = false;

    }
    public void LoadScene(string newScene)
    {

        if(isLoading) return;
        StartCoroutine(transitionScene(newScene));
    }

    public void LoadScene(int newSceneIdx){
        if(isLoading) return;
        StartCoroutine(transitionScene(newSceneIdx));    
    }
    void Update() {

    }

    public bool PreviousScene()
    {
        bool returnValue = false;
        if (sceneHistory.Count >= 2)  //Checking that we have actually switched scenes enough to go back to a previous scene
        {
            returnValue = true;
            sceneHistory.RemoveAt(sceneHistory.Count -1);
            SceneManager.LoadScene(sceneHistory[sceneHistory.Count -1]);
        }
 
        return returnValue;
    }

    public void loadLoseScene(){
        LoadScene("LoseScene");
    }
    public void loadWinScene(){
        LoadScene("WinScene");
    }

    public void restartButton(){
        PreviousScene();
    }

    public void restartFirstLevel(){
        LoadScene("Level 1");
    }

    public void restartMainMenu(){
        Debug.Log("main menu");
        LoadScene("MainMenu");
    }

    public void QuitGame(){
        Debug.Log("QUit Game");
        Application.Quit();
    }

    public void loadNextLevel(){
        int nextSceneIdx = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene(nextSceneIdx);
    }
}
