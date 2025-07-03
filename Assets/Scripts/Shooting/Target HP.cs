using UnityEngine;
using System.Collections;
public class TargetHP : MonoBehaviour
{
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] GameObject boopSound;
    [SerializeField] GameObject cheerSound;
    [SerializeField] int startingHP = 1;
    [SerializeField] Transform player;

    int currentHP;

    private void Awake()
    {
        currentHP = startingHP;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            

            Instantiate(hitVFXPrefab, transform.position, Quaternion.identity);
            AudioSource boopAudioSource = boopSound.GetComponent<AudioSource>();
            boopAudioSource.Play();
            AudioSource cheerAudioSource = cheerSound.GetComponent<AudioSource>();
            if (cheerAudioSource != null && !cheerAudioSource.isPlaying)
            {
                cheerAudioSource.Play();
            }
    
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
