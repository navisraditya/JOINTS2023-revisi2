using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyWalkController : MonoBehaviour
{
    private Animator animator;
    // [SerializeField] PlayerController playerController;
    Vector2 moveDir;
    [SerializeField] AIPath aIPath;
    

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        moveDir = aIPath.desiredVelocity;
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
