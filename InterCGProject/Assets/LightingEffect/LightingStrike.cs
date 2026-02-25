using UnityEngine;

public class LightingStrike : MonoBehaviour
{
    public ParticleSystem lighting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lighting.Stop();
    }

    public void playerEffect()
    {
        lighting.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
