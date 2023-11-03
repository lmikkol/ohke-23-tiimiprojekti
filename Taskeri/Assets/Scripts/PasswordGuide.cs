using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PasswordGuide : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_Text textObject;
    public Image BG;

    public float fadeDuration = 1.0f; // Duration of the fade effect in seconds
    private bool isFading = false;

    private void Start()
    {
        // Make the text initially transparent
        SetTextAlpha(0);
    }

    private void Update()
    {
        // Check if either of the input fields is focused
        bool isFocused = inputField1.isFocused || inputField2.isFocused;

        if (isFocused && !isFading)
        {
            // Start the fade-in coroutine
            StartCoroutine(FadeText(true));
        }
        else if (!isFocused && !isFading)
        {
            // Start the fade-out coroutine
            StartCoroutine(FadeText(false));
        }
        Color textColor = textObject.color;
        Color imageColor = BG.color;

        imageColor.a = textColor.a; // Set the image's alpha to match the text's alpha

        BG.color = imageColor;
    }

    private IEnumerator FadeText(bool fadeIn)
    {
        isFading = true;

        float startAlpha = textObject.color.a;
        float targetAlpha = fadeIn ? 1.0f : 0.0f;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            SetTextAlpha(newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetTextAlpha(targetAlpha);
        isFading = false;
    }

    private void SetTextAlpha(float alpha)
    {
        Color textColor = textObject.color;
        textColor.a = alpha;
        textObject.color = textColor;
    }
}
