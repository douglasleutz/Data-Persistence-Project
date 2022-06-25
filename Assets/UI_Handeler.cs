using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UI_Handeler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        SaveData.Instance.LoadHighScore();

        bestScoreText.text = "Best Score : " + SaveData.Instance.HighScoreName + " : " + SaveData.Instance.HighScorePoints;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }




}
