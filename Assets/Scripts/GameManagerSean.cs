using UnityEngine;
using UnityEngine.UI;

public class GameManagerSean : MonoBehaviour
{

    public GameObject player;
    public Text pickupText;

    //Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }
    
    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    //Loop for playing audio proximity events - AudioSource based
    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if(Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
        }
    }



}


