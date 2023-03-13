using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private Game _game;

    private void OnTriggerEnter(Collider other)
    {
        CheckIfPlayer(other);
    }

    private void Start()
    {
        _game = FindObjectOfType<Game>();
    }

    private void CheckIfPlayer(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (Physics.Raycast(transform.parent.position, (player.transform.position - transform.parent.position), out RaycastHit hit) == true)
            {
                if (hit.transform.TryGetComponent<Player>(out Player p) == true)
                {
                    _game.ShowSpottedPanel();
                    OnPlayerEntered();
                }
            }
        }
    }

    private void OnPlayerEntered()
    {
        Debug.Log("Oh nooo");
    }
}
