using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private uint _score = 0;
    public Action<uint> _updateScore;
    private uint _numberOfBricks = 4;
    public Transform bricksParent;
    public uint Score//Destroyed bricks
    {
        get
        {
            return _score;
        }

        private set
        {
            _score = value;
            _updateScore.Invoke(_score);
        }
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _numberOfBricks = (uint)bricksParent.childCount;
    }
    public void AddScore()
    {
        Score++;
        if (Score.Equals(_numberOfBricks))
            SceneController.Instance.LoadScene("Win");
    }
}
