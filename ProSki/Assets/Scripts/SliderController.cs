using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float decreasePerSecond;
    public GameObject bar;

    private Image barImage;

    private void Awake()
    {
        barImage = bar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= decreasePerSecond * Time.deltaTime;

        changeColor();
    }

    private void changeColor()
    {
        if (slider.value > 50)
        {
            barImage.color = Color.Lerp(Color.yellow, Color.red, (slider.value - 50) / 50);
        }
        else
        {
            barImage.color = Color.Lerp(Color.green, Color.yellow, slider.value / 50);
        }
    }


}
