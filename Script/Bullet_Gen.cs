/*using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bullet_Gen : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastVelocity;  // speed[bullets speed]
    int collisionCount = 0; // Counte collisions[bullets touch for collider]
    //public GameObject Attacker;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        lastVelocity = rb.linearVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        *//*destroyCount--;
        if (destroyCount == 0)
        {
            Destroy(gameObject);
            return;
        }*//*
        collisionCount++; // Increment collision[bullets(touch)]
        if (collisionCount >= 5)// Destroy bullet
        {
            Destroy(gameObject);
            
            var bulletsCounts = GameObject.FindGameObjectsWithTag("Bullet").Length;
            //print(bulletsCounts);
            if (bulletsCounts == 1) // Open the Try Again page[last one bullets is destroy ]
            {
                Time.timeScale = 0;
                Zombies_Manager.instance.openTryAgainPage();
            }
            return;
        }
        var force = lastVelocity.magnitude;
        var reflection = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        var angle = Mathf.Atan2(reflection.y, reflection.x) * Mathf.Rad2Deg;
        //var rotate = Quaternion.Euler(0, 0, angle + 90);
        //rb.transform.rotation = rotate;
        rb.rotation = angle + 90;
        rb.linearVelocity = reflection * force;
    }
    *//*  private void OnTriggerEnter2D(Collider2D collision)// Destroy for attacker[zombies]& win page is open 
      {                                                      // open use for zombies_manager [using openWinPage() function]
          if (collision.gameObject.name == "Attack")//tag use
          {
              collision.gameObject.SetActive(false);
              var zombieCount = GameObject.FindGameObjectsWithTag("Attack").Length;
             // Attacker.SetActive(true);
              if (zombieCount == 0)
              {
                  Time.timeScale = 0;
                  Zombies_Manager.instance.openWinPage();
                  //print("Game Over");//win page is open && not a attack is death[bullets is 0 then open restart btn]--> restart buutton is open other wise winpage open
              }
          }

      }*//*
    private void OnTriggerEnter2D(Collider2D collision)// Destroy for attacker[zombies] & win page is open 
    {                                                      // open use for zombies_manager [using openWinPage() function]
        if (collision.gameObject.name == "Attack")// tag use
        {
            collision.gameObject.SetActive(false); // Disable the attacker (zombie)
            var zombieCount = GameObject.FindGameObjectsWithTag("Attack").Length;
            Destroy(gameObject);
            if (zombieCount == 0)
            {

                Zombies_Manager.instance.openWinPage();
                //Zombies_Manager.instance.openDeath();
                // Start a coroutine to wait for 3 seconds before opening the win page
                StartCoroutine(WaitAndOpenWinPage());
            }
        }
        //Destroy(gameObject);
    }

    // Coroutine to wait for 3 seconds and then open the win page
    private IEnumerator WaitAndOpenWinPage()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(10f);

        // After waiting, open the win page
        Time.timeScale = 0;
        Zombies_Manager.instance.openWinPage();
    }

}*/

/*using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bullet_Gen : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastVelocity;  // speed[bullets speed]
    int collisionCount = 0; // Counte collisions[bullets touch for collider]

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rb.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++; // Increment collision[bullets(touch)]
        if (collisionCount >= 5) // Destroy bullet
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            int bulletsCounts = GameObject.FindGameObjectsWithTag("Bullet").Length;
            print("BulletsCounts :-- " + bulletsCounts);
            if (bulletsCounts == 0) // Open the Try Again page [last bullet destroyed]
            {
                Time.timeScale = 0;
                Zombies_Manager.instance.openTryAgainPage();
            }
            return;
        }

        var force = lastVelocity.magnitude;
        var reflection = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        var angle = Mathf.Atan2(reflection.y, reflection.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 90;
        rb.linearVelocity = reflection * force;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Destroy for attacker[zombies] & win page is open
    {
        if (collision.gameObject.tag == "Attack") // tag use
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");
            int zombieCount = GameObject.FindGameObjectsWithTag("Attack").Length;
            print(zombieCount);
            Destroy(gameObject);
            Zombies_Manager.instance.OnZombieDestroyed();
            //collision.gameObject.SetActive(false); // Disable the attacker (zombie)
            //var zombieCount = GameObject.FindGameObjectsWithTag("Attack").Length;
           

            if (zombieCount == 0) // All zombies are defeated
            {

                // Call death function
                //Zombies_Manager.instance.openDeath(); // Open the death UI
                //Zombies_Manager.instance.openWinPage();
                Zombies_Manager.instance.WaitAndOpenGameOver();
            }
        }
    }
}*/
using UnityEngine;

public class Bullet_Gen : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastVelocity;
    int collisionCount = 0;
    public int bulletsUsed;  // Track number of bullets used

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rb.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++;
        if (collisionCount >= 5)
        {
            gameObject.SetActive(false);

            int bulletsCounts = GameObject.FindGameObjectsWithTag("Bullet").Length;
            if (bulletsCounts == 0)
            {
                Time.timeScale = 0;
                Zombies_Manager.instance.openTryAgainPage();
            }
            return;
        }

        var force = lastVelocity.magnitude;
        var reflection = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        var angle = Mathf.Atan2(reflection.y, reflection.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 90;
        rb.linearVelocity = reflection * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");
            int zombieCount = GameObject.FindGameObjectsWithTag("Attack").Length;
            Destroy(gameObject);
            Zombies_Manager.instance.OnZombieDestroyed();

            if (zombieCount == 0)
            {
                print("BULLEST :-"+bulletsUsed);
                Zombies_Manager.instance.WaitAndOpenGameOver();
            }
        }
    }
}