using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bulletSpawn : MonoBehaviour
{

    public GameObject gun;
    public gunController gunController;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 30f;
    [SerializeField] weaponAmmo weaponAmmo;
    [SerializeField] Animator reloadAnimator;
    Transform gunEndPosition;
    float lastShot = 0;
    int gunType;
    handleAiming handleAiming;
    Coroutine reloadRoutine;
    Animator animator;
    [SerializeField] audioManager audioManager;
   
    private void OnEnable() {
        reloadRoutine = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        gunType = gunController.getGunIndex() % 3;
        handleAiming = GetComponent<handleAiming>();
    }

    // Update is called once per frame
    void Update()
    {
        if(reloadRoutine != null) return;
        lastShot -= Time.deltaTime;
        gunEndPosition = transform.Find("gunEndPosition");
        if(Input.GetKeyDown(KeyCode.R)){
            reloadRoutine = StartCoroutine(reloadGun());
        }
        else if(weaponAmmo.getAmmo(gunType) <= 0){
            reloadRoutine = StartCoroutine(reloadGun());
        }
        else{
            if(gunType == 0){
                if(Input.GetKeyDown(KeyCode.Mouse0) && lastShot <= 0){
                    audioManager.playShoot();
                    weaponAmmo.reduceAmmo(gunType);
                    lastShot = 0.2f;
                    Fire(handleAiming.angle);
                }
            }
            else if(gunType == 1){
                if(Input.GetKey(KeyCode.Mouse0) && lastShot <= 0){
                    audioManager.playShoot();
                    weaponAmmo.reduceAmmo(gunType);
                    lastShot = 0.2f;
                    Fire(handleAiming.angle);
                }
            }
            else if(gunType == 2){
                if(Input.GetKeyDown(KeyCode.Mouse0) && lastShot <= 0){
                    audioManager.playShoot();
                    weaponAmmo.reduceAmmo(gunType);
                    lastShot = 0.2f;       
                    Fire(handleAiming.angle, 0.25f);
                    Fire(handleAiming.angle + 15, 0.25f);
                    Fire(handleAiming.angle - 15, 0.25f);           
                }
            }
        }
    }
    void Fire(float angle, float duration = 1f){
        GameObject bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
        bulletSpawn.GetComponent<bulletController>().rotateBullet(Quaternion.Euler(0, 0, angle));
        bulletSpawn.GetComponent<bulletController>().isPlayerShooting = true; 
        bulletSpawn.GetComponent<bulletController>().setDuration(duration);
        bulletSpawn.GetComponent<bulletController>().setSpeed(bulletSpeed);
    }

    private IEnumerator reloadGun(){
        audioManager.playReload();
        reloadAnimator.SetTrigger("reload");
        yield return new WaitForSeconds(1.2f);
        weaponAmmo.reloadGun(gunType);
        reloadRoutine = null;
    }
}
