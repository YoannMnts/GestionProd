using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SwitchScene : MonoBehaviour
{
    private BoxCollider collider = new BoxCollider();
    [SerializeField]
    private int sceneIndex;

    private void Reset()
    {
        collider = GetComponent<BoxCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
