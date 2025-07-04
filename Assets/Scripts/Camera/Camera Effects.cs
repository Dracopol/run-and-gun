using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;

    [SerializeField] private float baseFov = 100f; 
    [SerializeField] private float maxFov = 150f; 
    [SerializeField] private float fovSpeedMultiplier = 0.5f;

    private void Update()
    {
        AdjustFovBasedOnSpeed();
    }

    private void AdjustFovBasedOnSpeed()
    {
        float speed = rb.linearVelocity.magnitude;

        float targetFov = baseFov + speed * fovSpeedMultiplier;

        targetFov = Mathf.Clamp(targetFov, baseFov, maxFov);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFov, Time.deltaTime * 5f);
    }
}
