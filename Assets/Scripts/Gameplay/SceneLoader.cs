using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]private string _sceneName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneController.Instance.LoadScene(_sceneName);
    }
}
