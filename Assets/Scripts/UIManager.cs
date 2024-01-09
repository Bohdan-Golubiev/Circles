using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject victoryPanel;
    public Button retryButton;
    public Button menuButton;
    public Text victoryText;

    private GameManager gameManager;
    private CanvasManager canvasManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        Image panelImage = victoryPanel.GetComponent<Image>();
        Color panelColor = panelImage.color;
        panelColor.a = 1.0f;
        panelImage.color = panelColor;


        gameManager = FindObjectOfType<GameManager>();
        canvasManager = FindObjectOfType<CanvasManager>();

        victoryText.text = "";
        victoryPanel.SetActive(false);
    }

    public void ShowVictoryMessage()
    {
        Image panelImage = victoryPanel.GetComponent<Image>();
        Color panelColor = panelImage.color;
        panelColor.a = 1.0f;
        panelImage.color = panelColor;
        if (canvasManager != null)
        {
            canvasManager.ShowCanvas();
        }

        victoryText.text = "You win!";
        victoryPanel.SetActive(true);
        EnableButtons();
    }

    public void EnableButtons()
    {
        retryButton.interactable = true;
        menuButton.interactable = true;
    }

    public void RetryButtonPressed()
    {
        gameManager.ResetGame();
    }

    public void MenuButtonPressed()
    {
        gameManager.LoadMainMenu();
    }
}