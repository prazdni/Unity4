using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    #region Methods

    private string _qualityChange;

    public void FreezeTime()
    {
        Time.timeScale = 0;
    }

    public void UnfreezeTime()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void ApplyQualitySettings(TMP_Text _text)
    {
        _qualityChange = _text.text;

        switch (_qualityChange)
        {
            case "Fastest":
                QualitySettings.SetQualityLevel(0);
                print("fastest");
                break;
            case "Fast":
                QualitySettings.SetQualityLevel(1);
                print("Fast");
                break;
            case "Good":
                QualitySettings.SetQualityLevel(2);
                print("Good");
                break;
            case "Simple":
                QualitySettings.SetQualityLevel(3);
                print("Simple");
                break;
            case "Beautiful":
                QualitySettings.SetQualityLevel(4);
                print("Beautiful");
                break;
            case "Fantastic":
                QualitySettings.SetQualityLevel(5);
                print("Fantastic");
                break;
            default:
                break;
        }
    }

    #endregion
}
