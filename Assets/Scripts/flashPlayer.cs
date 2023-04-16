using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashPlayer : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    [SerializeField] int numFlashClip;
    [SerializeField] float flashDuration; 
    [SerializeField] SpriteRenderer spriteRenderer;

    playerInvrunrable playerInvrunrable;
    float eachFlash;

    Material originalMaterial;
    Coroutine flashRoutine;

    // Start is called before the first frame update
    void Start()
    {
        playerInvrunrable = GetComponent<playerInvrunrable>();
        originalMaterial = spriteRenderer.material;
        if(numFlashClip <= 1){
            numFlashClip = 1;
        }
        eachFlash = (float)(flashDuration / numFlashClip);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void flashObject(){
       if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        playerInvrunrable.setInvrunrableDuration(flashDuration);
        for(int i = 0; i < numFlashClip; i++){
            spriteRenderer.material = flashMaterial;
            yield return new WaitForSeconds(eachFlash - 0.1f);
            spriteRenderer.material = originalMaterial;
            flashRoutine = null;
            yield return new WaitForSeconds(0.1f);
        }
        // yield return new WaitForSeconds(0.5f);
       
    }
}
