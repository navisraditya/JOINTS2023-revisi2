using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingAnim : MonoBehaviour
{
    public GameObject btn;
    public float delay;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        btn.SetActive(false);
        yield return new WaitForSeconds(delay);
        btn.SetActive(true);
    }
}
