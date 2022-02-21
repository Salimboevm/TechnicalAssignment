using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float _speedOfBall = 1f;
    private Rigidbody2D _ballRigidbody2D;
    private GamePlay _gamePlayInstance;
    private void Awake()
    {
        _gamePlayInstance = GamePlay.Instance;
        _ballRigidbody2D = GetComponent<Rigidbody2D>();
        _gamePlayInstance.OnReset += InitialState;
        _gamePlayInstance.OnGameBegin += SetDirection;
    }

    public void SetDirection()
    {
        _ballRigidbody2D.velocity = Random.insideUnitCircle * _speedOfBall;
    }

    private void Update()
    {
        _ballRigidbody2D.velocity = _ballRigidbody2D.velocity.normalized * _speedOfBall;
    }

    public void InitialState()
    {
        _ballRigidbody2D.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }
    private void OnDestroy()
    {
        _gamePlayInstance.OnReset -= InitialState;
        _gamePlayInstance.OnGameBegin -= SetDirection;
    }
}