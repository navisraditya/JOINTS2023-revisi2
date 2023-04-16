using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gunController : MonoBehaviour
{
    public PlayerInputActions playerInputActions;
    private InputAction changeColor; 
    [SerializeField] GameObject upperBody;
    facingController facingController;

    int curColor = 0;
    int curGun = 0;
    int selectedGun = 0;
    bool[] haveGun = {true, true, true};

    private void Awake() {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable() {
        changeColor = playerInputActions.WeaponChange.changeColor;
        changeColor.Enable();
    }
    private void OnDisable() {

        changeColor.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        facingController = upperBody.GetComponent<facingController>();
    }

    // Update is called once per frame
    void Update()
    {   
        int bfrGun = getGunIndex();
        float mouseY = changeColor.ReadValue<float>();
        if(mouseY > 0f){
            curColor += 1;
            curColor %= 3;
        }
        else if(mouseY < 0f){
            curColor -= 1;
            curColor = (curColor + 3) % 3;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            curGun = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && haveGun[1]){
            curGun = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && haveGun[2]){
            curGun = 2;
        }
        selectedGun = getGunIndex();
        if(selectedGun != bfrGun){
            changeGun();
        }

    }

    public int getGunIndex(){
        return curColor * 3 + curGun;
    }

    public void changeGun(){
        int cnt = 0;
        foreach(Transform weapon in transform){
            if(cnt == selectedGun){
                weapon.gameObject.SetActive(true);
                facingController.aimDirection = weapon.gameObject.GetComponent<handleAiming>();
            }
            else{
                weapon.gameObject.SetActive(false);
            }
            cnt++;
        }
    }
}
