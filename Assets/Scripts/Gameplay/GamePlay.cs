using System;
using System.Collections;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay Instance
    {
        get
        {
            return _instance;
        }
    }
    public Action<uint> _updateNumberOfLives;
    public Action OnReset,OnGameBegin;
    private static GamePlay _instance;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    [SerializeField] private uint _numberOfLivesLeft = 3;

    public uint NumberOfLivesLeft
    {
        get
        {
            return _numberOfLivesLeft;
        }

        private set
        {
            _numberOfLivesLeft = value;
            _updateNumberOfLives.Invoke(_numberOfLivesLeft);
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

    }
    private void Start()
    {
        InitialSetAndStartGame();
    }

    public void InitialSetAndStartGame()
    {
        OnReset();
        StartCoroutine(BeginGame());
    }

    
    private IEnumerator BeginGame()
    {
        yield return _waitForSeconds;
        OnGameBegin();
    }
    private void FinishGame(string nameOfScene)
    {
        SceneController.Instance.LoadScene(nameOfScene);
    }
    
    public void DecriseNumberOfLives()
    {
        NumberOfLivesLeft--;
        if (NumberOfLivesLeft.Equals(0))
            FinishGame("Lose");
    }
}