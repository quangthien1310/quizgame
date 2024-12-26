using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    public GameObject screenQuestion;
    public static string newQuestion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PushTextOnScreen());
    }

    IEnumerator PushTextOnScreen()
    {
        yield return new WaitForSeconds(0.01f);
        screenQuestion.GetComponent<Text>().text = newQuestion;
    }
}
