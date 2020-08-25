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

        print("highscoreData: " + highscoreData);

        if (highscoreData != "")
        {
            List<string> encodedHighscores = highscoreData.Split(';').ToList<string>();

            string textBoxText = "";

            SortedDictionary<float, string> scores = new SortedDictionary<float, string>();

            foreach (var encodedHighscore in encodedHighscores)
            {
                print("Encoded highscore: " + encodedHighscore);
                if (encodedHighscore == "")
                {
                    continue;
                }
                string decodedHighscore = HighscoreController.DecodeString(encodedHighscore);
                print("Decoded highscore: " + decodedHighscore);
                string[] array = decodedHighscore.Split('§');
                string name = array[0];
                float time = float.Parse(array[1]);
                print("Decoded float time: " + time.ToString());

                scores.Add(time, name);
            }

            foreach (var score in scores)
            {
                textBoxText += score.Value + " : " + TMPTextController.FormatFloatTimeToGameTime(score.Key).Substring(6) + '\n';
            }

            textElement.SetText(textBoxText);
        } else
        {
            textElement.SetText("No highscores found!");
        }


    }

}
