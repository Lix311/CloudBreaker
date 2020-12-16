
using UnityEngine;

public class Materia : MonoBehaviour
{
    // params
    [SerializeField] BusterSword bustersword1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] materiaSounds;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 swordToMateriaVector;
    bool hasStarted = false;

    // Cashed component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        swordToMateriaVector = transform.position - bustersword1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       

        if(!hasStarted)
        {
            LockSwordToMateria();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockSwordToMateria()
    {
        Vector2 swordPos = new Vector2(bustersword1.transform.position.x, bustersword1.transform.position.y);
        transform.position = swordPos + swordToMateriaVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = materiaSounds[UnityEngine.Random.Range(0, materiaSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
       
    }
}
