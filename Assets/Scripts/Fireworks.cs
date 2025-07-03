using UnityEngine;

public class Fireworks : MonoBehaviour
{
    [SerializeField] private AudioSource fireworkAudio; 
    [SerializeField] private ParticleSystem fireworkParticles; 
    private bool hasTriggered = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End") && !hasTriggered)
        {
            hasTriggered = true; 

            if (fireworkAudio != null)
            {
                fireworkAudio.Play();
            }

            StartCoroutine(PlayFireworks());
        }
    }

    private System.Collections.IEnumerator PlayFireworks()
    {
        int totalBursts = 5; 
        float interval = 2f; 

        for (int i = 0; i < totalBursts; i++)
        {
            if (fireworkParticles != null)
            {
                fireworkParticles.Play(); 
            }

            yield return new WaitForSeconds(interval); 
        }
    }
}