using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject audios;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject menuTxt;
    [SerializeField] GameObject TimerTxt;

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

    public void OpenMenu()
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


    public void RestartLevelButton()
    {
        int cureerentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cureerentSceneIndex);
    }
}

