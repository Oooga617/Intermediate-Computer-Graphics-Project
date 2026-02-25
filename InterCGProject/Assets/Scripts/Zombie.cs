using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animator;
    int hp = 2;
    public CapsuleCollider c;
    

    //got help from here:https://www.reddit.com/r/unity/comments/w27gkf/unity_3d_mirrorflip_character_for_player_2/?rdt=57776
    private void OnEnable()
    {
        Debug.Log("is supposed to enable");
        this.transform.Rotate(new Vector3(0, 0, 0));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void getHit()
    {
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
