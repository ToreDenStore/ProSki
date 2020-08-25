using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class HighscoreResultController : MonoBehaviour
{
    public void ShowHighscore(GameObject highscoreTMP)
    {
        TextMeshProUGUI textElement = highscoreTMP.GetComponent<TextMeshProUGUI>();

        print("Showing highscore");

        List<string> encodedHighscores = PlayerPrefs.GetString("highscore").Split(';').ToList<string>();

        string textBoxText = "";

        foreach (var encodedHighscore in encodedHighscores)
        {
            string decodedHighscore = HighscoreController.DecodeString(encodedHighscore);
            print("Found highscore: " + decodedHighscore);
            textBoxText += decodedHighscore + '\n';
        }

        textElement.SetText(textBoxText);
    }

}
