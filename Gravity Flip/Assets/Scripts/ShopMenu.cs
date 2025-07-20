using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameManager gameManager;

    [Header("Costs")] 
    public int speedIncreaseCost = 2;
    
    public void speedIncrease()
    {
        if (gameManager.playerCredits >= speedIncreaseCost)
        {
            gameManager.playerCredits -= speedIncreaseCost;
            gameManager.playerCreditsText.text = gameManager.playerCredits.ToString();
        
            playerMovement.moveSpeed += 1;
        }
    }
}
