using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] public Image one;
    [SerializeField] public Image two;
    [SerializeField] public Image three;
    [SerializeField] public Image four;
    [SerializeField] public Image five;

    [SerializeField] public Image un_one;
    [SerializeField] public Image un_two;
    [SerializeField] public Image un_three;
    [SerializeField] public Image un_four;
    [SerializeField] public Image un_five;

    int health;
    [SerializeField] PlayerHealth playerHealth;

    void Start() {
        health = 5;

        one.enabled = true;
        two.enabled = true;
        three.enabled = true;
        four.enabled = true;
        five.enabled = true;

        un_one.enabled = false;
        un_two.enabled = false;
        un_three.enabled = false;
        un_four.enabled = false;
        un_five.enabled = false;
    }

    private void Update() {
        int temp = (int)(Mathf.Ceil((float)playerHealth.getHealth() / playerHealth.getMaxHealth() * 5));
        health = temp;
        setHealth();
    }


    void setHealth() {

        Debug.Log(health);
        if(health == 5) {
            one.enabled = true;
            two.enabled = true;
            three.enabled = true;
            four.enabled = true;
            five.enabled = true;

            un_one.enabled = false;
            un_two.enabled = false;
            un_three.enabled = false;
            un_four.enabled = false;
            un_five.enabled = false;
        }
        if(health == 4) {
            one.enabled = true;
            two.enabled = true;
            three.enabled = true;
            four.enabled = true;
            five.enabled = false;

            un_one.enabled = false;
            un_two.enabled = false;
            un_three.enabled = false;
            un_four.enabled = false;
            un_five.enabled = true;
        }
        if(health == 3) {
            one.enabled = true;
            two.enabled = true;
            three.enabled = true;
            four.enabled = false;
            five.enabled = false;

            un_one.enabled = false;
            un_two.enabled = false;
            un_three.enabled = false;
            un_four.enabled = true;
            un_five.enabled = true;            
        }
        if(health == 2) {
            one.enabled = true;
            two.enabled = true;
            three.enabled = false;
            four.enabled = false;
            five.enabled = false;

            un_one.enabled = false;
            un_two.enabled = false;
            un_three.enabled = true;
            un_four.enabled = true;
            un_five.enabled = true;
        }
        if(health == 1) {
            one.enabled = true;
            two.enabled = false;
            three.enabled = false;
            four.enabled = false;
            five.enabled = false;

            un_one.enabled = false;
            un_two.enabled = true;
            un_three.enabled = true;
            un_four.enabled = true;
            un_five.enabled = true;
        }
    }
}