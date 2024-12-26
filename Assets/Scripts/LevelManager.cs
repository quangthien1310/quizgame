using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public const int numLevel = 30; // Tổng số lượng Level trong game (hằng số)

    public int currentLevel = 1; // Level hiện tại

    public GameObject levelText;

    void Update()
    {
        levelText.GetComponent<Text>().text = "Level " + currentLevel;
    }
    
    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            if (value >= 1 && value <= numLevel) // Giới hạn giá trị trong khoảng hợp lệ
            {
                currentLevel = value;
            }
            else
            {
                Debug.LogWarning("Giá trị CurrentLevel không hợp lệ!");
            }
        }
    }

    public int NumLevel
    {
        get { return numLevel; }
    }

    // Level tốt nhất đạt được (lưu trữ bằng PlayerPrefs)
    public int BestLevel
    {
        get { return PlayerPrefs.GetInt("BestLevel", 1); }
        set
        {
            if (value >= 1 && value <= numLevel && value > BestLevel)
            {
                PlayerPrefs.SetInt("BestLevel", value);
                PlayerPrefs.Save();
            }
        }
    }

    // Singleton để đảm bảo chỉ có một instance của LevelManager
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không phá hủy LevelManager khi chuyển Scene
        }
        else
        {
            Destroy(gameObject); // Đảm bảo chỉ có một instance
        }
    }

    // Hàm kiểm tra và cập nhật BestLevel
    public void UpdateBestLevel()
    {
        if (currentLevel > BestLevel)
        {
            BestLevel = currentLevel;
        }
    }

    // Reset BestLevel (nếu cần)
    public void ResetBestLevel()
    {
        PlayerPrefs.DeleteKey("BestLevel");
        PlayerPrefs.Save();
    }
}
