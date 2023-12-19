using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CodeEmulator : MonoBehaviour
{
    public ScrollRect scrollRect;
    public TextMeshProUGUI codeText;
    public string codeToEmulate = "public class CodeEmulator : MonoBehaviour\n{\n    public ScrollRect scrollRect;\n    public TextMeshProUGUI codeText;\n    public string codeToEmulate = 'void Start(){    // Your code here\n}';\n\n    public float typingSpeed = 0.05f; // Adjust the speed as needed\n   \npublic int charactersPerFrame = 1; // Number of characters to write at a time\n   \nprivate bool isPaused = false;\n\n    private RectTransform contentRect;\n    private float scrollSpeed = 0.02f; // Adjust the scroll speed as needed\n\n    private void Start()\n    {\n        contentRect = scrollRect.content.GetComponent<RectTransform>();\n        StartCoroutine(EmulateCode());\n    }\n\n    private void Update()\n    {\n        // Toggle pause with a checkbox in the inspector\n        if (Input.GetKeyDown(KeyCode.Space))\n        {\n            isPaused = !isPaused;\n        }\n    }\n\n    private IEnumerator EmulateCode()\n    {\n        int length = 0;\n\n        while (true)\n        {\n            if (!isPaused)\n            {\n                length += charactersPerFrame;\n                string displayedText = codeToEmulate.Substring(0, Mathf.Min(length, codeToEmulate.Length));\n\n                codeText.text = displayedText;\n\n                if (length >= codeToEmulate.Length)\n                {                    yield return new WaitForSeconds(1.0f); // Wait for a moment before resetting\n                    length = 0;\n                    contentRect.anchoredPosition = Vector2.zero; // Reset scroll position\n                }\n                else\n                {\n                    yield return new WaitForSeconds(typingSpeed);\n\n                    // Check if the text has reached the bottom of the box\n                    TMP_TextInfo textInfo = codeText.textInfo;\n                    TMP_LineInfo lastLine = textInfo.lineInfo[textInfo.lineCount - 1];\n\n                    // Move text up by adjusting the content size\n      \n             float lineHeight = lastLine.lineHeight - lastLine.descender; // Use lineHeight to move up by the actual line height\n                    contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, contentRect.sizeDelta.y + lineHeight); // Adjust as needed\n\n                    // Scroll down gradually\n                    scrollRect.verticalNormalizedPosition -= scrollSpeed;\n\n                    // Wait for a moment before scrolling agai\n";

    public float typingSpeed = 0.05f; // Adjust the speed as needed
    private bool isPaused = false;

    private RectTransform contentRect;

    private void Start()
    {
        contentRect = scrollRect.content.GetComponent<RectTransform>();
        StartCoroutine(EmulateCode());
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

        while (length <= codeToEmulate.Length)
        {
            if (!isPaused)
            {
                string displayedText = codeToEmulate.Substring(0, length);
                codeText.text = displayedText;

                // Move text up by adjusting the content size
                contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, codeText.preferredHeight);

                // Scroll to the bottom to always show the last line
                scrollRect.verticalNormalizedPosition = 0;

                yield return new WaitForSeconds(typingSpeed);
                length++;
            }
            else
            {
                yield return null;
            }
        }
    }
}
