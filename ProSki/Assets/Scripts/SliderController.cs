using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float decreasePerSecond;

    // Update is called once per frame
    void Update()
    {
        slider.value -= decreasePerSecond * Time.deltaTime;
    }

}
