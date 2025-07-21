using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerMovement playerMovement;
    public GameManager gameManager;
    public Light2D playerSpotlight;

    [Header("Costs")] 
    public int speedIncreaseCost = 2;
    public int heightIncreaseCost = 4;
    public int brighterSpotLightCost = 1;
    public int widerFovCost = 3;
    
    [Header("Panels")]
    public GameObject heightIncreasePanel;
    public GameObject brighterSpotLightPanel;
    
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
            
            heightIncreasePanel.SetActive(false);
        }
    }

    public void spotLightIncrease()
    {
        if (gameManager.playerCredits >= widerFovCost)
        {
            gameManager.playerCredits -= widerFovCost;
            gameManager.playerCreditsText.text = gameManager.playerCredits.ToString();

            playerSpotlight.pointLightOuterRadius = 10f;
            
            brighterSpotLightPanel.SetActive(false);
        }
    }
}
