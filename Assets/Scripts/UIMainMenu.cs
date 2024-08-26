using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button BackFromSettingsButton;
    [SerializeField] private Button BackFromCreditsButton;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject CreditsPanel;

    [SerializeField] private Slider player1SpeedSlider;
    [SerializeField] private Slider player2SpeedSlider;

    [SerializeField] private Text player1SpeedText;
    [SerializeField] private Text player2SpeedText;

    private Movement player1Movement;
    private Movement player2Movement;

    private void Awake()
    {

        player1Movement = player1.GetComponent<Movement>();
        player2Movement = player2.GetComponent<Movement>();

        player1SpeedSlider.onValueChanged.AddListener(UpdatePlayer1Speed);
        player2SpeedSlider.onValueChanged.AddListener(UpdatePlayer2Speed);
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        SettingsButton.onClick.AddListener(OnSettingsButtonClicked);
        CreditsButton.onClick.AddListener(OnCreditsButtonClicked);
        BackFromSettingsButton.onClick.AddListener(BackToPauseMenu);
        BackFromCreditsButton.onClick.AddListener(BackToPauseMenu);
        ExitButton.onClick.AddListener(OnExitButtonClicked);

        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PausePanel.activeSelf)
            {
                PausePanel.SetActive(true);
            }
            Debug.Log("se apreto la tecla menu");
        }
    }

    private void OnPlayButtonClicked()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
            Debug.Log("OnPlayButtonClicked");
        }
    }

    public void OnSettingsButtonClicked()
    {
        if (PausePanel != null && SettingsPanel != null)
        {
            PausePanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }
    }

    public void OnCreditsButtonClicked()
    {
        if (PausePanel != null && CreditsPanel != null)
        {
            PausePanel.SetActive(false);
            CreditsPanel.SetActive(true);
        }
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void UpdatePlayer1Speed(float newSpeed)
    {
        if (player1Movement != null)
        {
            player1Movement.speed = newSpeed;
            player1SpeedText.text = newSpeed.ToString("F2");
        }
    }

    public void UpdatePlayer2Speed(float newSpeed)
    {
        if (player2Movement != null)
        {
            player2Movement.speed = newSpeed;
            player2SpeedText.text = newSpeed.ToString("F2");
        }
    }

    public void BackToPauseMenu()
    {
        if (SettingsPanel != null && CreditsPanel != null && PausePanel != null)
        {
            SettingsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
            PausePanel.SetActive(true);
        }
    }
}