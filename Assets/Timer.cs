using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Singleton class to access timer variable from anywhere
public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;

    // Static reference to the instance of the class
    private static Timer _instance;

    public static Timer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Timer>();

                // If no instance was found, create a new GameObject and add the singleton script to it
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("MySingleton");
                    _instance = singletonObject.AddComponent<Timer>();
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if(remainingTime < 15)
            {
                //Change colour to red
                timerText.color = Color.red;
            }else
            {
                timerText.color = Color.white;
            }
        }else if(remainingTime < 0)
        {
            remainingTime = 0;
        }
        
        int minutes=Mathf.FloorToInt(remainingTime / 60); 
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);    
    }
}
