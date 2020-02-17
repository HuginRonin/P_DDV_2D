using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CollisionDetector))]
public class CrouchController : MonoBehaviour
{
    private CollisionDetector colDetect;

    [SerializeField]
    private GameObject ColliderStanding;

    [SerializeField]
    private GameObject ColliderCrouching;

    private bool standUp;

    private void Awake()
    {
     
    }

    void FixedUpdate()
    {
        if (CanStandUp() && standUp)
        {
            StandUp();
        }
    }

    public void OnCrouchStart()
    {
        Debug.Log("baia");
        ColliderStanding.SetActive(false);
        ColliderCrouching.SetActive(true);
        standUp = false;
    }

    public void OnCrouchEnd()
    {
        Debug.Log("ust");
        standUp = true;
    }

    private bool CanStandUp()
    {
        if (!colDetect)
        {
            colDetect = GetComponent<CollisionDetector>();
        }

        return !colDetect.IsRoofed;
    }

    private void StandUp()
    {
        ColliderStanding.SetActive(true);
        ColliderCrouching.SetActive(false);
        standUp = false;
    }
}
