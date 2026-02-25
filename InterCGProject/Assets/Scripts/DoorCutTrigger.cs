using UnityEngine;
using UnityEngine.Playables;

public class DoorCutTrigger : MonoBehaviour
{
    //playable director for the door cutscene
    public PlayableDirector doorDir;
    public TankController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player"))
        {
            triggerDoorCut();
        }
    }

    public void triggerDoorCut()
    {
        player.isPlayerDisabled = true;
        doorDir.Play();
        //once cutscene is over the player has control again
        doorDir.stopped += stopCutscene;
    }

    void stopCutscene(PlayableDirector d)
    {
        player.isPlayerDisabled = false;
        this.doorDir.stopped -= stopCutscene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
