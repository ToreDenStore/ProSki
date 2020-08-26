using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedInputController : MonoBehaviour
{
    public GameObject inputObject;
    private TMP_InputField textElement;

    // Start is called before the first frame update
    void Awake()
    {
        textElement = inputObject.GetComponent<TMP_InputField>();
    }

    public void SetRandomSeed() {
        int randomSeed = Random.Range(0, int.MaxValue);
        print("Setting random seed to " + randomSeed.ToString());
        textElement.text = (randomSeed.ToString());
    }

    public int GetChosenSeed()
    {
        return int.Parse(textElement.text);
    }
}
