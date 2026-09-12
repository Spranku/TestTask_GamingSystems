using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button exitButton;
    /* [SerializeField]
    *  private Button loadButton;
    *  [SerializeField]
    *  private Button saveButton;
    */

    private void OnEnable()
    {
        if (playButton != null) playButton.onClick.AddListener(OnPlayClick);
        if (exitButton != null) exitButton.onClick.AddListener(OnExitClick);
    }

    private void OnPlayClick()
    {
        Debug.Log("MenuUI::OnPlayClicked - LoadScene");
        SceneManager.LoadScene("GameLevel");
    }

    private void OnExitClick()
    {
        Debug.Log("MenuUI::OnExitClicked - Quit");
        Application.Quit();
    }

    private void OnDisable()
    {
        if (playButton != null) playButton.onClick.RemoveListener(OnPlayClick);
        if (exitButton != null) exitButton.onClick.RemoveListener(OnExitClick);
    }
}
