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
}
