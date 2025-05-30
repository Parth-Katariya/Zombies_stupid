/*using UnityEngine;

public class GUN : MonoBehaviour
{
    public Transform aim; // mouse
    public GameObject bullet;
    public GameObject[] Bullets;// array bullets
    public  int bulletCount;//5 bullets

    private void Update()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //Gun move to mouse position 
        mousePos.z = 0;// after a screen[BG]
        aim.position = mousePos;

        var offset = mousePos - transform.position;// gun rotate for mouse move
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;//? mousepos & gunpos middle space[angle]
        var rotate = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotate;

        if (Input.GetMouseButtonDown(0) && bulletCount > 0)
        {
            bulletCount--;  // fire bullets is decrees

            Bullets[bulletCount].SetActive(false);
            fire(angle);
        }
    }

    private void fire(float angle)   // fire Bullets
    {
        var gunPos = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - gunPos;

        Vector3 pos = transform.position;
        Quaternion rotate = Quaternion.Euler(0, 0, angle + 90);//bullet roted 90 deg
        GameObject b = Instantiate(bullet, pos, rotate, transform.parent);//canvas->bullet set
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
        rb.AddForce(direction.normalized * 500);//bullet force[speed]
    }
}*/
using System;
using UnityEngine;

public class GUN : MonoBehaviour
{
    public Transform aim; // mouse
    public GameObject bullet;//,Playing, LevelSelection
    public GameObject[] Bullets; // array bullets
    public int bulletCount; // 5 bullets

    private void Update()
    {
        /*if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LevelSelection.SetActive(true);
                Playing.SetActive(false);
            }
        }*/
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        mousePos.z = 0; // after a screen[BG]
        aim.position = mousePos;

        var offset = mousePos - transform.position;
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; 
        var rotate = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotate;

        if (Input.GetMouseButtonUp(0) && bulletCount > 0)//    
        {
            bulletCount--; 
            Bullets[bulletCount].SetActive(false);
            fire(angle);
            Zombies_Manager.instance.OnBulletUsed(); 
        }
    }
    private void fire(float angle)
    {
        var gunPos = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - gunPos;

        Vector3 pos = transform.position;
        Quaternion rotate = Quaternion.Euler(0, 0, angle + 90); 
        GameObject b = Instantiate(bullet, pos, rotate, transform.parent); 
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
        rb.AddForce(direction.normalized * 500);
    }
}
