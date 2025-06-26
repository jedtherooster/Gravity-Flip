using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static void killPlayer(GameObject player, Collider2D spike)
    {
        Debug.Log("Player Killed");

        PlayerMovement.isAlive = false;

        Vector3 deathPos = player.transform.position;
        CameraFollow.shouldStopAtTarget = true;
        CameraFollow.stopAtPosition = deathPos;

        GameObject deathCamTarget = new GameObject("DeathCamTarget");
        deathCamTarget.transform.position = deathPos;
        CameraFollow.instance.SetTarget(deathCamTarget.transform); 

        GameObject.Destroy(player);
    }
}
