using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    int scene;
    private void Start()
    {
        LoadScene();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneLevel());
    }

    public int SceneLevel()
    {
        scene = (characterData.level-1) % (SceneManager.sceneCountInBuildSettings - 1);
        return scene + 1;
    }
    public void PreLoad()
    {
        SceneManager.LoadScene(0);
    }
}
