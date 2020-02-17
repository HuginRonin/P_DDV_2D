using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [HideInInspector]
    public List<Transform> Targets;
    [SerializeField]
    private float posZ;
    [SerializeField]
    private float smoothFactor;
    [SerializeField]
    private float zoomAllowance;
    [SerializeField]
    Vector2 deadZone = new Vector2(0.2f, 0.15f);

    private Camera cam;
    private float ogSize;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        ogSize = cam.orthographicSize;
    }

    private void LateUpdate()
    {
        if (!InBounds())
        {
            MoveToTarget();
        }

        if (Targets.Count > 1)
        {
            ZoomIn();
        }
        else
        {
            ZoomBack();
        }
    }

    private void MoveToTarget()
    {
        Vector3 targetPos = GetCenterPosition();
        targetPos.z = posZ;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.deltaTime);
    }

    private bool InBounds()
    {
        foreach (var target in Targets)
        {
            Vector2 targetPos = cam.WorldToViewportPoint(target.position);

            if (targetPos.x > (0.5f + deadZone.x) || (targetPos.x < (0.5f - deadZone.x)) || targetPos.y > (0.5f + deadZone.y) || (targetPos.y < (0.5f - deadZone.y)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return true;
    }

    private Vector3 GetCenterPosition()
    {
        var sum = Vector3.zero;
        foreach (var target in Targets)
        {
            sum = sum + target.position;
        }
        return sum / Targets.Count;
    }

    private void ZoomIn()
    {
        Vector2 frameSize = GetFrame();
        Debug.Log(frameSize.x);
        Debug.Log(frameSize.y);
        if (frameSize.x > frameSize.y)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, (frameSize.x / 2) * zoomAllowance / cam.aspect, smoothFactor * Time.deltaTime);
            Debug.Log("x " + cam.orthographicSize);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, frameSize.y * zoomAllowance / 2, smoothFactor * Time.deltaTime);
            Debug.Log("y " + cam.orthographicSize);
        }
    }

    private void ZoomBack()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, ogSize, smoothFactor * Time.deltaTime);
    }

    private Vector2 GetFrame()
    {
        float leftBound = Targets[0].position.x;
        float rightBound = Targets[0].position.x;
        float upBound = Targets[0].position.y;
        float downBound = Targets[0].position.y;

        foreach (Transform t in Targets)
        {
            if (t.position.x < leftBound)
            {
                leftBound = t.position.x;
            }
            if (t.position.x > rightBound)
            {
                rightBound = t.position.x;
            }
            if (t.position.y > upBound)
            {
                upBound = t.position.y;
            }
            if (t.position.y < downBound)
            {
                downBound = t.position.y;
            }
        }

        return new Vector2(rightBound - leftBound, upBound - downBound);
    }
}