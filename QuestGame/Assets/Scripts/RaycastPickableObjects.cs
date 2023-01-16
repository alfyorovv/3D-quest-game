using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPickableObjects : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 2.5f;
    private LayerMask raycastLayerMask;
    private Transform cameraTransform;
    private bool isEquiped = false;

    public GameObject interactButton;
    public GameObject weaponHolder;


    void Awake()
    {
        raycastLayerMask = LayerMask.GetMask("PickableObjects");
        cameraTransform = GetComponent<Transform>();
    }

    void Update()
    {
        WeaponEquiping();
    }

    private void WeaponEquiping()
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, raycastDistance, raycastLayerMask))
        {
            interactButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F) && !isEquiped)
            { 
                PickUpWeapon(hit.collider.gameObject);
                isEquiped = true;
            }
            else if (Input.GetKeyDown(KeyCode.F) && isEquiped)
            {
                ChangeWeapon(hit.collider.gameObject);
            }

        }
        else
        {
            interactButton.SetActive(false);
        }

        Debug.DrawLine(transform.position, transform.position + transform.forward * raycastDistance);
    }

    private void PickUpWeapon(GameObject weapon)
    {
        weapon.GetComponent<Rigidbody>().isKinematic = true; //Object becomes kinematic after picking
        weapon.GetComponent<BoxCollider>().isTrigger = true; //Set collider as trigger
        weapon.transform.SetParent(weaponHolder.transform); //Set an object as a child of weapon holder

        //Set object to position of weapon holder
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon.transform.localScale = Vector3.one;
    }

    private void ChangeWeapon(GameObject newWeapon)
    {
        GameObject currentWeapon = weaponHolder.transform.GetChild(0).gameObject;

        //Drop current weapon
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false; //Object becomes non-kinematic after picking
        currentWeapon.GetComponent<BoxCollider>().isTrigger = false; //Set collider as non-trigger
        currentWeapon.transform.SetParent(null); //Set an object as not a child of weapon holder
        currentWeapon.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * 2, ForceMode.Impulse); //Throw weapon

        PickUpWeapon(newWeapon);
    }

}
