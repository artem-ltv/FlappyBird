using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    public event UnityAction Dying;
    public event UnityAction<int> ScoreChanged;

    private int _score;
    private BirdMover _mover;

    private void Start() =>
        _mover = GetComponent<BirdMover>();
    
    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetBird();
    }

    public void Die() =>
        Dying?.Invoke();


    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}