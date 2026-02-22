using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtnScript : MonoBehaviour
{
    public CanvasGroup currentPanel;
    public CanvasGroup nextPanel;

    public float fadeDuration = 0.5f;

    public void SwitchPanels()
    {
        StartCoroutine(FadeTransition());
    }

    IEnumerator FadeTransition()
    {
        float time = 0f;

        // Immediately disable current panel interaction
        currentPanel.interactable = false;
        currentPanel.blocksRaycasts = false;

        // Prepare next panel for fade in
        nextPanel.alpha = 0f;
        nextPanel.interactable = false;
        nextPanel.blocksRaycasts = false;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;

            currentPanel.alpha = Mathf.Lerp(1f, 0f, t);
            nextPanel.alpha = Mathf.Lerp(0f, 1f, t);

            yield return null;
        }

        // Ensure final values are exact
        currentPanel.alpha = 0f;
        currentPanel.interactable = false;
        currentPanel.blocksRaycasts = false;

        nextPanel.alpha = 1f;
        nextPanel.interactable = true;
        nextPanel.blocksRaycasts = true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
