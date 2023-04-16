using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReloadManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _ammoText;
    [SerializeField] weaponAmmo weaponAmmo;
    [SerializeField] gunController gunController;

    // Start is called before the first frame update
    private void Update() {
        string temp = weaponAmmo.getAmmo(gunController.getGunIndex() % 3).ToString();
        _ammoText.text = temp;
    }
}
