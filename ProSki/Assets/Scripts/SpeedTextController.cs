using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedTextController : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;
    private TextMeshProUGUI speedTextElement;

    // Start is called before the first frame update
    void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
        speedTextElement = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeedForward = Mathf.Sqrt(Mathf.Pow(Mathf.Max(0, rb.velocity.x), 2) + Mathf.Pow(Mathf.Max(0, rb.velocity.y), 2));
        speedTextElement.SetText("Speed: " + Mathf.RoundToInt(currentSpeedForward));
    }
}
