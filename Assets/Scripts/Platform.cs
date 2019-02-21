using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform startPoint, endPoint;

    public bool startOrEnd = false; // false = start, true = end

    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.position;
    }
    
    void Update()
    {
        if (startOrEnd)
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

        if (transform.position == endPoint.position && !startOrEnd)
            startOrEnd = true;

        if (transform.position == startPoint.position && startOrEnd)
            startOrEnd = false;
    }
}
