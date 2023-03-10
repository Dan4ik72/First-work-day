using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [SerializeField] private string _name;
    [SerializeField, TextArea(1, 5)] private string _text;
    [SerializeField] private Sprite _leftSideIcon;
    [SerializeField] private Sprite _rightSideIcon;

    public string Name => _name;
    public string Text => _text;
    public Sprite LeftSideIcon => _leftSideIcon;
    public Sprite RightSideIcon => _rightSideIcon;
}
