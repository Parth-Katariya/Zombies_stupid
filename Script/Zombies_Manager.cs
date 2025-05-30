/*using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zombies_Manager : MonoBehaviour
{
    public GameObject WinPage, TryAgainPage, Playing;//Death
    public static Zombies_Manager instance;
    public static int currentLevel = 1;
    public int zombiesDestroyed;
    public int TotalZombies;
    public Text levelText;

    private void Awake()
    {
        instance = this;
        ZombiesCountLevel();
    }

    private void ZombiesCountLevel()
    {
        if (currentLevel == 1)
        {
            TotalZombies = 1;
        }
        else if (currentLevel == 2) 
        {
            TotalZombies =2;
        }
        else if (currentLevel == 3)
        {
            TotalZombies = 2;
        }
        else if (currentLevel == 4)
        {
            TotalZombies = 3;
        }
        else if (currentLevel == 5)
        {
            TotalZombies = 1;
        }
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Zombies_Level_Selection");
            }
        }
    }
    public void openWinPage()
    {
        WinPage.SetActive(true);
        if (levelText != null)// Level completed and show for a level 1,2 completed text show
        {
            levelText.text = "Level " + currentLevel + " Completed!";
        }
        int maxLevel = PlayerPrefs.GetInt("lastLevel", 1);
        if (currentLevel + 1 > maxLevel)
        {
            PlayerPrefs.SetInt("lastLevel", currentLevel + 1);
        }
        //SceneManager.LoadScene("LEVEL-" + currentLevel);
        //Death.SetActive(true);
    }

    public void OnNextClick()
    {
        currentLevel++;
        SceneManager.LoadScene("LEVEL-" + currentLevel);
    }
    public void WaitAndOpenGameOver()
    {
        StartCoroutine(_WaitAndOpenGameOver());
    }
    private IEnumerator _WaitAndOpenGameOver()
    {
        yield return new WaitForSeconds(3f);
        print("WIN PAGE ");
        //Time.timeScale = 0; // Pause the game
        //Zombies_Manager.instance.openWinPage();
        openWinPage();
    }
    public void openTryAgainPage()
    {
        TryAgainPage.SetActive(true);
    }
    *//*public void openDeath()
    {
        Death.SetActive(true);
    }*//*
    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LEVEL-" + currentLevel);
    }

    internal void MoveToPlaying()
    {
        Debug.Log("Moving to level " + currentLevel);
       *//* this.currentLevel = finalI;
        LevelNo.text = (currentLevel + 1).ToString();*/
/*//
 Playing.SetActive(true);
 SelectionLevel.SetActive(false);*//*
currentLevel = currentLevel + 1; // Level number set karvo
SceneManager.LoadScene("LEVEL-" + currentLevel);
}
public void MoveToHome()
{
SceneManager.LoadScene("Zombies_Level_Selection");
}

internal void OnZombieDestroyed()
{
zombiesDestroyed++;
CheckIfAllZombiesAreDestroyed();
}

private void CheckIfAllZombiesAreDestroyed()
{
if(TotalZombies <= zombiesDestroyed)
{
    StartCoroutine(_WaitAndOpenGameOver());
}
}
}
*/
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zombies_Manager : MonoBehaviour
{
    public GameObject WinPage, TryAgainPage, Playing,HomePage,LevelSelection;
    public static Zombies_Manager instance;
    public static int currentLevel = 1;
    public int zombiesDestroyed;
    public int TotalZombies;
    public Text levelText;
    public GameObject[] starImages; 

    public int bulletsUsed = 0; 


    private void Awake()
    {
        instance = this;
        ZombiesCountLevel();
    }
    private void Update()// Handle Back Button Press on Android
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HandleBackPress();
            }
        }

    }

    private void HandleBackPress()   // back press 
    {
        if (TryAgainPage.activeSelf)
        { 
            TryAgainPage.SetActive(false);
            Playing.SetActive(true);
        }
        else if (WinPage.activeSelf)
        {
            WinPage.SetActive(false);
            Playing.SetActive(true);
        }
        else if (Playing.activeSelf)
        {
            Playing.SetActive(false);
            HomePage.SetActive(true);

        }
        else if (LevelSelection.activeSelf)
        {
            LevelSelection.SetActive(false);
            HomePage.SetActive(true);
        }
        else
        {
            Application.Quit();
        }
    }

    private void ZombiesCountLevel()
    {
        if (currentLevel == 1)
        {
            TotalZombies = 1;
        }
        else if (currentLevel == 2)
        {
            TotalZombies = 2;
        }
        else if (currentLevel == 3)
        {
            TotalZombies = 2;
        }
        else if (currentLevel == 4)
        {
            TotalZombies = 3;
        }
        else if (currentLevel == 5)
        {
            TotalZombies = 1;
        }
    }

    public void OnBulletUsed()
    {
        bulletsUsed++;
    }

    public void UpdateStars()
    {
        if (bulletsUsed <= 2)
        {
            for (int i = 0; i < 3; i++)
            {
                starImages[i].SetActive(i < 3); // Show 3 stars
            }
        }
        else if (bulletsUsed <= 4)
        {
            for (int i = 0; i < 3; i++)
            {
                starImages[i].SetActive(i < 2); // Show 2 stars
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                starImages[i].SetActive(i < 1); // Show 1 star
            }
        }
    }

    public void openWinPage()
    {

        WinPage.SetActive(true);
        if (levelText != null)
        {
            levelText.text = "Level " + currentLevel + " Completed!";
        }

        UpdateStars(); 

        int maxLevel = PlayerPrefs.GetInt("lastLevel", 1);
        if (currentLevel + 1 > maxLevel)
        {
            PlayerPrefs.SetInt("lastLevel", currentLevel + 1);
        }
    }

    public void OnNextClick()
    {
        currentLevel++;
        SceneManager.LoadScene("LEVEL-" + currentLevel);
    }

    public void WaitAndOpenGameOver()
    {
        StartCoroutine(_WaitAndOpenGameOver());
    }

    private IEnumerator _WaitAndOpenGameOver()
    {
        yield return new WaitForSeconds(3f);
        openWinPage();
    }

    public void openTryAgainPage()
    {
        TryAgainPage.SetActive(true);
    }

    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LEVEL-" + currentLevel);
    }

    internal void MoveToPlaying()
    {
        currentLevel++;
        SceneManager.LoadScene("LEVEL-" + currentLevel);
    }

    public void MoveToHome()
    {
        SceneManager.LoadScene("Zombies_Level_Selection");
    }

    internal void OnZombieDestroyed()
    {
        zombiesDestroyed++;
        CheckIfAllZombiesAreDestroyed();
    }

    private void CheckIfAllZombiesAreDestroyed()
    {
        if (TotalZombies <= zombiesDestroyed)
        {
            StartCoroutine(_WaitAndOpenGameOver());
        }
    }
}
/*
 if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                // do on back press
            }
        }
 */