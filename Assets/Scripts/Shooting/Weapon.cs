using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gunSound;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private int DMG = 1;

    private void Update()
    {
        HandleShoot();
        HandleSpin();
    }

    private void HandleSpin()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.Play("Spin", 0, 0f);
        }
    }

    private void HandleShoot()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

        muzzleFlash.Play();

        AudioSource gunAudioSource = gunSound.GetComponent<AudioSource>();
        gunAudioSource.Play();

        animator.Play("Shoot", 0, 0f);

        RaycastHit hit;

    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
    {
        if (hit.collider.CompareTag("RespawnTrigger"))
        {
            if (Physics.Raycast(hit.point + Camera.main.transform.forward * 0.01f, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Instantiate(hitVFXPrefab, hit.point, quaternion.identity);
                TargetHP targetHP = hit.collider.GetComponent<TargetHP>();
                targetHP?.TakeDamage(DMG);
            }
        }
        else
        {
            Instantiate(hitVFXPrefab, hit.point, quaternion.identity);
            TargetHP targetHP = hit.collider.GetComponent<TargetHP>();
            targetHP?.TakeDamage(DMG);
            if (targetHP != null)
            {
                targetHP.TakeDamage(DMG);
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                StartCoroutine(TemporarySpeedBoost(playerMovement, 10f, 20f, 2f)); 
            }
        }
    }
    }

        private IEnumerator TemporarySpeedBoost(PlayerMovement playerMovement, float walkIncrease, float swingIncrease, float duration)
{
    playerMovement.walkSpeed += walkIncrease;
    playerMovement.swingSpeed += swingIncrease;
    yield return new WaitForSeconds(duration);
    playerMovement.walkSpeed -= walkIncrease;
    playerMovement.swingSpeed -= swingIncrease;
}
}
