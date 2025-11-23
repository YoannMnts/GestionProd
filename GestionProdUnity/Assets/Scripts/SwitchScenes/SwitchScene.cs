using System;
using ECM2;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;
    [SerializeField]
    private Vector3 posAfterSwitch;
    [SerializeField]
    private Quaternion rotAfterSwitch;
    
    private BoxCollider collider = new BoxCollider();
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Reset()
    {
        collider = GetComponent<BoxCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = posAfterSwitch;
            player.transform.rotation = rotAfterSwitch;
            player.GetComponent<CharacterMovement>().velocity = Vector3.zero;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
