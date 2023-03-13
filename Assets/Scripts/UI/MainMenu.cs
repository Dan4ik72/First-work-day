using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CursorBehavior _cursorBehavior; 

    public void PauseGame()
    {
        _cursorBehavior.EnableCursor();

        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        _cursorBehavior.DisableCursor();

        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
