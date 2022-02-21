using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private Rigidbody2D _playerRigidbody2D;
    private Vector3 _initialPos;
    private void Awake()
    {
       _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _initialPos = transform.position;
        GamePlay.Instance.OnReset += InitialState;
    }
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerRigidbody2D.isKinematic = false;
            _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + Vector2.left * _velocity);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerRigidbody2D.isKinematic = false;
            _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + Vector2.right * _velocity);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _playerRigidbody2D.isKinematic = true;
           
        }
    }
    public void InitialState()
    {
        transform.position = _initialPos;
    }
    private void OnDestroy()
    {
        GamePlay.Instance.OnReset -= InitialState;
    }
}