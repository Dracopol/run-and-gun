using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera cam;

    [SerializeField] float baseFov = 100f; 
    [SerializeField] float maxFov = 150f; 
    [SerializeField] float fovSpeedMultiplier = 0.5f;

    void Update()
    {
        AdjustFovBasedOnSpeed();
    }

    void AdjustFovBasedOnSpeed()
    {
        float speed = rb.linearVelocity.magnitude;

        float targetFov = baseFov + speed * fovSpeedMultiplier;

        targetFov = Mathf.Clamp(targetFov, baseFov, maxFov);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFov, Time.deltaTime * 5f);
    }
}
