using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetLevelNumTxt : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start() {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        textMesh.text = GameManager.instance.GetCurrentLevel().ToString();
    }
}
