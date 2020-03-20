using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMove : MonoBehaviour
{

    static GameManagerMove singleton;
    //Altri Manager
    Animator MoveSM;


    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(singleton);
        }
        else
        {
            DestroyImmediate(singleton);
        }
        Setup();
    }
    /// <summary>
    /// Delegato che gestisce gli eventi lanciati dall'esterno per triggerare il cambio di stato della GameStateMachine
    /// </summary>

    //public static GamePlayTriggerDelegate Setup;


    #region GamePlay Trigger Delegate
    public delegate void GamePlayTriggerDelegate();

    public static GamePlayTriggerDelegate WaitingTriggerState;
    public static GamePlayTriggerDelegate WalkTriggerState;
    public static GamePlayTriggerDelegate RunTriggerState;
    public static GamePlayTriggerDelegate CrunchTriggerState;
    #endregion

    public static void Setup()
    {
        singleton.MoveSM = singleton.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventSetup();
    }

    public static void EventSetup()     /// <summary> /// Funzione che si occupa di iscriversi a N eventi in base alla tipologia di struttura. /// </summary>
    {
        WaitingTriggerState += singleton.HandleWaitingState;
        WalkTriggerState += singleton.HandleWalkState;
        RunTriggerState += singleton.HandleRunState;
        CrunchTriggerState += singleton.HandleCrunchState;
    }

    void HandleWaitingState()    /// <summary> /// Funzione che gestisce l'evento WaitingState /// </summary>
    {
        if (!singleton.MoveSM.GetCurrentAnimatorStateInfo(0).IsName("Waiting"))
        {
            singleton.MoveSM.SetTrigger("WaitingTriggerState");
        }
    }

    void HandleWalkState()    /// <summary> /// Funzione che gestisce l'evento WalkState /// </summary>
    {
        if (!singleton.MoveSM.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            singleton.MoveSM.SetTrigger("WalkTriggerState");
        }
    }

    void HandleRunState()    /// <summary> /// Funzione che gestisce l'evento RunState /// </summary>
    {
        if (!singleton.MoveSM.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            singleton.MoveSM.SetTrigger("RunTriggerState");
        }
    }

    void HandleCrunchState()    /// <summary> /// Funzione che gestisce l'evento CrunchState /// </summary>
    {
        if (!singleton.MoveSM.GetCurrentAnimatorStateInfo(0).IsName("Crunch"))
        {
            singleton.MoveSM.SetTrigger("CrunchTriggerState");
        }
    }

    private void OnDisable()
    {
        WaitingTriggerState -= singleton.HandleWaitingState;
        WalkTriggerState -= singleton.HandleWalkState;
        RunTriggerState -= singleton.HandleRunState;
        CrunchTriggerState -= singleton.HandleCrunchState;
    }
}