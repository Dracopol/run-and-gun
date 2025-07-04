using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            gameManager.Win(); 
        }
    }
}

