using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public GameObject[] handPoints;

    private Rigidbody rb;
    private bool grabbing = false;

    public float fistDistance = 0.15f;
    public float reachDistance = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool fist = IsFist();

        float handToCube = Vector3.Distance(
            handPoints[0].transform.position,
            transform.position);

        if (fist && handToCube < reachDistance)
        {
            Grab();
        }
        else
        {
            Release();
        }

        if (grabbing)
        {
            transform.position = handPoints[0].transform.position;
        }
    }

    bool IsFist()
    {
        float index = Vector3.Distance(handPoints[8].transform.position, handPoints[0].transform.position);
        float middle = Vector3.Distance(handPoints[12].transform.position, handPoints[0].transform.position);
        float ring = Vector3.Distance(handPoints[16].transform.position, handPoints[0].transform.position);
        float pinky = Vector3.Distance(handPoints[20].transform.position, handPoints[0].transform.position);

        return index < fistDistance &&
               middle < fistDistance &&
               ring < fistDistance &&
               pinky < fistDistance;
    }

    void Grab()
    {
        grabbing = true;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
    }

    void Release()
    {
        grabbing = false;
        rb.useGravity = true;
    }
}