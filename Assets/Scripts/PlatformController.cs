using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static bool hasStarted = false;

    public int livesNumber;
    public int platformNumber = 0;
    public static PlatformController platformContr;
    public List<GameObject> platforms;
    public List<Material> allMaterials;
    public List<GameObject> buttonsMaj;

    public List<GameObject> firstLive;
    public List<GameObject> secondLive;
    public List<GameObject> thirdLive;

    public float ttl;
    public float changePercentage;
    public GameObject platformPrefab;
    public float timeRotate;

    public int platformCount = 0;

    public enum PlatformColors
    {
        BLUE = 0,
        ORANGE = 1,
        PURPLE = 2,
        RED = 3
    }

    private void Awake()
    {
        platformContr = this;
    }

    private void Start()
    {
        Create();
    }

    private void Update()
    {
        if (timeRotate > 0)
        {
            timeRotate -= Time.deltaTime;
            if (timeRotate < 0)
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void Create()
    {   
        GameObject platform = platforms[platforms.Count - 1];
        GameObject whereToInstantiate = platform.GetComponent<PlatformBehaviour>().whereToPlace;

        bool shufflin = false;
        bool rotate = false;
        int givenColor = Random.Range(0, allMaterials.Count);

        PlatformColors color = (PlatformColors)givenColor;
        Material mat = allMaterials[givenColor];

        if (Random.Range(0, 100) < changePercentage)
        {
            int disp = Random.Range(0, 2);
            shufflin = disp == 0 ? true : false;
            rotate = disp == 1 ? true : false;

        }

        if (Random.Range(0, 100) < changePercentage)
        {
            int disp = Random.Range(0, 2);
            shufflin = disp == 0 ? true : false;
            rotate = disp == 1 ? true : false;
        }

        GameObject platInstantiation = Instantiate(platformPrefab);
        PlatformBehaviour behaviour = platInstantiation.GetComponent<PlatformBehaviour>();
        behaviour.SetUp(rotate, shufflin, mat, color);
        platInstantiation.transform.position = whereToInstantiate.transform.position;
        platforms.Add(platInstantiation);
    }

    public void Dispatch(PlatformColors color)
    {
        if (!FindObjectOfType<CharacterController>().isGrounded)
            return;

        GameObject platform = platforms[0];
        if (platform && platform.GetComponent<PlatformBehaviour>().color != color)
        {
            FindObjectOfType<CharacterController>().stun();
            livesNumber -= 1;

            switch (livesNumber)
            {
                case 2:
                    foreach (GameObject go in firstLive)
                        go.SetActive(false);
                    break;
                case 1:
                    foreach (GameObject go in secondLive)
                        go.SetActive(false);
                    break;
                case 0:
                    foreach (GameObject go in thirdLive)
                        go.SetActive(false);
                    break;
            }

            if (livesNumber <= 0)
            {
                GameOver("BAD COLOR !", "Too bad...you missed it...");
                return;
            }
            return;
        }

        if (!hasStarted)
            hasStarted = true;

        platformCount++;
        HandlePlatforming();
        Create();
        platforms.RemoveAt(0);
        PlatformBehaviour platformBehave = platform.GetComponent<PlatformBehaviour>();
        FindObjectOfType<CharacterController>().jumpTo(platformBehave.whereToLand.transform);

        if (platformBehave.isRotating && timeRotate <= 0f)
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180);
            timeRotate += 5f;
        }

        if (platformBehave.isShuffling)
        {
            ShuffleButtons();
        }
    }

    public void GameOver(string reason, string explanation)
    {
        hasStarted = false;
        ScoreHandler.scoreHandler.setUpFinalScore(reason, explanation, platformCount);
    }
    private void ShuffleButtons()
    {
        List<GameObject> buttons = new List<GameObject>();
        foreach (GameObject b in buttonsMaj)
            buttons.Add(b);


        FindObjectOfType<ButtonShuffler>().ShuffleButtons(buttons);
    }

    private void HandlePlatforming()
    {
        platformNumber++;
        if (platformNumber % 10 == 0 && changePercentage < 30)
            changePercentage += 5;

        if (platformNumber % 20 == 0 && ttl > 3)
            ttl -= 0.5f;
    }
}
