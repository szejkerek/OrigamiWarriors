using Cinemachine;
using UnityEngine;

public class SamuraiStylizer : MonoBehaviour
{
    public SamuraiRenderers Renderers { get; private set; }

    public CinemachineVirtualCamera cam { get; private set; }

    private void Awake()
    {
        Renderers = GetComponentInChildren<SamuraiRenderers>();
        cam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        Renderers.transform.rotation = Quaternion.LookRotation(Renderers.transform.position - cam.transform.position);

    }
}