using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private WaitForSeconds _delay = new WaitForSeconds(10f);

    private void Start()
    {
        StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound()
    {
        while (true)
        {
            yield return _delay;

            _audioSource.Play();
            _delay = new WaitForSeconds(Random.Range(5f, 20f));

            yield return _delay;
        }
    }
}
