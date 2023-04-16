using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float activateDist = 20f;
    public GameObject[] barbWire;
    public GameObject spawnLocation;
    public GameObject enemySpawner;
    bool isActivated = false;
    bool isDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform.Find("spawnLocation").gameObject;
        enemySpawner = transform.Find("enemySpawner").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActivated && Vector2.Distance(playerTransform.position, transform.position) <= activateDist){
            for(int i = 0; i < barbWire.Length; i++){
                barbWire[i].SetActive(true);
            }
            spawnLocation.SetActive(true);
            enemySpawner.SetActive(true);
            isActivated = true;
        }
        if(isActivated && !isDestroyed && enemySpawner.GetComponent<enemySpawner>().isFinishRunning()){
            isDestroyed = true;
            for(int i = 0; i < barbWire.Length; i++){
                barbWire[i].GetComponent<barbWireController>().waveDone();
            }
            Destroy(gameObject, 0.3f);
        }   
    }
}
