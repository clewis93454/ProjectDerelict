using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform player;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // v - vector from enemy space ship to player space ship.
        var v = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, v);

        // since the head of enemy spaceship points to negative y-axis
        // we must apply the force along the negative y-axis by multiply with -1.
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed * -1);
    }
}
