using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animator;
    int hp = 3;
    public CapsuleCollider c;

    //setting up the zombie sounds
    [SerializeField] AudioSource audioSource;
    public AudioClip eating1, eating2, eating3, eating4, eating5, eating6, hurt1, hurt2, hurt3;
    bool isEating = true;
    public float eatSoundTime = 3.0f;
    float eatSoundPlay = 0.0f;
    public Renderer bloodPool;
    //floats for blood pool lerp
    public float timeToPool = 4.0f;
    float poolTiming = 0.0f;
    bool startBleeding = false;

    //got help from here:https://www.reddit.com/r/unity/comments/w27gkf/unity_3d_mirrorflip_character_for_player_2/?rdt=57776
    private void OnEnable()
    {
        Debug.Log("is supposed to enable");
        this.transform.Rotate(new Vector3(0, 0, 0));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //audioSource.GetComponent<AudioSource>();
        bloodPool.material.SetFloat("_Erosion", 0.0f);
        Debug.Log(bloodPool.material.GetFloat("_Erosion"));
    }

    public void getHit()
    {
        playHurt();
        if (hp >0)
        {
            hp--;
        }
        else
        {
            c.enabled = false;
            death();
        }
    }

    void death()
    {
        animator.SetBool("isDead", true);
        startBleeding = true;
        //this tweaks the blood pool effect to form
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isEating)
        {
            eatSoundPlay += Time.deltaTime;
            if (eatSoundPlay >= eatSoundTime)
            {
                playEating();
                eatSoundPlay = 0.0f;
            }
        }

        //makes the blood pool
        if (startBleeding)
        {
            if (poolTiming < timeToPool)
            {
                bloodPool.material.SetFloat("_Erosion", Mathf.Lerp(0.0f, 0.8f, poolTiming / timeToPool));
                poolTiming += Time.deltaTime;
            }
            else
                bloodPool.material.SetFloat("_Erosion", 0.8f);
        }   
    }

    void playEating()
    {
        int pickSound = Random.Range(0, 6);
        switch (pickSound)
        {
            case 0:
                audioSource.PlayOneShot(eating1);
                break;
            case 1:
                audioSource.PlayOneShot(eating2);
                break;
            case 2:
                audioSource.PlayOneShot(eating3);
                break;
            case 3:
                audioSource.PlayOneShot(eating4);
                break;
            case 4:
                audioSource.PlayOneShot(eating5);
                break;
            case 5:
                audioSource.PlayOneShot(eating6);
                break;
        }
    }

    void playHurt()
    {
        int pickSound = Random.Range(0, 3);
        switch (pickSound)
        {
            case 0:
                audioSource.PlayOneShot(hurt1);
                break;
            case 1:
                audioSource.PlayOneShot(hurt2);
                break;
            case 2:
                audioSource.PlayOneShot(hurt3);
                break;
        }
    }

    public void stopEating()
    {
        isEating = false;
    }
}
