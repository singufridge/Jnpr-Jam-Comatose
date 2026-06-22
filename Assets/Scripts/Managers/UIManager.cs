using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public BallController ballController;

    public GameManager gameManager;

    //physics
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI velocityText;

    //score
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        speedText.text = ballController.currentSpeed.ToString();
        scoreText.text = gameManager.objectsBrokenScore.ToString();
    }
}
