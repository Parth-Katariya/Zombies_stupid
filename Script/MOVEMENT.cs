using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MOVEMENT : MonoBehaviour
{
    public float speed;
    public GameObject Win,playing;
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
    
    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Zombies_stupid");
    }
}
