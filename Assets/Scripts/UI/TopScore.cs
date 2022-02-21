using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    [SerializeField]
    private Text _highScoreText;
    
    private void Awake()
    {
        _highScoreText.text += ScoreManager.Instance.Score.ToString();
    }
}