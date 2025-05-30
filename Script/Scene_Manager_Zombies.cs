using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager_Zombies : MonoBehaviour
{
    public static Scene_Manager_Zombies instance;

    private void Awake()
    {
        instance = this;
    }

    /*public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void unLoadScene(string sceneName)
    {
        SceneManager.UnloadScene(sceneName);
    }*/

    /* public void goToLevel1()
     {
         SceneManager.LoadScene("Zombies_stupid"); 
         //SceneManager.LoadScene(10);
     }
     public void goToLevel2()
     {
         SceneManager.LoadScene("LEVEL_2");   
         //SceneManager.LoadScene(11);
     }*/
    public void loadScene(int levelIndex)
    {
        Zombies_Manager.currentLevel = levelIndex;
        SceneManager.LoadScene("LEVEL-" + levelIndex);
    }
}
