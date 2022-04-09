using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/Estado")]
public class AIState : ScriptableObject
{
    public AIAccion[] Actions;
    public AITransiciones[] Transitions;

    public void RunState(StateController controller){
        ExecuteActions(controller);
        EvaluateTransitions(controller);
    }
    public void ExecuteActions(StateController controller){
        foreach (AIAccion action in Actions)
        {
            action.Act(controller);
        }
    }

    public void EvaluateTransitions(StateController controller){
        if(Transitions != null || Transitions.Length > 0){
            for(int i = 0; i < Transitions.Length; i++){
                bool decisionValue = Transitions[i].Decisiones.Decide(controller);
                if(decisionValue){
                    controller.TransitionToState(Transitions[i].TrueState);
                }else{
                    controller.TransitionToState(Transitions[i].FalseState);
                }
            }
        }
    }
} 
