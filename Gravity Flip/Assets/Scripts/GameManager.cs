using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement playerMovement;
    public Animator transition;
    public TextMeshProUGUI playerCreditsText;
    public GameObject shopScreen;
    public GameObject gameOverScreen;

    [Header("Settings")] 
    public float transitionDuration = 1f;

    [Header("Variables")] 
    public int playerCredits;
    public bool gravityZonesEnabled = true;

    private Vector3 playerScale;
    private static Vector3 lastCheckpointPos;

    public void killPlayer(Collider2D spike)
    {
        
        PlayerMovement.isAlive = false;
        PlayerMovement.spotLight.SetActive(false);
        PlayerMovement.innerLight.SetActive(false);

        Vector3 deathPos = spike.transform.position;
        CameraFollow.shouldStopAtTarget = true;
        CameraFollow.stopAtPosition = deathPos;

        GameObject deathCamTarget = new GameObject("DeathCamTarget");
        deathCamTarget.transform.position = deathPos;
        CameraFollow.instance.SetTarget(deathCamTarget.transform);

        // Stop the players movement
        PlayerMovement.rb.linearVelocity = Vector2.zero;
        gameOverScreen.SetActive(true);
    }

    public static void checkpoint(Collider2D cpNum)
    {
        Debug.Log(cpNum);
        lastCheckpointPos = cpNum.transform.position;
    }

    public void respawnPlayer()
    {
        gameOverScreen.SetActive(false);
        
        PlayerMovement.isAlive = true;
        playerMovement.player.transform.position = lastCheckpointPos;
        playerMovement.spriteRenderer.enabled = true;
        CameraFollow.tracking = true;
        PlayerMovement.spotLight.SetActive(true);
        PlayerMovement.innerLight.SetActive(true);
        
        playerMovement.transform.localScale = playerScale;
        PlayerMovement.rb.gravityScale = 2.5f;

        CameraFollow.instance.SetTarget(playerMovement.player.transform);
    }

    public void loadNextLevel(int sceneIndex)
    {
        StartCoroutine(loadLevel(sceneIndex));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionDuration);
        
        SceneManager.LoadScene(levelIndex);
    }

    public void addCredits(int amount)
    {
        playerCredits += amount;
        playerCreditsText.text = playerCredits.ToString();
    }

    public void loadShop()
    {
        shopScreen.SetActive(true);
        playerMovement.canMove = false;
    }

    public void resumeGame()
    {
        playerMovement.canMove = true;
    }

    private void Start()
    {
        playerScale = playerMovement.player.transform.localScale;
    }

    private void Update()
    {
        if (PlayerMovement.isAlive == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                respawnPlayer();
            }
        }
    }
}
