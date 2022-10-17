using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    #region Singlton
    public static Level Instance;
    private void Awake()
    {
        Instance = this;
        //if (!Instance)
        //{
        //    Instance = this;
        //} else
        //{
        //    throw new Exception();
        //}
    }
    #endregion

    [SerializeField] private GameObject _gameOverPanel, _victoryPanel;

    public static void ShowVictoryPanel()
    {
        Instance._victoryPanel.SetActive(true);
    }
    public static void ShowGameOverPanel()
    {
        Instance._gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}