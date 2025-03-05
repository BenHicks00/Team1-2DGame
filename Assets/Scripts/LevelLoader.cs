using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 3f;

    public void LoadHelpMenu()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }
    public void LoadLevelOne()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void LoadLevelTwo()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void LoadLoseScene()
    {
        StartCoroutine(LoadLevel(4));
    }
    public void LoadWinScene()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void ExitGame()
    {
        Application.Quit();
    }





    IEnumerator LoadLevel(int levelindex)
    {

        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelindex);
    }
}
