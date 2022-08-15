using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_moveSpeed, 0);
            transform.rotation = _maxRotation;
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
