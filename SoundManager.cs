using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip amafo, greenStone, damage;
    AudioSource audiosource;

    void Start()
    {

        amafo = Resources.Load<AudioClip>("Amafo");
        greenStone = Resources.Load<AudioClip>("greenstone");
        damage = Resources.Load<AudioClip>("damage");

        audiosource = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "amafo":
                audiosource.PlayOneShot(amafo);
                break;
            case "greenstone":
                audiosource.PlayOneShot(greenStone);
                break;
            case "damage":
                audiosource.PlayOneShot(damage);
                break;
        }
    }
}
