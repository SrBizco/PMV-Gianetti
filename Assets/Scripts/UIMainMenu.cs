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

    [SerializeField] private Slider player1ScaleSlider;
    [SerializeField] private Slider player2ScaleSlider;

    [SerializeField] private Text player1SpeedText;
    [SerializeField] private Text player2SpeedText;

    [SerializeField] private Button ChangePlayer1ColorButton;
    [SerializeField] private Button ChangePlayer2ColorButton;

    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;

    private PlayerController player1Movement;
    private PlayerController player2Movement;

    private int player1Score = 0;
    private int player2Score = 0; 

    private void Awake()
    {
        player1Movement = player1.GetComponent<PlayerController>();
        player2Movement = player2.GetComponent<PlayerController>();

        player1SpeedSlider.onValueChanged.AddListener(UpdatePlayer1Speed);
        player2SpeedSlider.onValueChanged.AddListener(UpdatePlayer2Speed);

        player1ScaleSlider.onValueChanged.AddListener(UpdatePlayer1Scale);
        player2ScaleSlider.onValueChanged.AddListener(UpdatePlayer2Scale);

        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        SettingsButton.onClick.AddListener(OnSettingsButtonClicked);
        CreditsButton.onClick.AddListener(OnCreditsButtonClicked);
        BackFromSettingsButton.onClick.AddListener(BackToPauseMenu);
        BackFromCreditsButton.onClick.AddListener(BackToPauseMenu);
        ExitButton.onClick.AddListener(OnExitButtonClicked);

        ChangePlayer1ColorButton.onClick.AddListener(ChangePlayer1Color);
        ChangePlayer2ColorButton.onClick.AddListener(ChangePlayer2Color);

        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        
        player1SpeedSlider.minValue = 50f;
        player1SpeedSlider.maxValue = 200f;
        player1SpeedSlider.value = 100f;

        player2SpeedSlider.minValue = 50f;
        player2SpeedSlider.maxValue = 200f;
        player2SpeedSlider.value = 100f;


        player1ScaleSlider.minValue = 0.5f;
        player1ScaleSlider.maxValue = 2.0f;
        player1ScaleSlider.value = 1.0f;

        player2ScaleSlider.minValue = 0.5f;
        player2ScaleSlider.maxValue = 2.0f;
        player2ScaleSlider.value = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PausePanel.activeSelf)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    private void OnPlayButtonClicked()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
            Debug.Log("OnPlayButtonClicked");
            Time.timeScale = 1f;
        }
    }

    public void OnSettingsButtonClicked()
    {
        if (PausePanel != null && SettingsPanel != null)
        {
            PausePanel.SetActive(false);
            SettingsPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnCreditsButtonClicked()
    {
        if (PausePanel != null && CreditsPanel != null)
        {
            PausePanel.SetActive(false);
            CreditsPanel.SetActive(true);
            Time.timeScale = 0f;
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


    public void UpdatePlayer1Scale(float newScale)
    {
        if (player1 != null)
        {
            player1.transform.localScale = new Vector3(newScale, newScale, 1);
        }
    }


    public void UpdatePlayer2Scale(float newScale)
    {
        if (player2 != null)
        {
            player2.transform.localScale = new Vector3(newScale, newScale, 1);
        }
    }


    public void BackToPauseMenu()
    {
        if (SettingsPanel != null && CreditsPanel != null && PausePanel != null)
        {
            SettingsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void ChangePlayer1Color()
    {
        if (player1 != null)
        {
            Renderer renderer = player1.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }

    private void ChangePlayer2Color()
    {
        if (player2 != null)
        {
            Renderer renderer = player2.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }
    public void UpdatePlayer1Score()
    {
        Debug.Log("Player 1 Score Updated: " + player1Score);
        player1Score += 1;
        player1ScoreText.text = player1Score.ToString();
    }

    public void UpdatePlayer2Score()
    {
        Debug.Log("Player 1 Score Updated: " + player1Score);
        player2Score += 1;
        player2ScoreText.text = player2Score.ToString();
    }
}