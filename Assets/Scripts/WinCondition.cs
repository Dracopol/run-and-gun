using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player entered the end zone trigger box!");
            gameManager.Win(); 
        }
    }
}

