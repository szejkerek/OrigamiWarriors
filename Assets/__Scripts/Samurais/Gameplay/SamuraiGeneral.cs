using Cinemachine;

public class SamuraiGeneral : Samurai
{
    private void Awake()
    {
        var cam = FindObjectOfType<CinemachineVirtualCamera>();
        cam.Follow = transform;
        cam.LookAt = transform;
    }
}
