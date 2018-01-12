using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(" you clicked Start");
    }
	
	// Update is called once per frame
	void Update () {
    
    }
}
public class MovableObject : MonoBehaviour
{
    public static implicit operator MovableObject(TouchableObject v)
    {
        throw new NotImplementedException();
    }
}
