using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private Audio _audio;

    private Bird _bird;

    private void Start() =>
        _bird = GetComponent<Bird>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ScoreZone scoreZone))
        {
            _bird.AddScore();
            _audio.PlayScorePoint();
        }
        
        else
            _bird.Die();
    }
    
}
