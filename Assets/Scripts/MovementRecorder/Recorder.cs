using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Recorder : MonoBehaviour
{
    [SerializeField] private GameObject _replayObjectPrefab;

    private Queue<ReplayData> _recordQueue;
    private bool _isDoingReplay = false;
    private bool _isRecording = true;
    private Record _record;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Awake()
    {
        _recordQueue = new Queue<ReplayData>();
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        if (_isDoingReplay == true)
        {
            bool hasMoreFrames = _record.PlayNextFrame();

            if (hasMoreFrames == false)
            {
                if (Game.Instance.IsQuestsDone())
                {

                }
                else
                {
                    Game.Instance.ShowNotInTimePanel();
                }

                _isDoingReplay = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (_isRecording == true)
        {
            ReplayData data = new ReplayData(transform.position, transform.rotation, Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
            RecordReplayFrame(data);
        }
    }

    public void RecordReplayFrame(ReplayData data)
    {
        _recordQueue.Enqueue(data);
    }

    public void StopRecording()
    {
        _isRecording = false;
    }

    public void StartCorutineReplay()
    {
        StartCoroutine(PlayReplay());
    }

    private IEnumerator PlayReplay()
    {
        _record = new Record(_recordQueue, _startPosition, _startRotation);
        _recordQueue.Clear();
        _record.InstantiateReplayObject(_replayObjectPrefab);
        _isRecording = false;

        yield return new WaitForSeconds(2f);

        _isDoingReplay = true;
    }

    public void RestartReplay()
    {
        _isDoingReplay = true;
        _record.RestartFromBegining();
    }

    private void ResetRecorder()
    {
        _isDoingReplay = false;
        _recordQueue.Clear();
        _record.DestroyReplayObjectIfExists();
        _record = null;
    }
}
