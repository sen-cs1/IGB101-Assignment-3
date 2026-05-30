using UnityEngine;

public class door : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 3f;

    private Animator doorAnim;
    private bool isOpen = false;

    void Start()
    {
        // Always grab Animator from the TOP parent
        doorAnim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (player == null || doorAnim == null) return;

        // IMPORTANT: measure distance to DOOR PARENT, not this object
        Transform doorRoot = doorAnim.transform;

        float distance = Vector3.Distance(player.position, doorRoot.position);

        if (distance <= interactionDistance)
        {
            if (!isOpen)
            {
                isOpen = true;
                doorAnim.SetTrigger("open");
            }
        }
    }
}