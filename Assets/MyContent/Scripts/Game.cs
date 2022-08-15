using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private ObstacleGenerator _obstacleGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _bird.Dying += OnGameOver;
    }

    private void OnDisable()
    {
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _bird.Dying -= OnGameOver;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _obstacleGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}

