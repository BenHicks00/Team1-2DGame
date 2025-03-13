using UnityEngine;

public class SceneSkip : MonoBehaviour
{
    public LevelLoader levelLoader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            levelLoader.SkipCutscene();
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            levelLoader.LoadLevelTwo();
        }
    }
}
