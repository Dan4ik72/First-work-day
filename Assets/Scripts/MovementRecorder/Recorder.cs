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

    private void Awake()
    {
        _recordQueue = new Queue<ReplayData>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            if (_isRecording == false)
            {
                _recordQueue = new Queue<ReplayData>();
                _isDoingReplay = false;
                _isRecording = true;
                Debug.Log("Recording started");
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartReplay();
            Debug.Log("Playing record started");
        }
        */

        if (_isDoingReplay == true)
        {
            bool hasMoreFrames = _record.PlayNextFrame();

            if (hasMoreFrames == false)
                RestartReplay();
        }
    }

    private void LateUpdate()
    {
        if (_isRecording == true)
        {
            ReplayData data = new ReplayData(transform.position, transform.rotation);
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
        StartCoroutine(StartReplay());
    }

    private IEnumerator StartReplay()
    {
        _record = new Record(_recordQueue);
        _recordQueue.Clear();
        _record.InstantiateReplayObject(_replayObjectPrefab);
        _isRecording = false;

        yield return new WaitForSeconds(2f);

        _isDoingReplay = true;
    }

    private void RestartReplay()
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
