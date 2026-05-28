using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public float currentPickups = 0;
    [SerializeField] private float maxPickups = 5;
    public bool levelComplete = false;
    [SerializeField] public Image progressBar;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private float audioProximity = 5.0f;
    [SerializeField] private Animator doorAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UIUpdate();
    }

    public void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
        {
            levelComplete = true;
            doorAnimator.SetBool("Level Complete", true);
        }
        else
            levelComplete = false;
    }

    private void UIUpdate()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, currentPickups / maxPickups, 1 * Time.deltaTime);
    }
}
