using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //scripts
    public BallController ballController;
    public GameManager gameManager;

    [Space(10)]

    //physics
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI velocityText;

    //score
    [SerializeField] private TextMeshProUGUI scoreText;

    //pause menu
    [SerializeField] private GameObject pauseMenu;

    [Space(10)]
    public bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) { Pause(); }
            else if (isPaused) { Resume(); }
        }
    }

    public void UpdateText()
    {
        speedText.text = ballController.currentSpeed.ToString();
        scoreText.text = gameManager.objectsBrokenScore.ToString();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
