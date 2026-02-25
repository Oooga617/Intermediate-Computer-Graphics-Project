using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TankController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    public Animator ani;
    bool isFired = false;
    public GameObject muzzleFlash;
    public Transform firePoint;
    public bool isPlayerDisabled = false;
    public GameObject bloodSpray;
    //got help from:
    //https://discussions.unity.com/t/c-player-controller-with-wsad-keys/657231
    //https://discussions.unity.com/t/character-rotation-using-charactercontroller/59232
    //https://stackoverflow.com/questions/54763050/how-do-i-rotate-an-object-on-the-y-axis#:~:text=Sorted%20by:,Nicolas
    //https://www.youtube.com/watch?v=X84szMcIbqg
    //https://www.youtube.com/watch?v=cI3E7_f74MA
    //https://discussions.unity.com/t/how-to-make-bullet-holes-at-raycast-hit/684428

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
 
    }

     void Update()
    {
        //checks if the player fires
        inputAttack();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlayerDisabled == false && isFired == false)
            getInput();
        else
            ani.SetBool("isMove", false);
    }

    void inputAttack()
    {
        if ((Input.GetMouseButtonDown(0) && isFired == false && isPlayerDisabled == false))
        {
            Debug.Log("is fired true!");
            isFired = true;
            StartCoroutine(firingGun());
        }
    }
    
    IEnumerator firingGun()
    {
        Debug.Log("should spawn is fired");
        shoot();
        var muzzleEffect = Instantiate(muzzleFlash, firePoint);
        yield return new WaitForSeconds(0.8f);
        isFired = false;
        Destroy(muzzleEffect);
        yield return null;
    }

    IEnumerator sprayingBlood(RaycastHit hit)
    {
        var targetPos = hit.transform.position;
        var bloodDir = this.transform.position - targetPos;
        GameObject blood = Instantiate(bloodSpray, hit.point + hit.normal * 0.0001f, Quaternion.LookRotation(hit.normal));
        blood.transform.LookAt(bloodDir);
        yield return new WaitForSeconds(0.8f);
        Destroy(blood);
        yield return null;
    }
    void shoot()
    {

        Vector3 direction = transform.forward;
        if (Physics.Raycast(firePoint.position, direction, out RaycastHit hit, float.MaxValue))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("hit zombie");
                hit.transform.GetComponent<Zombie>().getHit();
                StartCoroutine(sprayingBlood(hit));
                
            }
        }
    }

    void getInput()
    {
        //forward and backward motions
        float forwardMove = 0.0f;
        float turnMove = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
   
            ani.SetBool("isMove", true);
            ani.SetBool("isForward", true);
            forwardMove = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ani.SetBool("isMove", true);
            ani.SetBool("isForward", false);
            forwardMove = -1f;
        }
        else
        {

            ani.SetBool("isMove", false);
            forwardMove = 0f;
        }

        //turning left or right
        if (Input.GetKey(KeyCode.A))
        {

            turnMove = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
    
            turnMove = 1f;
        }
        else
        {
            turnMove = 0f;
        }
        //only on the Z axis to move
        //Vector3 movement = new Vector3((float)(forwardMove * moveSpeed * Time.deltaTime), 0.0f, 0.0f);

        rb.linearVelocity = transform.forward * moveSpeed * forwardMove * Time.deltaTime;
        //rotates on Y axis
        transform.Rotate(Vector3.up * turnMove * turnSpeed * Time.deltaTime);

    }

    //so i dont forget to cite this: 
}
