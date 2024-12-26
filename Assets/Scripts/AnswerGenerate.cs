using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerGenerate : MonoBehaviour
{
    public static string answer;
    public GameObject screenAnswer;

    public GameObject wrongText;

    public AudioSource correctFX;
    public AudioSource wrongFX;
    public AudioSource congratulationFX;

    void Start()
    {
        wrongText.SetActive(false);
    }

    public void EnterButton()
    {
        answer = screenAnswer.GetComponent<TMP_InputField>().text;
        screenAnswer.GetComponent<TMP_InputField>().text = "";
        if (QuestionGenerate.actualAnswer != answer)
        {
            wrongText.SetActive(true);
            wrongFX.Play();
            StartCoroutine(HideWrongTextAfterDelay(1f));
        }
        else if (QuestionGenerate.actualAnswer == answer)
        {
            //correctFX.Play();
            if (wrongText.activeSelf)
            {
                wrongText.SetActive(false);
            }
            if (LevelManager.Instance.CurrentLevel == LevelManager.Instance.NumLevel)
            {
                congratulationFX.Play();
                LevelManager.Instance.ResetBestLevel();
                CanvasManager.Instance.ShowCompleteGameCanvas();
            }
            else
            {
                correctFX.Play();
                CanvasManager.Instance.ShowChangeLevelCanvas();
                LevelManager.Instance.CurrentLevel++;
                LevelManager.Instance.UpdateBestLevel();
            }
        }
    }

    public void ChangeLevelButton()
    {
        CanvasManager.Instance.ShowGameplayCanvas();
        QuestionGenerate.displayQuestion = false;
    }

    private IEnumerator HideWrongTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        wrongText.SetActive(false);
    }

    public void Button_1()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "1";
    }

    public void Button_2()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "2";
    }

    public void Button_3()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "3";
    }

    public void Button_4()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "4";
    }
    
    public void Button_5()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "5";
    }

    public void Button_6()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "6";
    }

    public void Button_7()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "7";
    }

    public void Button_8()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "8";
    }

    public void Button_9()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "9";
    }

    public void Button_0()
    {
        screenAnswer.GetComponent<TMP_InputField>().text += "0";
    }
}
