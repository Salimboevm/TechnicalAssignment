using UnityEngine.UI;
using UnityEngine;

public class LabelsController : MonoBehaviour
{
    [SerializeField]
    private Text _scoreLableToUserFeedback;
    [SerializeField]
    private Text _livesLabelToUserFeedback;
    [SerializeField]
    private Text _getReadyLabelForPreparation;
    private GamePlay _gamePlayInstance;
    private void ShowGetReadyLabel()
    {
        _getReadyLabelForPreparation.enabled = true;
    }
    private void HideGetReadyLabel()
    {
        _getReadyLabelForPreparation.enabled = false;
    }
    private void SetScoreText(uint score)
    {
        _scoreLableToUserFeedback.text = score.ToString();
    }
    private void SetNumberOfLivesText(uint numberOfLivesLeft)
    {
        _livesLabelToUserFeedback.text = numberOfLivesLeft.ToString();
    }
    
    private void Awake()
    {
        _gamePlayInstance = GamePlay.Instance;

        _gamePlayInstance._updateNumberOfLives += SetNumberOfLivesText;
        _gamePlayInstance.OnReset += ShowGetReadyLabel;
        _gamePlayInstance.OnGameBegin += HideGetReadyLabel;
        ScoreManager.Instance._updateScore += SetScoreText;
    }

    private void OnDestroy()
    {
        _gamePlayInstance._updateNumberOfLives -= SetNumberOfLivesText;
        _gamePlayInstance.OnReset -= ShowGetReadyLabel;
        _gamePlayInstance.OnGameBegin -= HideGetReadyLabel;
        ScoreManager.Instance._updateScore -= SetScoreText;
    }
}
