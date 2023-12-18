using UnityEngine;
using TMPro;
using System.Collections;

public class CodeEmulator : MonoBehaviour
{
    public TextMeshProUGUI codeText; // Use TextMeshProUGUI instead of TextMeshPro
    public string codeToEmulate = "void Start()\n{\n    // Your code here\n}";

    public float typingSpeed = 0.05f; // Adjust the speed as needed
    public int charactersPerFrame = 1; // Number of characters to write at a time
    private bool isPaused = false;

    private RectTransform rectTransform;
    private float originalY;

    private void Start()
    {
        StartCoroutine(EmulateCode());
        rectTransform = codeText.rectTransform;
        originalY = rectTransform.anchoredPosition.y;
    }

    private void Update()
    {
        // Toggle pause with a checkbox in the inspector
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPaused = !isPaused;
        }
    }

    private IEnumerator EmulateCode()
    {
        int length = 0;

        while (true)
        {
            if (!isPaused)
            {
                length += charactersPerFrame;
                string displayedText = codeToEmulate.Substring(0, Mathf.Min(length, codeToEmulate.Length));

                codeText.text = displayedText;

                if (length >= codeToEmulate.Length)
                {
                    yield return new WaitForSeconds(1.0f); // Wait for a moment before resetting
                    length = 0;
                }
                else
                {
                    yield return new WaitForSeconds(typingSpeed);

                    // Check if the text has reached the bottom of the box
                    TMP_TextInfo textInfo = codeText.textInfo;
                    TMP_LineInfo lastLine = textInfo.lineInfo[textInfo.lineCount - 1];

                    // Move text up by adjusting the anchored position
                    float lineHeight = lastLine.lineHeight - lastLine.descender; // Use lineHeight to move up by the actual line height
                    rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, originalY + lineHeight); // Adjust as needed
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
