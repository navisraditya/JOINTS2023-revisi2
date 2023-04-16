using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacingController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] EnemyHandleAiming aimDirection;
    Vector2 moveDir;
    float angle = 0;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        // todo cari movedir
        moveDir = Vector2.zero;
        angle = aimDirection.angle;
    }
    // Update is called once per frame
    private void FixedUpdate() {
        if(moveDir == Vector2.zero){
            animator.SetBool("isWalking", false);
        }
        else{
            animator.SetBool("isWalking", true);
        }

        if(angle < 0){
            angle = 360 + angle;
        }

        if(angle >= 300 || angle <= 30){
            animator.SetFloat("facing", 2f);
         }
        else if(angle >= 30 && angle <= 120){
            animator.SetFloat("facing", 1f);
        }
        else if(angle >= 120 && angle <= 210){
            animator.SetFloat("facing", 4f);
        }
        else if(angle >= 210 && angle <= 300){
            animator.SetFloat("facing", 3f);

        }
    }
}
