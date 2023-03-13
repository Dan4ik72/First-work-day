using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueRenderer : MonoBehaviour
{
    public event UnityAction DialogueStarted;
    public event UnityAction DialogueEnded;

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _line;
    [SerializeField] private Image _leftSideImage;
    [SerializeField] private Image _rightSideImage;

    [SerializeField] private float _textSpeed;

    [SerializeField] private CursorBehavior _cursorBehavior;

    private DialogueInfo _dialogueInfo;

    private Coroutine _textRenderCoroutine;

    private int _lineIndex;

    public void StartDialogue(DialogueInfo dialogueInfo)
    {
        _dialogueInfo = dialogueInfo;

        DialogueStarted?.Invoke();
        _cursorBehavior.EnableCursor();

        ResetDialogue();

        RenderNextLine();
    }

    public void RenderNextLine()
    {
        if (_textRenderCoroutine != null)
        {
            StopCoroutine(_textRenderCoroutine);
            _textRenderCoroutine = null;

            _line.text = _dialogueInfo.DialogueLines[_lineIndex - 1].Text;

            return;
        }

        if (_lineIndex > _dialogueInfo.DialogueLines.Count - 1)
        {
            EndDialogue();

            return;
        }

        SetImages();

        _line.text = string.Empty;

        _name.text = _dialogueInfo.DialogueLines[_lineIndex].Name;

        _textRenderCoroutine = StartCoroutine(RenderLine());

        _lineIndex++;
    }

    private IEnumerator RenderLine()
    {
        var waitForSecondsBetweenChars = new WaitForSecondsRealtime(_textSpeed);

        foreach (char c in _dialogueInfo.DialogueLines[_lineIndex].Text)
        {
            _line.text += c;

            yield return waitForSecondsBetweenChars;
        }

        _textRenderCoroutine = null;
    }

    private void SetImages()
    {
        Sprite leftSideIconSprite = _dialogueInfo.DialogueLines[_lineIndex].LeftSideIcon;
        Sprite rightSideIconSprite = _dialogueInfo.DialogueLines[_lineIndex].RightSideIcon;

        Color originalColor = new Color(255, 255, 255,255);
        Color transperedColor = new Color(_leftSideImage.color.r, _leftSideImage.color.g, _leftSideImage.color.b, 0f);

        if (leftSideIconSprite == null)
        {
            _leftSideImage.color = transperedColor;
        }
        else
        {
            _leftSideImage.color = originalColor;
            _leftSideImage.sprite = leftSideIconSprite;
        }

        if (rightSideIconSprite == null)
        {
            _rightSideImage.color = transperedColor;
        }
        else
        {
            _rightSideImage.color = originalColor;
            _rightSideImage.sprite = rightSideIconSprite;
        }
    }

    private void EndDialogue()
    {
        _line.text = string.Empty;

        DialogueEnded?.Invoke();
        _cursorBehavior.DisableCursor();

        gameObject.SetActive(false);
    }

    private void ResetDialogue()
    {
        _lineIndex = 0;

        _textRenderCoroutine = null;
    }
}
