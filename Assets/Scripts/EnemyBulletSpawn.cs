using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBulletSpawn : MonoBehaviour
{
    public GameObject gun;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 30f;
    [SerializeField] weaponAmmo weaponAmmo;
    [SerializeField] Animator reloadAnimator;


    Transform gunEndPosition;
    float lastShot = 0;
    [SerializeField] int gunType;
    EnemyHandleAiming enemyHandleAiming;
    [SerializeField] AIPath aIPath;
    Coroutine reloadRoutine;
    
    private void OnEnable() {
        reloadRoutine = null;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHandleAiming = GetComponent<EnemyHandleAiming>();
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
        else if(aIPath.reachedDestination){
                if(gunType == 0){
                    if(lastShot <= 0){
                        weaponAmmo.reduceAmmo(gunType);
                        lastShot = 0.4f;
                        Fire(enemyHandleAiming.angle);
                    }
                }
                else if(gunType == 1){
                    if(lastShot <= 0){
                        weaponAmmo.reduceAmmo(gunType);
                        lastShot = 0.2f;
                        Fire(enemyHandleAiming.angle);
                    }
                }
                else if(gunType == 2){
                    if(lastShot <= 0){
                        weaponAmmo.reduceAmmo(gunType);
                        lastShot = 0.4f;                
                        Fire(enemyHandleAiming.angle, 0.5f);
                        Fire(enemyHandleAiming.angle + 15, 0.5f);
                        Fire(enemyHandleAiming.angle - 15, 0.5f);              
                    }
                    
                }
            }
      
    }
    void Fire(float angle, float duration = 2f){
        GameObject bulletSpawn = Instantiate(bullet, gunEndPosition.position, gun.transform.rotation);
        bulletSpawn.GetComponent<bulletController>().rotateBullet(Quaternion.Euler(0, 0, angle));
        bulletSpawn.GetComponent<bulletController>().isPlayerShooting = false; 
        bulletSpawn.GetComponent<bulletController>().setDuration(duration);
        bulletSpawn.GetComponent<bulletController>().setSpeed(bulletSpeed);
    }

    private IEnumerator reloadGun(){
        reloadAnimator.SetTrigger("reloadLate");
        yield return new WaitForSeconds(2.2f);
        weaponAmmo.reloadGun(gunType);
        reloadRoutine = null;
    }
}
