using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private ExperimentInteraction _experimentInteraction;
    [SerializeField] private Transform _timeMachineBarrier;
    [SerializeField] private TimeMachineIntaraction _timeMachine;
    [SerializeField] private GameObject _spottedPanel;
    [SerializeField] private GameObject _notInTimePanel;
    [SerializeField] private GameObject _donePanel;
    [SerializeField] private Player _player;
    [SerializeField] private Interactable[] _quests;
    [SerializeField] private NPCTriggerReactor _NPCTriggerReactor;
    [SerializeField] private NPCTriggerAfterExplosion _NPCTriggerAfterExplosion;

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
        _timeMachine.Restarted += OnRestarted;
        _NPCTriggerReactor.NPCArrived += OnNPCArrived;
    }

    private void OnNPCArrived()
    {
        _experimentInteraction.ResetByDefault();
    }

    private void OnDisable()
    {
        _experimentInteraction.Explosion -= OnExplosion;
        _timeMachine.Restarted -= OnRestarted;
        _NPCTriggerReactor.NPCArrived -= OnNPCArrived;
    }

    private void Start()
    {
        _timeMachineBarrierPosition = _timeMachineBarrier.position;
        _timeMachineBarrierRotation = _timeMachineBarrier.rotation;
        _experimentInteraction.DisableQuest();

        foreach (var quest in _quests)
        {
            quest.DisableQuest();
        }
    }

    private void OnExplosion()
    {
        _timeMachineBarrier.GetComponent<MeshCollider>().enabled = false;
        _timeMachineBarrier.rotation = Quaternion.Euler(84.23f, 184.187f, 0f);
        _NPCTriggerAfterExplosion.NPCMover.enabled = true;
        Destroy(_NPCTriggerAfterExplosion.gameObject);
        _player.Radar.DeletePointersAndClearTargets();
        _timeMachine.TurnOn();
    }

    private void OnRestarted()
    {
        _experimentInteraction.StopSound();
        ResetTimeMachineBarrier();
    }

    public void RestartOnSpoted()
    {
        _player.GetComponent<Movement>().enabled = true;
        _timeMachine.RestartReplays();

        ResetTimeMachineBarrier();
        RestartQuests();
    }

    public void RestartQuests()
    {
        foreach (var quest in _quests)
        {
            quest.ResetByDefault();
        }
    }

    public void ResetTimeMachineBarrier()
    {
        _timeMachineBarrier.GetComponent<MeshCollider>().enabled = true;
        _timeMachineBarrier.position = _timeMachineBarrierPosition;
        _timeMachineBarrier.rotation = _timeMachineBarrierRotation;
    }

    public void ShowSpottedPanel()
    {
        _spottedPanel.SetActive(true);
        _player.GetComponent<Movement>().enabled = false;
    }

    public void ShowNotInTimePanel()
    {
        if (_spottedPanel.active == true)
            return;

        _notInTimePanel.SetActive(true);
        _player.GetComponent<Movement>().enabled = false;
    }

    public void ShowDonePanel()
    {
        _donePanel.SetActive(true);
        _player.GetComponent<Movement>().enabled = false;
    }

    public bool IsQuestsDone()
    {
        foreach (var quest in _quests)
        {
            if (quest.IsAvailable == true)
                return false;
        }

        return true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
