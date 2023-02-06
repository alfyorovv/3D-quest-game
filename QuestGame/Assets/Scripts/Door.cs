using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 2.5f;

    private LayerMask doorsLayerMask;
    private Animator doorAnimator;

    public Transform cameraTransform;
    public GameObject interactButton;
    public GameObject doorWay;


    private void Awake()
    {
        doorsLayerMask = LayerMask.GetMask("Doors");
        doorAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        DoorRaycast();
    }

    private void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), doorWay.GetComponent<Collider>()); //Door ignoring doorway
    }

    private void DoorRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, raycastDistance, doorsLayerMask))
        {
            interactButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                OpenCloseDoor();
            }
        }
    }

    private void OpenCloseDoor()
    {
        doorAnimator.SetTrigger("doorTrigger");
    }
}