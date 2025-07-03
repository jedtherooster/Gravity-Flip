using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayTutorial()
    {
        SceneManager.LoadScene(1);  // Scene 1 = Turorial Level
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene(2);  // Scene 2 = Main Game
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    
}
