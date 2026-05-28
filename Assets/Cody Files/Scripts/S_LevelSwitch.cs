using UnityEngine;
using UnityEngine.SceneManagement;

public class S_LevelSwitch : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private string nextLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            if (gameManager.levelComplete)
                SceneManager.LoadScene(nextLevel);
        }
    }
}
