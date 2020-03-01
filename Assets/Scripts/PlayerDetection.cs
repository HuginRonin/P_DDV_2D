using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public LayerMask Player;
    public LayerMask Visible;
    public float range;
    public float visionAngle;
    public Transform[] PlayersDetected => DetectPlayer();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    protected Transform[] DetectPlayer()
    {
        List<Transform> AllDetectedPlayers = new List<Transform>();
        if (IsInRange(ref AllDetectedPlayers))
        {
            IsInAngle(ref AllDetectedPlayers);
            IsVisible(ref AllDetectedPlayers);
        }

        return AllDetectedPlayers.ToArray();
    }

    bool IsInRange(ref List<Transform> players)
    {
        Collider2D[] pColliders = Physics2D.OverlapCircleAll(transform.position, range, Player);

        if (pColliders.Length == 0)
        {
            return false;
        }

        foreach(var item in pColliders)
        {
            players.Add(item.transform);
        }
        
        return true;
    }

    bool IsInAngle(ref List<Transform> players)
    {
        for (int i=players.Count - 1; i>=0; i--)
        {
            var angleV = GetAngle(players[i]);

            if(angleV > visionAngle/2)
            {
                players.Remove(players[i]);
            }
        }
    
        return players.Count > 0;
    }

    bool IsVisible(ref List<Transform> players)
    {
        for (int i = players.Count - 1; i >= 0; i--)
        {
            var visible = Visibility(players[i]);

            if (!visible)
            {
                players.Remove(players[i]);
            }
        }
     
        return players.Count > 0;
    }

    float GetAngle(Transform t)
    {
        Vector3 dir = t.position - transform.position;
        float angle = Vector3.Angle(dir, transform.right);
        return angle;
    }

    bool Visibility(Transform t)
    {
        Vector3 dir = t.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, range, Visible);

        return (hit.collider.transform == t);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.red;
        var direction = Quaternion.AngleAxis(visionAngle/2, transform.forward) * transform.right;
        Gizmos.DrawRay(transform.position, direction * range);
        var direction2 = Quaternion.AngleAxis(-visionAngle/2, transform.forward) * transform.right;
        Gizmos.DrawRay(transform.position, direction2 * range);

        Gizmos.color = Color.white;
    }
}
