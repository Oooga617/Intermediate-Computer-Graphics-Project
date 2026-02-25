using UnityEngine;
using TMPro;

public class AmmoCutTrigger : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextType textType;
    bool hasInteracted = false;
    MeshRenderer mr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && hasInteracted == false)
        {
            text.gameObject.SetActive(true);
            hasInteracted = !hasInteracted;
            //textType.EndCheck();
        }
        else if (textType.canPress && Input.GetKeyDown(KeyCode.E) && hasInteracted == true)
        {
            //mr.gameObject.SetActive(false);
            Debug.Log("progress description");
            textType.EndCheck();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
