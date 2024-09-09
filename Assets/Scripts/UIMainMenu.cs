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

    [SerializeField] private Slider player1ScaleSlider; // Slider para la escala del jugador 1
    [SerializeField] private Slider player2ScaleSlider; // Slider para la escala del jugador 2

    [SerializeField] private Text player1SpeedText;
    [SerializeField] private Text player2SpeedText;

    private PlayerController player1Movement;
    private PlayerController player2Movement;

    private void Awake()
    {
        player1Movement = player1.GetComponent<PlayerController>();
        player2Movement = player2.GetComponent<PlayerController>();

        player1SpeedSlider.onValueChanged.AddListener(UpdatePlayer1Speed);
        player2SpeedSlider.onValueChanged.AddListener(UpdatePlayer2Speed);

        player1ScaleSlider.onValueChanged.AddListener(UpdatePlayer1Scale); // Añadido
        player2ScaleSlider.onValueChanged.AddListener(UpdatePlayer2Scale); // Añadido

        PlayButton.onClick.AddListener(OnPlayButtonClicked);
        SettingsButton.onClick.AddListener(OnSettingsButtonClicked);
        CreditsButton.onClick.AddListener(OnCreditsButtonClicked);
        BackFromSettingsButton.onClick.AddListener(BackToPauseMenu);
        BackFromCreditsButton.onClick.AddListener(BackToPauseMenu);
        ExitButton.onClick.AddListener(OnExitButtonClicked);

        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);

        // Inicializar sliders de escala
        player1ScaleSlider.minValue = 0.5f;  // Valor mínimo de escala
        player1ScaleSlider.maxValue = 2.0f;  // Valor máximo de escala
        player1ScaleSlider.value = 1.0f;     // Valor por defecto

        player2ScaleSlider.minValue = 0.5f;  // Valor mínimo de escala
        player2ScaleSlider.maxValue = 2.0f;  // Valor máximo de escala
        player2ScaleSlider.value = 1.0f;     // Valor por defecto
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

    // Nueva función para actualizar la escala del jugador 1
    public void UpdatePlayer1Scale(float newScale)
    {
        if (player1 != null)
        {
            player1.transform.localScale = new Vector3(newScale, newScale, 1);
        }
    }

    // Nueva función para actualizar la escala del jugador 2
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
        }
    }
}