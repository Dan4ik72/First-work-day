using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RestartPowerSupplyInteraction : Interactable
{
    public event UnityAction PowerSupplyRestarted;

    [SerializeField] private GameObject _bulb;
    [SerializeField] private Material _greenBulbMaterial;
    [SerializeField] private Material _redBulbMaterial;

    [SerializeField] private Color _redLightColor;
    [SerializeField] private Color _greenLightColor;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioServerOn;

    private MeshRenderer _bulbMeshRenderer;
    private Light _bulbLight;

    private Coroutine _coroutine;

    private void Awake()
    {
        _bulbMeshRenderer = _bulb.gameObject.GetComponent<MeshRenderer>();
        _bulbLight = _bulb.gameObject.GetComponent<Light>();
    }

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioServerOn);
        _bulbMeshRenderer.material = _greenBulbMaterial;
        _bulbLight.color = _greenLightColor;
        IsAvailable = false;

        PowerSupplyRestarted?.Invoke();
        //_coroutine = StartCoroutine(RestartPowerSupply());
    }

    private IEnumerator RestartPowerSupply()
    {
        yield return new WaitForSecondsRealtime(3f);

        _bulbMeshRenderer.material = _greenBulbMaterial;
        _bulbLight.color = _greenLightColor;
        IsAvailable = false;

        PowerSupplyRestarted?.Invoke();
    }

    public override void ResetByDefault()
    {
        base.ResetByDefault();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _bulbLight.color = _redLightColor;
        _bulbMeshRenderer.material = _redBulbMaterial;
    }
}
