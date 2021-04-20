using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float respawnTime = 5;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public IEnumerator HideForTime()
    {
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
    }
}
