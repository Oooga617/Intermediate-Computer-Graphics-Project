using UnityEngine;
using Unity.Cinemachine;
using System.Collections.Generic;
using UnityEngine.Playables;

public class CamManager : MonoBehaviour
{
    public List<CinemachineCamera> cams;
    private const int lowPriority = -1;
    private const int highPriority = 10;
   
    //player script reference
    public TankController player;
    //playable director for the zombie cutscene
    public PlayableDirector director;
    //zombie scrpt itself
    public Zombie z;
    //text typing thing
    public TextType textType;
    //shotgun shell pick up camera
    public PlayableDirector shotDir;

    public Animator deadGuy;

    //got help from: https://medium.com/@austinjy13/using-triggers-to-change-cameras-unity-cinemachine-fb4825fa1885
    // https://www.youtube.com/watch?v=biyH7pKwSAs
    //https://docs.unity3d.com/Packages/com.unity.cinemachine@3.0/api/Unity.Cinemachine.CinemachineVirtualCameraBase.Prioritize.html
    void Awake()
    {
        //disable zombie script
        z.enabled = false;
        //sets every camera as a low priority
        for (int i = 0; i < cams.Count; i++)
        {
            cams[i].Priority = lowPriority;
        }
        cams[0].Priority = highPriority;

    }

    public void switchCamera (int number)
    {
        
        for (int i = 0; i < cams.Count; i++)
        {
            if (i == number)
            {
                cams[number].Priority = highPriority;
                break;
            }
            else
            {
                cams[i].Priority = lowPriority;
            }
        }
    }

    public void startCutscene()
    {
        player.isPlayerDisabled = true;
        director.Play();
        //once cutscene is over the player has control again
        director.stopped += returnPlayerControl;
        deadGuy.SetBool("cutSDone", true);
    }

    void returnPlayerControl(PlayableDirector d)
    {
        
        z.enabled = true;
        //removes the listener
        this.director.stopped -= returnPlayerControl;
        cams[2].Priority = highPriority;
        player.isPlayerDisabled = false;
    }

    public void showShells()
    {
        shotDir.Play();        
    }

    public void stopShowingShells()
    {
        shotDir.Stop();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
