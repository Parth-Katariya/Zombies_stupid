/*using UnityEngine;
using UnityEngine.UI;

public class Zombies_Level_Selected : MonoBehaviour
{
    public GameObject btn;//Playing
    public Transform gridTransform;

    private void Start()
    {

        //PlayerPrefs.SetString("" + i, "clear");

        //int temp = 1;
        int maxLevel = PlayerPrefs.GetInt("s", 0);
        for (int i = 0; i < 5; i++)
        {
            GameObject Clone = Instantiate(btn, gridTransform);
            Button b = Clone.GetComponent<Button>();
            Text t = Clone.GetComponentInChildren<Text>();
            Image tickImage = Clone.transform.GetChild(1).GetComponent<Image>();
            Image lockImage = Clone.transform.GetChild(2).GetComponent<Image>();
            //t.text = (temp).ToString();
            string state = PlayerPrefs.GetString("" + i, "lock"); //using string [ tick,lock]

            if (state == "clear")   // level is compeleted then show tick image is show
            {
                tickImage.gameObject.SetActive(true);
                lockImage.gameObject.SetActive(false);
                t.text = (i + 1).ToString();        //  Display level number
            }
            else if (maxLevel == i)   // skip level & lastlevel state == "skip" ||
            {
                tickImage.gameObject.SetActive(false);
                lockImage.gameObject.SetActive(false);
                t.text = (i + 1).ToString();        //  Display level number
            }
            else    // bydefault is lock image show
            {
                tickImage.gameObject.SetActive(false);
                lockImage.gameObject.SetActive(true);
                t.text = "";
                b.interactable = false;   // lock show is level is not open
            }
            if (state == "clear")
            {
                tickImage.gameObject.SetActive(true);
                lockImage.gameObject.SetActive(false);
                t.text = (i + 1).ToString();
            }
            else
            {
                tickImage.gameObject.SetActive(false);
                lockImage.gameObject.SetActive(true);
                t.text = (i + 1).ToString();
            }
            int finalI = i;
            b.onClick.AddListener(() =>   // click btn and move to playing page show
            {
                //print("level   ----");
                Zombies_Manager.instance.MoveToPlaying();

               *//* Playing.SetActive(true);
                SelectionLevel.SetActive(false);*//*

            });
        }
    }
}*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zombies_Level_Selected : MonoBehaviour
{
    public GameObject btn; // Prefab for level buttons
    public Transform gridTransform; // Grid where buttons will be instantiated
    public GameObject HomePage,LevelSelection;
    /*private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HomePage.SetActive(true);
                LevelSelection.SetActive(false);
            }
        }
    }*/
    private void Start()
    {
        int maxLevel = PlayerPrefs.GetInt("lastLevel", 1);

        for (int i = 1; i <= 5; i++)
        {
            GameObject Clone = Instantiate(btn, gridTransform);
            Button b = Clone.GetComponent<Button>();
            Text t = Clone.GetComponentInChildren<Text>();
            Image tickImage = Clone.transform.GetChild(1).GetComponent<Image>();
            Image lockImage = Clone.transform.GetChild(2).GetComponent<Image>();

            if (i <= maxLevel) // First level unlocked
            {
                tickImage.gameObject.SetActive(i != maxLevel);  // No tick for the first level initially
                lockImage.gameObject.SetActive(false);  // No lock on the first level
                t.text = (i).ToString(); // Display the level number
            }
            else // Lock all levels
            {
                tickImage.gameObject.SetActive(false);  // No tick image for locked levels
                lockImage.gameObject.SetActive(true);   // Lock image for all other levels
                t.text = (i).ToString(); // Display the level number
                b.interactable = false; // Disable the button for locked levels
            }

            // Capture the final level index to pass when the button is clicked
            int finalI = i;
            b.onClick.AddListener(() =>
            {
                Scene_Manager_Zombies.instance.loadScene(finalI);
                // When the level button is clicked, move to the corresponding level scene
                //Zombies_Manager.instance.MoveToPlaying(finalI); // Pass the level number to the scene manager
                //Scene_Manager_Zombies.instance.loadScene(finalI);
                /*if (Scene_Manager_Zombies.instance != null)
                {
                    // Pass the level number to the Scene_Manager_Zombies instance
                    Scene_Manager_Zombies.instance.loadScene(finalI);
                }*/
            });
        }
    }
}