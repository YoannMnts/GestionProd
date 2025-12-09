using System;
using CharacterController;
using GestionFolder.Scenes.Group1.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonInteraction : MonoBehaviour, IInteractable
{
    public bool isDone { get; private set; } = false;
    [SerializeField]
    private FPSCharacter character;
    [SerializeField]
    private NoGravityZone[] noGravityZones;
    [SerializeField]
    private GameObject rootSpawnGO;
    [SerializeField]
    private GameObject rootGravityGO;
    [SerializeField]
    private GameObject doorGO;

    public void Interact()
    {
        Debug.Log("aaaa");
        character.ActivateGravity();
        foreach (var noGravityZone in noGravityZones)
        {
            noGravityZone.gameObject.SetActive(false);
        }

        var spawnedChilds = rootSpawnGO.GetComponentsInChildren<MeshRenderer>();
        foreach (var child in spawnedChilds)
        {
            Debug.Log(child);
            child.enabled = true;
            child.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        doorGO.SetActive(false);
        
        var gravityChilds = rootGravityGO.GetComponentsInChildren<MeshRenderer>();
        foreach (var child in gravityChilds)
        {
            child.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //child.gameObject.GetComponent<Animator>().enabled = true;
        }
        
        isDone = true;
    }
}
