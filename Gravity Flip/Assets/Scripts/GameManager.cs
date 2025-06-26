using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement playerMovement;

    private static Vector3 lastCheckpointPos;

    public static void killPlayer(GameObject player, Collider2D spike, SpriteRenderer playerSR)
    {
        Debug.Log("Player Killed");

        PlayerMovement.isAlive = false;

        Vector3 deathPos = spike.transform.position;
        CameraFollow.shouldStopAtTarget = true;
        CameraFollow.stopAtPosition = deathPos;

        GameObject deathCamTarget = new GameObject("DeathCamTarget");
        deathCamTarget.transform.position = deathPos;
        CameraFollow.instance.SetTarget(deathCamTarget.transform);

        // Stop the players movement
        PlayerMovement.rb.linearVelocity = Vector2.zero;
        Destroy(deathCamTarget);
    }

    public static void checkpoint(Collider2D cpNum)
    {
        Debug.Log(cpNum);
        lastCheckpointPos = cpNum.transform.position;
    }

    private void respawnPlayer()
    {
        Debug.Log("Player Respawned");

        PlayerMovement.isAlive = true;
        playerMovement.player.transform.position = lastCheckpointPos;
        playerMovement.spriteRenderer.enabled = true;
        CameraFollow.tracking = true;

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
