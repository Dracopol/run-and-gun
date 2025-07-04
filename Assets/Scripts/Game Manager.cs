using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject audios;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuTxt;
    [SerializeField] private GameObject TimerTxt;

    private float timer;

    private void Start()
    {
        timer = 0f; 
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (TimerTxt != null)
        {
            TimerTxt.GetComponent<TextMeshProUGUI>().text = $"Time: {timer:F2}"; 
        }

        if (playerTransform.position.y < -50f)
        {
            OpenMenu();
            TextMeshProUGUI menuTextComponent = menuTxt.GetComponent<TextMeshProUGUI>();
            if (menuTextComponent != null)
            {
                menuTextComponent.text = "You Died";
                menuTextComponent.color = Color.red;
            }
        }
    }

    private void OpenMenu()
    {
        player.SetActive(false);
        weapon.SetActive(false);
        audios.SetActive(false);
        panel.SetActive(true);
        menu.SetActive(true);
        TimerTxt.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Win()
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        PlayerCam cameraController = player.GetComponentInChildren<PlayerCam>();

        playerMovement.enabled = false;
        cameraController.enabled = false;

        weapon.SetActive(false);
        panel.SetActive(true);
        menu.SetActive(true);
        TimerTxt.SetActive(false);
        menuTxt.GetComponent<TextMeshProUGUI>().text = $"Time: {timer:F2}";
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    private void RestartLevelButton()
    {
        int cureerentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cureerentSceneIndex);
    }
}

