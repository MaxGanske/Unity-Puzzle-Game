using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabSpawner : MonoBehaviour
{

    private float nextSpawnTime;

    [SerializeField]
    private GameObject greenFellowPrefab;
    [SerializeField]
    private float spawnDelay = 10;

    private GameObject greenFellowSpawned;

    public int numberOfAmafo = 0;
    public Renderer first, second, third, fourth, fifth, sixth, seventh, eighth, ninenth, tenth, eleventh;
    public Collider firstC, SecondC, thirdC, fourthC, fifthC, sixthC, seventhC, eighthC, ninenthC, tenthC, eleventhC;

    public Renderer puzzleGreenStone1, puzzleGreenStone2;
    public Collider puzzleGreenStone1C, puzzleGreenStone2C;
    public GreenStonePickUp puzzleGreenStone1Pickup, puzzleGreenStone2Pickup;
    public SceneManager credits;

    GameObject[] amafoExtra;

    public GameObject player;
    public GameObject enemy;
    public Collider enemyCollider;
    public int maxAmafo;
    public GameObject amafoEffect;


    void Start()
    {


    }

    private void Update()
    {

        
        amafoExtra = GameObject.FindGameObjectsWithTag("Amafo");

        if (Input.GetKeyDown(KeyCode.V) && (numberOfAmafo <= maxAmafo))
        {
            nextSpawnTime = Time.deltaTime + spawnDelay;
            greenFellowSpawned = Instantiate(greenFellowPrefab, transform.position, transform.rotation);
            Instantiate(amafoEffect, transform.position, transform.rotation);
            FindObjectOfType<SoundManager>().PlaySound("amafo");

            numberOfAmafo++;
            FindObjectOfType<GameManager>().AddAmafo(1, maxAmafo);

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            for (int i = 0; i < amafoExtra.Length; i++)
            {
                Destroy(amafoExtra[i]);
            }
            FindObjectOfType<GameManager>().RemoveAmafo(numberOfAmafo, maxAmafo);
            numberOfAmafo -= numberOfAmafo;

        }
        

        if(numberOfAmafo >= 8)
        {

            Application.Quit();
        }

        if (numberOfAmafo >= 3)
        {
            first.enabled = true;
            firstC.enabled = true;
        }
        else
        {
            first.enabled = false;
            firstC.enabled = false;
        }
        if (numberOfAmafo >= 3)
        {
            second.enabled = true;
            third.enabled = true;
            SecondC.enabled = true;
            thirdC.enabled = true;
        }
        else
        {
            second.enabled = false;
            third.enabled = false;
            SecondC.enabled = false;
            thirdC.enabled = false;
        }
        if (numberOfAmafo >= 4)
        {
            fourth.enabled = true;
            fifth.enabled = true;
            sixth.enabled = true;
            fourthC.enabled = true;
            fifthC.enabled = true;
            sixthC.enabled = true;
        }

        else
        {
            fourth.enabled = false;
            fifth.enabled = false;
            sixth.enabled = false;
            fourthC.enabled = false;
            fifthC.enabled = false;
            sixthC.enabled = false;
        }
        if (numberOfAmafo >= 7)
        {
            puzzleGreenStone2.enabled = true;
            puzzleGreenStone2C.enabled = true;
            puzzleGreenStone2Pickup.enabled = true;

        }
        else
        {
            puzzleGreenStone2.enabled = false;
            puzzleGreenStone2C.enabled = false;
            puzzleGreenStone2Pickup.enabled = false;
        }
        if (numberOfAmafo >= 5)
        {
            seventh.enabled = true;
            eighth.enabled = true;
            ninenth.enabled = true;
            seventhC.enabled = true;
            eighthC.enabled = true;
            ninenthC.enabled = true;

        }
        else
        {
            seventh.enabled = false;
            eighth.enabled = false;
            ninenth.enabled = false;
            seventhC.enabled = false;
            eighthC.enabled = false;
            ninenthC.enabled = false;
        }
        if (numberOfAmafo == 1)
        {
            puzzleGreenStone1.enabled = true;
            puzzleGreenStone1C.enabled = true;
            puzzleGreenStone1Pickup.enabled = true;
            tenth.enabled = true;
            eleventh.enabled = true;
            tenthC.enabled = true;
            eleventhC.enabled = true;

        }
        else
        {
            puzzleGreenStone1.enabled = false;
            puzzleGreenStone1C.enabled = false;
            puzzleGreenStone1Pickup.enabled = false;
            tenthC.enabled = false;
            eleventhC.enabled = false;
            tenth.enabled = false;
            eleventh.enabled = false;

        }
    }


        

       


        /*if (player != GameObject.FindGameObjectWithTag("Player"))
        {
            if(numberOfAmafo > 2)
            {
                Physics.IgnoreCollision
            }


        }*/


    




    private bool ShouldSpawn()
    {

        return Time.deltaTime >= nextSpawnTime;

    }

    public void increaseAmafo(int increase)
    {

        maxAmafo += increase;
        FindObjectOfType<GameManager>().LimitAmafo(maxAmafo);

    }
    

}
