using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement playerMovement;
    

    private static Vector3 lastCheckpointPos;

    public static void killPlayer(Collider2D spike)
    {
        
        PlayerMovement.isAlive = false;
        PlayerMovement.spotLight.SetActive(false);

        Vector3 deathPos = spike.transform.position;
        CameraFollow.shouldStopAtTarget = true;
        CameraFollow.stopAtPosition = deathPos;

        GameObject deathCamTarget = new GameObject("DeathCamTarget");
        deathCamTarget.transform.position = deathPos;
        CameraFollow.instance.SetTarget(deathCamTarget.transform);

        // Stop the players movement
        PlayerMovement.rb.linearVelocity = Vector2.zero;
    }

    public static void checkpoint(Collider2D cpNum)
    {
        Debug.Log(cpNum);
        lastCheckpointPos = cpNum.transform.position;
    }

    private void respawnPlayer()
    {
        PlayerMovement.isAlive = true;
        playerMovement.player.transform.position = lastCheckpointPos;
        playerMovement.spriteRenderer.enabled = true;
        CameraFollow.tracking = true;
        PlayerMovement.spotLight.SetActive(true);

        CameraFollow.instance.SetTarget(playerMovement.player.transform);
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
