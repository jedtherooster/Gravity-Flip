using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameManager gameManager;

    [Header("Costs")] 
    public int speedIncreaseCost = 2;
    public int heightIncreaseCost = 4;
    public int brighterSpotLightCost = 1;
    public int disableGroundCheckCost = 10;
    
    public void speedIncrease()
    {
        if (gameManager.playerCredits >= speedIncreaseCost)
        {
            gameManager.playerCredits -= speedIncreaseCost;
            gameManager.playerCreditsText.text = gameManager.playerCredits.ToString();
        
            playerMovement.moveSpeed += 1;
        }
    }

    public void heightIncrease()
    {
        if (gameManager.playerCredits >= heightIncreaseCost)
        {
            gameManager.playerCredits -= heightIncreaseCost;
            gameManager.playerCreditsText.text = gameManager.playerCredits.ToString();

            playerMovement.jumpForce += 2;

        }
    }
}
