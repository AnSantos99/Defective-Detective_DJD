using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    public GameObject chicken;
    public GameObject startPoint;
    public GameObject endPoint;

    private Transform target;

    [SerializeField]private bool startPF;
    private bool cinematicsActive;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        chicken.transform.position = new Vector3(0.22f, 0.4842691f,-1.27f);
        target = endPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPF == true)
        {
            ActivateGObject();
            PathF();
        }
    }

    public void ActivateGObject()
    {
        chicken.SetActive(true);
    }

    private void PathF()
    {
        if (chicken.activeSelf == true)
        {
            chicken.transform.position = new Vector3(target.position.x, 0.4842691f, target.position.z);

            if(chicken.transform.position == startPoint.transform.position)
            {
                chicken.transform.position = Vector3.MoveTowards(target.position, transform.position, speed * Time.deltaTime);
                target = endPoint.transform;
                //StartCoroutine(waitMoment());
                Debug.Log(target);
            }
            

            //if (chicken.transform.position != startPoint.transform.position)
            //{
            //    StartCoroutine(waitMoment());
            //    target = startPoint.transform;
            //    Debug.Log(target);
            //}
        }
    }

    IEnumerator waitMoment()
    {
        yield return new WaitForSecondsRealtime(60);
    }
}
