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

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // If the current scene is a cutscene, start waiting for the video to end
        if (currentSceneIndex == 6 || currentSceneIndex == 7)
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
        StartCoroutine(LoadCutsceneThenLevel(6, 2)); // Load Cutscene 1 before Level 1
    }

    public void LoadLevelTwo()
    {
        StartCoroutine(LoadCutsceneThenLevel(7, 3)); // Load Cutscene 2 before Level 2
    }

    public void LoadCutsceneAfterLevelOne()
    {
        Debug.Log("Loading Cutscene after Level 1 (Scene 7)...");
        StartCoroutine(LoadLevel(7)); // Ensure Scene 7 (Cutscene 2) is loaded
    }

    public void SkipCutscene()
    {
        StartCoroutine(LoadLevel(2)); // Skips Cutscene 1 → Loads Level 1
    }

    public void SkipCutscene2()
    {
        StartCoroutine(LoadLevel(3)); // Skips Cutscene 2 → Loads Level 2
    }

    public void LoadLoseScene()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void LoadWinScene()
    {
        StartCoroutine(LoadLevel(5)); // Leaves LoadWinScene unchanged
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
        StartCoroutine(WaitForVideoToEnd(levelIndex));
    }

    IEnumerator WaitForVideoToEnd(int nextLevel = 2) // Default changed to prevent errors
    {
        yield return new WaitForSeconds(1f);

        VideoPlayer videoPlayer = FindObjectOfType<VideoPlayer>();

        if (videoPlayer != null)
        {
            isCutscenePlaying = true;
            Debug.Log("Cutscene started!");

            while (videoPlayer.isPlaying)
            {
                yield return null; // Wait until the video finishes
            }

            Debug.Log($"Cutscene finished! Loading Scene {nextLevel}...");
            isCutscenePlaying = false;

            // If Scene 7 (Cutscene 2) is playing, transition to Scene 5 (Level 2)
            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                StartCoroutine(LoadLevel(5)); // Ensure Scene 7 → Scene 5
            }
            else
            {
                StartCoroutine(LoadLevel(nextLevel));
            }
        }
        else
        {
            Debug.LogWarning("No VideoPlayer found! Loading next level immediately.");
            StartCoroutine(LoadLevel(nextLevel));
        }
    }
}