using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPTextController : MonoBehaviour
{
    private TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Awake()
    {
        textElement = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void SetText(string text)
    {
        textElement.SetText(text);
    }

    public string FormatFloatTimeToGameTime(float floatTime)
    {
        string minutes = Mathf.Floor(floatTime / 60).ToString();
        string seconds = (floatTime % 60).ToString("00");
        string hundreds = Mathf.Floor((floatTime - Mathf.Floor(floatTime)) * 100).ToString("00");
        return "Time: " + minutes + ":" + seconds + "." + hundreds;
    }
}
