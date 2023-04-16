using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] string bulletColor; 
    [SerializeField] int bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy" || other.gameObject.tag == "player"){
            if(other.gameObject.tag == "player" && other.gameObject.GetComponent<playerInvrunrable>().isInvrunrable()){
                other.gameObject.GetComponent<PlayerHealth>().reducePlayerHP(0);
            }

            else if(other.gameObject.GetComponent<PlayerHealth>().getPlayerColor() == bulletColor){
                other.gameObject.GetComponent<PlayerHealth>().reducePlayerHP(bulletDamage);
                if(other.gameObject.tag == "player"){
                    other.gameObject.GetComponent<flashPlayer>().flashObject();
                }
            }
        }
       
    }
}
