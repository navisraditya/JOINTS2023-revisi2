using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Animator animator;
    [SerializeField] audioManager audioManager;
    public PlayerInputActions playerInputActions;
    public Vector2 moveDir = Vector2.zero;
    private InputAction move;

    bool isDashing;
    float curDashCooldown;
    const float DEFAULT_DASH_SPEED = 100f;
    float dashSpeed;

    float dashCooldown = 1.5f;
    Vector3 dashDir;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable() {
        move = playerInputActions.Player.Move;
        move.Enable();  
    }
    
    private void OnDisable() {
        move.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curDashCooldown -= Time.deltaTime;
        if(isDashing == false){
            moveDir = move.ReadValue<Vector2>();
            if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){
                if(curDashCooldown < 0){
                    audioManager.playDash();
                    dashDir = moveDir;
                    animator.SetTrigger("isDashing");
                    gameObject.GetComponent<playerInvrunrable>().setInvrunrableDuration(0.15f);
                    isDashing = true;
                    curDashCooldown = dashCooldown;
                    dashSpeed = DEFAULT_DASH_SPEED;
                }
            }
        }
        else{
            float dashSpeedMultiplier = 5f;
            dashSpeed -= dashSpeed * dashSpeedMultiplier * Time.deltaTime;

            float dashSpeedMinimum = 25f;
            if(dashSpeed < dashSpeedMinimum){
                isDashing = false;
            }
        }
        
        
    }

    private void FixedUpdate() {
        if(!isDashing){
            rb.velocity = moveDir * moveSpeed;
        }
        else{
            rb.velocity = dashDir * dashSpeed;
        }
        

        // if(isDashing){
        //     Vector3 moveDir3d = new Vector3(moveDir.x, moveDir.y, 0);
        //     Vector3 dashPos = transform.position + moveDir3d * dashAmount;

        //     rb.MovePosition(dashPos);
        //     isDashing = false;
        // }
    }
}
