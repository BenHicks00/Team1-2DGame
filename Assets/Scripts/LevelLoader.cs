using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Video; // Required for VideoPlayer

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 3f;
    private bool isCutscenePlaying = false;

    private void Start()
    {
        Debug.Log("LevelLoader script is running in this scene.");
        
        if (SceneManager.GetActiveScene().buildIndex == 6) // Ensure this runs in Cutscene Scene
        {
            StartCoroutine(WaitForVideoToEnd());
        }
    }

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
        // Load Cutscene (Scene Index 6) before Level 1 (Scene Index 2)
        StartCoroutine(LoadCutsceneThenLevel(6, 2));
    }
    public void SkipCutscene()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadLevelTwo()
    {
        StartCoroutine(LoadLevel(5));
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

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);
        Debug.Log($"Loading Scene {levelIndex}...");
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadCutsceneThenLevel(int cutsceneIndex, int levelIndex)
    {
        Debug.Log($"Loading Cutscene Scene {cutsceneIndex}...");
        SceneManager.LoadScene(cutsceneIndex);

        yield return new WaitForSeconds(1f);

        Debug.Log("Waiting for video to finish...");
        StartCoroutine(WaitForVideoToEnd());
    }

    IEnumerator WaitForVideoToEnd()
    {
        yield return new WaitForSeconds(1f);

        // Find the VideoPlayer in the current scene
        VideoPlayer videoPlayer = FindObjectOfType<VideoPlayer>();

        if (videoPlayer != null)
        {
            isCutscenePlaying = true;
            Debug.Log("Cutscene started!");

            while (videoPlayer.isPlaying)
            {
                yield return null; // Wait one frame
            }

            Debug.Log("Cutscene finished! Loading Level 1...");
            isCutscenePlaying = false;
            StartCoroutine(LoadLevel(2)); // Load Level 1 (Scene 2)
        }
        else
        {
            Debug.LogWarning("No VideoPlayer found! Loading Level 1 immediately.");
            StartCoroutine(LoadLevel(2));
        }
    }
}