using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathStart : MonoBehaviour
{
    Activation activeS;
    
    public bool oneKaren;
    public bool cutscene;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartPathfinding();
    }

    private void StartPathfinding()
    {
        if(activeS.startPF == true)
        {

        }
    }
}
