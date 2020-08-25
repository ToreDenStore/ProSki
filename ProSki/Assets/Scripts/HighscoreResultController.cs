using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using System.Globalization;

public class HighscoreResultController : MonoBehaviour
{
    public void ShowHighscore(GameObject highscoreTMP)
    {
        TextMeshProUGUI textElement = highscoreTMP.GetComponent<TextMeshProUGUI>();

        //PlayerPrefs.SetString("highscore", null);
        string highscoreData = PlayerPrefs.GetString("highscore");

        if (highscoreData != "")
        {
            List<string> encodedHighscores = highscoreData.Split(';').ToList<string>();

            string textBoxText = "";

            foreach (var encodedHighscore in encodedHighscores)
            {
                print("encoded: " + encodedHighscore);
                string decodedHighscore = HighscoreController.DecodeString(encodedHighscore);
                print("Found highscore: " + decodedHighscore);
                string[] array = decodedHighscore.Split('§');
                string name = array[0];
                float time = float.Parse(array[1]); //, CultureInfo.InvariantCulture.NumberFormat
                print("Decoded float time: " + time.ToString());

                textBoxText += name + " : " + TMPTextController.FormatFloatTimeToGameTime(time).Substring(6) + '\n';
            }

            textElement.SetText(textBoxText);
        } else
        {
            textElement.SetText("No highscore found!");
        }


    }

}
