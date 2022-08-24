using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int currentAmafo;
    public Text amafoText;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void AddAmafo(int amafoToAdd, int maxAmafo)
    {
        currentAmafo += amafoToAdd;
        amafoText.text = "Amafo: " + currentAmafo + "/" + (maxAmafo + 1);

    }
    public void RemoveAmafo(int amafoToRemove, int maxAmafo)
    {

        currentAmafo -= amafoToRemove;
        amafoText.text = "Amafo: " + currentAmafo + "/" + (maxAmafo + 1);

    }
    public void LimitAmafo(int maxAmafo)
    {
        amafoText.text = "Amafo: " + currentAmafo + "/" + (maxAmafo + 1);
    }
    
}
