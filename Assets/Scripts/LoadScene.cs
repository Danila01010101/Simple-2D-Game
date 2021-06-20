using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private Canvas _loadScreen;
    public void LoadFirstScene()
    {
        ShowLoadScreen();
        Invoke("RestartScene", 2f);
    }
    private void ShowLoadScreen()
    {
        _loadScreen.GetComponentInChildren<Image>().DOFade(1f, 0.2f);
        _loadScreen.GetComponentInChildren<Text>().DOFade(1f, 0.2f);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
