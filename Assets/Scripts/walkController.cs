using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] PlayerController playerController;
    Vector2 moveDir;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        moveDir = playerController.moveDir;
    }
    // Update is called once per frame
    private void FixedUpdate() {
        if(moveDir == Vector2.zero){
            animator.SetBool("isWalking", false);
        }
        else{
            animator.SetBool("isWalking", true);
            animator.SetFloat("horizontalMovement", moveDir.x);
            animator.SetFloat("verticalMovement", moveDir.y);
        }
    }
}
