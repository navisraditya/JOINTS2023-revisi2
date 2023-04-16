using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip winningCondition;
    [SerializeField] AudioClip inGameAudio;
    [SerializeField] AudioClip mainMenu;
    [SerializeField] AudioClip losingCondition;
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip reload;
    [SerializeField] AudioClip dead;
    [SerializeField] AudioClip dash;
    [SerializeField] AudioClip barbWire;
    AudioSource audioSource;
    [SerializeField] bool isLoop;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log(inGameAudio);
        Debug.Log("test");
        if(isLoop){
            audioSource.loop = true;
        }
        else{
            audioSource.loop = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playWinningCondtion() {
        audioSource.clip = winningCondition;
        audioSource.Play();

    }

    public void playInGameAudio() {
        audioSource.clip = inGameAudio;
        audioSource.Play();

    }

    public void playMainMenu() {
        audioSource.clip = mainMenu;
        audioSource.Play();

    }

    public void playLosingCondition() {
        audioSource.clip = losingCondition;
        audioSource.Play();
    }

    public void playShoot() {
        audioSource.PlayOneShot(shoot);
    }

    public void playReload() {
        audioSource.PlayOneShot(reload);
    }

    public void playDead() {
        audioSource.PlayOneShot(dead);
    }

    public void playDash() {
        audioSource.PlayOneShot(dash);
    }

    public void playBarbWire() {
        audioSource.PlayOneShot(barbWire);


    }
}
