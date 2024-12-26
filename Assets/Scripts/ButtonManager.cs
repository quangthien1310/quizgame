using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void PlayButton()
    {
        LevelManager.Instance.CurrentLevel = LevelManager.Instance.BestLevel;
        QuestionGenerate.displayQuestion = false;
        CanvasManager.Instance.ShowGameplayCanvas();
    }

    public void LevelButton()
    {
        CanvasManager.Instance.ShowLevelStageCanvas();
    }

    public void BackButton()
    {
        CanvasManager.Instance.ShowMenuCanvas();
    }
}
