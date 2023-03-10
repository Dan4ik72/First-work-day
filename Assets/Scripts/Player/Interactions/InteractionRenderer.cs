using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionRenderer : MonoBehaviour
{
    [SerializeField] private TMP_Text _interactionDescription;
    [SerializeField] private Image _interactionIcon;

    private void Awake()
    {
        DisableRender();        
    }

    public void RenderInteraction(string description, Sprite icon)
    {
        _interactionDescription.text = description;
        _interactionIcon.sprite = icon;

        Render();
    }

    public void DisableRender()
    {
        _interactionDescription.gameObject.SetActive(false);
        _interactionIcon.gameObject.SetActive(false);
    }

    private void Render()
    {
        _interactionDescription.gameObject.SetActive(true);
        _interactionIcon.gameObject.SetActive(true);
    }

}
