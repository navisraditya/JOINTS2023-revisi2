using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAbleHealth : MonoBehaviour
{
    int playerHP;
    [SerializeField] int maxHp;
    Animator animator;
    bool isDead = false;
    MoveableObject moveableObject;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        playerHP = maxHp;
        animator = GetComponent<Animator>();
        moveableObject = GetComponent<MoveableObject>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(playerHP <= 0 && isDead == false){
            isDead = true;
            animator.SetBool("isDestroy", true);
            moveableObject.enabled = false;
            Destroy(gameObject, 1.1f);
        }
        else if(maxHp / 3 >= playerHP){
            animator.SetBool("isPhase3", true);
        }
        else if(2 * maxHp / 3 >= playerHP){
            animator.SetBool("isPhase2", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(playerHP);
        if(other.gameObject.tag == "bullet"){
            if(other.gameObject.GetComponent<bulletController>().isPlayerShooting == false){
                playerHP--;
            }
        }
    }
}
