using UnityEngine;

public class SizeFinder : MonoBehaviour
{
    public Renderer size_renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(size_renderer.bounds.size);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
