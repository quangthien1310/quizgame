using System.Collections;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance; // Singleton

    public GameObject menuCanvas;
    public GameObject gameplayCanvas;
    public GameObject changeLevelCanvas;
    public GameObject levelStageCanvas;
    public GameObject introCanvas;

    public GameObject completeGameCanvas;

    void Awake()
    {
        // Đảm bảo chỉ có một instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(ShowMenuAfterIntro());
    }

    public IEnumerator ShowMenuAfterIntro()
    {
        ShowIntroCanvas();
        yield return new WaitForSeconds(4f);
        ShowMenuCanvas();
    }

    public void ShowIntroCanvas()
    {
        introCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        changeLevelCanvas.SetActive(false);
        levelStageCanvas.SetActive(false);
        completeGameCanvas.SetActive(false);
    }

    public void ShowMenuCanvas()
    {
        introCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        gameplayCanvas.SetActive(false);
        changeLevelCanvas.SetActive(false);
        levelStageCanvas.SetActive(false);
        completeGameCanvas.SetActive(false);
    }

    public void ShowGameplayCanvas()
    {
        introCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        gameplayCanvas.SetActive(true);
        changeLevelCanvas.SetActive(false);
        levelStageCanvas.SetActive(false);
        completeGameCanvas.SetActive(false);
    }

    public void ShowChangeLevelCanvas()
    {
        introCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        changeLevelCanvas.SetActive(true);
        levelStageCanvas.SetActive(false);
        completeGameCanvas.SetActive(false);
    }

    public void ShowLevelStageCanvas()
    {
        introCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        changeLevelCanvas.SetActive(false);
        levelStageCanvas.SetActive(true);
        completeGameCanvas.SetActive(false);
    }

    public void ShowCompleteGameCanvas()
    {
        introCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        changeLevelCanvas.SetActive(false);
        levelStageCanvas.SetActive(false);
        completeGameCanvas.SetActive(true);
    }

    public void HideAllCanvases()
    {
        introCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        changeLevelCanvas.SetActive(false);
        levelStageCanvas.SetActive(false);
        completeGameCanvas.SetActive(false);
    }
}
