using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //scripts
    public Rigidbody playerPhysics;
    public GameManager gameManager;

    [Header("Player Score")]
    public int objectsDamageScore;

    [Space(10)]
    [Header("Ham-o-meter")]
    [SerializeField] private float maxSpeed = 0.0f;
    [SerializeField] private float minSpeedAngle;
    [SerializeField] private float maxSpeedAngle;
    private float speed = 0.0f;

    [Space(5)]
    public RectTransform meterPaw;

    [Space(10)]
    [Header("Score")]
    public TextMeshProUGUI scoreText;

    [Space(10)]
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    private bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) { Pause(); }
            else if (isPaused) { Resume(); }
        }

        //Hamometer
        speed = playerPhysics.linearVelocity.magnitude * 3.6f;
        if (meterPaw != null)
        {
            meterPaw.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedAngle, maxSpeedAngle, speed / maxSpeed));
        }
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

    public void UpdateScore(int damage)
    {
        objectsDamageScore += damage;
        scoreText.text = objectsDamageScore.ToString();
        //to add: animation trigger
    }
}
