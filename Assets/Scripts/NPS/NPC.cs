using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private Recorder _recorder;

    public void PlayRecord()
    {
        _recorder.StartCorutineReplay();
    }

    public void RestartReplay()
    {
        _recorder.RestartReplay();
    }
}
