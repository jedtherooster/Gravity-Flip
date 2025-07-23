using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void resumeGame()
    {
        playerMovement.canMove = true;
    }
}
