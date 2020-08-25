using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class HighScoreController : MonoBehaviour
{
    public GameObject inputObject;
    private TMP_InputField inputFieldComponent;

    // Start is called before the first frame update
    void Start()
    {
        inputFieldComponent = inputObject.GetComponent<TMP_InputField>();
    }

    public void SaveHighscore(float time)
    {
        string playerName = inputFieldComponent.text;
        
        List<string> highscores = PlayerPrefs.GetString("highscore").Split(';').ToList<string>();

        //Each element in highScores is encoded, but looks like: "Jonatan_:_2:12:42"

        string newHighscoreString = playerName + "_:_" + TMPTextController.FormatFloatTimeToGameTime(time);

        print("Saving highscore: " + newHighscoreString);

        highscores.Add(EncodeString(newHighscoreString));

        PlayerPrefs.SetString("highscore", string.Join(";", highscores));
    }

    public static string EncodeString(string text)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}
