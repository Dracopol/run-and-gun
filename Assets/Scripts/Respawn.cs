using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player; 
    private Vector3 respawnPoint = Vector3.zero; 

    private void Start()
    {
        respawnPoint = Vector3.zero;
    }

    private void Update()
    {
        if (player.position.y < -50f)
        {
            RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RespawnTrigger"))
        {
            respawnPoint = other.transform.position;
        }
    }

    private void RespawnPlayer()
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero; 
        }

        player.position = respawnPoint;
    }
}
