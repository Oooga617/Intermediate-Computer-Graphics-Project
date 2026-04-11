using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class LightingStrike : MonoBehaviour
{
    public ParticleSystem lighting;
    AudioSource audioSource;
    public AudioClip t1, t2, t3, t4, t5, t6;
    //pick which thunder sound to play
    int pickSfx;
    bool canPlay = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lighting.Stop();
        audioSource = GetComponent<AudioSource>();
    }

    public void disableSfx()
    {
        canPlay = false;
    }

    public void playerEffect()
    {
        lighting.Play();
    }

    public void playThunder()
    {
        if (canPlay)
            pickSfx = Random.Range(0, 6);
        switch (pickSfx)
        {
            case 0:
                audioSource.PlayOneShot(t1);
                break;
            case 1:
                audioSource.PlayOneShot(t2);
                break;
            case 2:
                audioSource.PlayOneShot(t3);
                break;
            case 3:
                audioSource.PlayOneShot(t4);
                break;
            case 4:
                audioSource.PlayOneShot(t5);
                break;
            case 5:
                audioSource.PlayOneShot(t6);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
