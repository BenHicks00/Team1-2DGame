using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<MenuMusic>().Length > 1)
        {
            Destroy(gameObject); // Prevent duplicate music players
        }
    }

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Ensure AudioSource exists
        }

        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 0.5f; // Adjust volume as needed

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Menu music started!");
        }

        // Listen for scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Stop music if the player enters the cutscene or a game scene
        if (scene.buildIndex == 6 || scene.buildIndex == 2 || scene.buildIndex == 3) // Adjust for your cutscene and game levels
        {
            Debug.Log($"Stopping menu music in scene: {scene.buildIndex}");
            Destroy(gameObject); // Stop music when entering the cutscene or game
        }
    }
}