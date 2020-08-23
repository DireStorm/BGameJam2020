using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    // Variables and References
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 1f;

    public GameObject destroyEffect;

    public Transform player;
    public Vector2 target;

    //Ground Breaking
    public GameObject ground;
    public GameObject platformBoom;
    public static float groundCount;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        // You can change the "target" in the MoveTowards method to "player.position" for a homing missile type projectile
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Death();
                //groundCount = 0;
                ScoreCounter.scoreValue = 0;
            }
            DestroyProjectile();
        }

        if (collision.CompareTag("Ground"))
        {
            //groundCount += 1;
            ScoreCounter.scoreValue += 1;
            DestroyProjectile();
            ground = GameObject.FindGameObjectWithTag("Ground");
            ground.SetActive(false);
            Instantiate(platformBoom, transform.position, Quaternion.identity);
            //Debug.Log(groundCount);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }
}
