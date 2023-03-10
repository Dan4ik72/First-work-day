using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record
{
    public ReplayObject ReplayObject { get; private set; }

    private Queue<ReplayData> _originalQueue;
    private Queue<ReplayData> _replayQueue;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    public Record(Queue<ReplayData> recordingQueue, Vector3 startPosition, Quaternion startRotation)
    {
        _originalQueue = new Queue<ReplayData>(recordingQueue);
        _replayQueue = new Queue<ReplayData>(recordingQueue);
        _startPosition = startPosition;
        _startRotation = startRotation;
    }

    public void RestartFromBegining()
    {
        _replayQueue = new Queue<ReplayData>(_originalQueue);
        ReplayObject.transform.position = _startPosition;
        ReplayObject.transform.rotation = _startRotation;
    }

    public bool PlayNextFrame()
    {
        if (ReplayObject == null)
        {
            Debug.LogError("No replay object!");
        }

        bool hasMoreFrames = false;

        if (_replayQueue.Count != 0)
        {
            ReplayData data = _replayQueue.Dequeue();
            ReplayObject.SetDataForFrame(data);
            hasMoreFrames = true;
        }

        return hasMoreFrames;
    }

    public void InstantiateReplayObject(GameObject replayObjectPrafab)
    {
        if (_replayQueue.Count != 0)
        {
            ReplayData startingData = _replayQueue.Peek();
            ReplayObject = Object.Instantiate(replayObjectPrafab, _startPosition, Quaternion.identity).GetComponent<ReplayObject>();
        }
    }

    public void DestroyReplayObjectIfExists()
    {
        if (ReplayObject != null)
        {
            Object.Destroy(ReplayObject.gameObject);
        }
    }
}
