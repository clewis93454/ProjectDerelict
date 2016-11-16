using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

    public float speed;
    public Transform player;
    public AudioSource thrusterAudio;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            anim.SetTrigger("Attack");
        }
    }
    void FixedUpdate()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D>().angularVelocity = 0;

        float inputVertical = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * inputVertical);

        // thruster looping audio
        if (Input.GetButtonDown("Vertical"))
            thrusterAudio.Play();
        else if (Input.GetButtonUp("Vertical") && thrusterAudio.isPlaying)
            thrusterAudio.Stop();
    }
}
