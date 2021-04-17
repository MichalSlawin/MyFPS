using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
