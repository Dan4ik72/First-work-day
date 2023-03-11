using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private ExperimentInteraction _experimentInteraction;
    [SerializeField] private Transform _timeMachineBarrier;
    [SerializeField] private TimeMachineIntaraction _timeMachine;
    [SerializeField] private GameObject _spottedPanel;
    [SerializeField] private GameObject _notInTimePanel;
    [SerializeField] private Player _player;

    public static Game Instance;
    private Vector3 _timeMachineBarrierPosition;
    private Quaternion _timeMachineBarrierRotation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _experimentInteraction.Explosion += OnExplosion;
    }

    private void OnDisable()
    {
        _experimentInteraction.Explosion -= OnExplosion;
    }

    private void Start()
    {
        _timeMachineBarrierPosition = _timeMachineBarrier.position;
        _timeMachineBarrierRotation = _timeMachineBarrier.rotation;
    }

    private void OnExplosion()
    {
        _timeMachineBarrier.GetComponent<MeshCollider>().enabled = false;
        _timeMachineBarrier.rotation = Quaternion.Euler(84.23f, 184.187f, 0f);
    }

    public void RestartOnSpoted()
    {
        _player.GetComponent<Movement>().enabled = true;
        _timeMachine.RestartReplays();
    }

    public void ShowSpottedPanel()
    {
        _spottedPanel.SetActive(true);
        _player.GetComponent<Movement>().enabled = false;
    }

    public void ShowNotInTimePanel()
    {
        _notInTimePanel.SetActive(true);
        _player.GetComponent<Movement>().enabled = false;
    }
}
