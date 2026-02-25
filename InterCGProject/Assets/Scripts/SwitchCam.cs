using UnityEngine;
using Unity.Cinemachine;

public class SwitchCam : MonoBehaviour
{
    //CinemachineCamera cam;
    public int num = 0;
    Rigidbody rb;
    public CamManager camManager;
    //this determines if this area triggers the cutscene
    public bool isCutscene = false;
    //got help from: https://medium.com/@austinjy13/using-triggers-to-change-cameras-unity-cinemachine-fb4825fa1885

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        //cam = GetComponent<CinemachineCamera>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& isCutscene == false)
            camManager.switchCamera(num);
        else if (other.CompareTag("Player") && isCutscene == true)
        {
            camManager.startCutscene();
            isCutscene = false;
        }
    }
}