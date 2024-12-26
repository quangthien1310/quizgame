using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    public static string actualAnswer; // Đáp án đúng
    public static string currentQuestion; // Câu hỏi hiện tại
    public static string currentQuestionID; // ID của câu hỏi hiện tại
    public static bool displayQuestion = false;

    private List<string> questions = new List<string>(); // Danh sách câu hỏi
    private List<string> answers = new List<string>(); // Danh sách đáp án
    private List<string> questionIDs = new List<string>(); // Danh sách ID câu hỏi

    void Start()
    {
        LoadQuestionsFromFile(); // Đọc dữ liệu từ file
        //GenerateQuestion(); // Tạo câu hỏi cho currentLevel
    }

    void Update()
    {
        if (CanvasManager.Instance.gameplayCanvas.activeSelf)
        {
            if (!displayQuestion)
            {
                GenerateQuestion(); // Chỉ tạo câu hỏi khi chưa hiển thị
            }
        }
    }

    void LoadQuestionsFromFile()
    {
        // Tải file từ Resources
        TextAsset questionData = Resources.Load<TextAsset>("questions"); // Không cần .txt
        if (questionData != null)
        {
            string[] blocks = questionData.text.Split(new string[] { "===" }, System.StringSplitOptions.RemoveEmptyEntries); // Chia theo `===`
            foreach (string block in blocks)
            {
                string[] lines = block.Trim().Split('\n'); // Lấy từng dòng trong một block
                string questionID = ""; // Chỉ số câu hỏi
                string question = ""; // Nội dung câu hỏi
                string answer = "";

                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == 0) // Dòng đầu tiên là ID câu hỏi
                    {
                        questionID = lines[i].Trim();
                    }
                    else if (lines[i].Contains("|")) // Dòng chứa đáp án
                    {
                        answer = lines[i].Split('|')[1].Trim(); // Lấy phần sau dấu `|`
                    }
                    else
                    {
                        question += lines[i] + "\n"; // Thêm vào nội dung câu hỏi
                    }
                }

                if (!string.IsNullOrEmpty(questionID) && !string.IsNullOrEmpty(question) && !string.IsNullOrEmpty(answer))
                {
                    questionIDs.Add(questionID); // Lưu ID câu hỏi
                    questions.Add(question.Trim());
                    answers.Add(answer);
                }
            }
        }
        else
        {
            Debug.LogError("Không tìm thấy file questions.txt trong Resources.");
        }
    }

    void GenerateQuestion()
    {
        int currentLevel = LevelManager.Instance.CurrentLevel; // Lấy Level hiện tại từ LevelManager
        if (currentLevel > 0 && currentLevel <= questions.Count)
        {
            int index = currentLevel - 1; // Chỉ số trong danh sách bắt đầu từ 0
            Debug.Log(currentLevel);
            // Lấy câu hỏi, ID, và đáp án theo currentLevel
            currentQuestionID = questionIDs[index];
            currentQuestion = questions[index];
            actualAnswer = answers[index];

            // Hiển thị câu hỏi
            QuestionDisplay.newQuestion = $"{currentQuestion}";
            displayQuestion = true;
        }
        else
        {
            Debug.LogError($"Level {currentLevel} vượt quá số lượng câu hỏi ({questions.Count}).");
        }
    }

    public void OnCorrectAnswer()
    {
        displayQuestion = false;

        // Cập nhật bestLevel nếu vượt qua level hiện tại
        LevelManager.Instance.UpdateBestLevel();
    }
}
