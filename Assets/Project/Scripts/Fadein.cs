using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fadein : MonoBehaviour
{
    [SerializeField] Image bg;
    [SerializeField] TextMeshProUGUI txt;

    private Color bgColor;
    private Color txtColor;

    private void Start() {
        bgColor = bg.color;
        txtColor = txt.color;

        bg.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0f);
        txt.color = new Color(txtColor.r, txtColor.g, txtColor.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(bg.color.a < 0.98)
        {
            bg.color = Color.Lerp(bg.color, bgColor, Time.deltaTime);
        }

        if(txt.color.a < 0.98)
        {
            txt.color = Color.Lerp(txt.color, txtColor, Time.deltaTime);
        }
    }

    private void OnDisable() {
        
        bg.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0f);
        txt.color = new Color(txtColor.r, txtColor.g, txtColor.b, 0f);
    }
}
