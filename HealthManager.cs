using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public PlayerController thePlayer;

    public float invicibilityLength;
    private float invicibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public RawImage heartFull1, heartFull2, heartFull3, heartEmpty1, heartEmpty2, heartEmpty3;



    void Start()
    {

        currentHealth = maxHealth;
        //thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;

    }


    void Update()
    {

        if(invicibilityCounter > 0)
        {

            invicibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;

            }


            if(invicibilityCounter <= 0)
            {
                playerRenderer.enabled = true;


            }

        }
        switch (currentHealth)
        {
            case 3:
                heartFull1.enabled = true;
                heartFull2.enabled = true;
                heartFull3.enabled = true;
                heartEmpty1.enabled = false;
                heartEmpty2.enabled = false;
                heartEmpty3.enabled = false;
                break;
            case 2:
                heartFull1.enabled = true;
                heartFull2.enabled = true;
                heartFull3.enabled = false;
                heartEmpty3.enabled = true;
                heartEmpty1.enabled = false;
                heartEmpty2.enabled = false;
                break;
            case 1:
                heartFull1.enabled = true;
                heartFull2.enabled = false;
                heartFull3.enabled = false;
                heartEmpty3.enabled = true;
                heartEmpty1.enabled = false;
                heartEmpty2.enabled = true;
                break;

        }
        if(thePlayer.transform.position.y <= -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
        

    }
    public void HurtPlayer(int damage, Vector3 direction)
    {

        if (invicibilityCounter <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                thePlayer.knockBack(direction);

                invicibilityCounter = invicibilityLength;

                playerRenderer.enabled = false;
                flashCounter = flashLength;
            }

        }

    }
    public void Respawn()
    {
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;

        if (currentHealth <= maxHealth)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    //public IEnumerator RespawnCo()
    //{
        //isRespawning = true;
        

        /*thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;

        invicibilityCounter = invicibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength; */

   // }
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }





}
