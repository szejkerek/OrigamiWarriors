using Cinemachine;
using UnityEngine;

public class SamuraiStylizer : MonoBehaviour
{
    [field: SerializeField] public SamuraiRenderers Renderers { get; private set; }

    public CinemachineVirtualCamera cam;

    private void Update()
    {
        Renderers.transform.rotation = Quaternion.LookRotation(Renderers.transform.position - cam.transform.position);

    }
}