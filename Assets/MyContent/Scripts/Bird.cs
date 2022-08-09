using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private int _score;
    private BirdMover _mover;

    private void Start() =>
        _mover = GetComponent<BirdMover>();
    
    private void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBird();
    }

    public void Die() =>
        Time.timeScale = 0f;
    
}