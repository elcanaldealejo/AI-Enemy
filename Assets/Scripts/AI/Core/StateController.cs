﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
[Header("State")]    
[SerializeField] private AIState currentState;
[SerializeField] private AIState remainState=null; 

//public PathFollow Path {get; set;} 
public Enemy1 _objectEnemy1=null;
public Enemy2 _objectEnemy2=null;

private void Update(){
    currentState.RunState(this);
}

public void TransitionToState(AIState newState){
    if(newState != remainState){
        currentState = newState;
    }
} 
}