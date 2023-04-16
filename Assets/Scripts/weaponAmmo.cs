using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponAmmo : MonoBehaviour
{
    int[] maxAmmo = {12, 24, 4};
    int[] curAmmo = {12, 24, 4};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getAmmo(int idx){
        return curAmmo[idx];
    }
    public void reduceAmmo(int idx){
        curAmmo[idx]--;
    }

    public void reloadGun(int idx){
        curAmmo[idx] = maxAmmo[idx];
    }
}
