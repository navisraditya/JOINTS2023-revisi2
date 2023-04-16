using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleAiming : MonoBehaviour
{
    [SerializeField] Transform gunTransform;
    [SerializeField] private Camera cam;
    public float angle = 0;

    private void Awake() {
        // todo if gun added;
        gunTransform = transform;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gunDirection = (mousePos - gunTransform.position).normalized;
        angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        gunTransform.eulerAngles = new Vector3(0, 0, angle);
        
        Vector2 localScale = Vector2.one;
        if(angle > 90 || angle < -90){
            localScale.y = -1f;
        }
        else{
            localScale.y = 1f;
        }
        gunTransform.localScale = localScale;
    }
}
