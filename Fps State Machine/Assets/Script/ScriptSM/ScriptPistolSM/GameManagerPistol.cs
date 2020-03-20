using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPistol : MonoBehaviour
{

    static GameManagerPistol singleton;
    //Altri Manager
    Animator PistolSM;

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

    public static GamePlayTriggerDelegate ShotBullet;
    public static GamePlayTriggerDelegate FocusPistol;
    public static GamePlayTriggerDelegate WeaponPistolOn;
    public static GamePlayTriggerDelegate WeaponPistolOff;
    public static GamePlayTriggerDelegate ReloadPistol;

    #endregion

    public static void Setup()
    {
        singleton.PistolSM = singleton.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventSetup();
    }

    public static void EventSetup()     /// <summary> /// Funzione che si occupa di iscriversi a N eventi in base alla tipologia di struttura. /// </summary>
    {
        ShotBullet += singleton.HandleShotBullet;
        FocusPistol += singleton.HandleFocusPistol;
        WeaponPistolOn += singleton.HandleWeaponOn;
        WeaponPistolOff += singleton.HandleWeaponOff;
        ReloadPistol += singleton.HandleReloadPistol;
    }

    void HandleShotBullet()    /// <summary> /// Funzione che gestisce l'evento ShotBullet /// </summary>
    {
        if (!singleton.PistolSM.GetCurrentAnimatorStateInfo(0).IsName("Shot"))
        {
            singleton.PistolSM.SetTrigger("ShotBullet");
        }
    }

    void HandleFocusPistol()    /// <summary> /// Funzione che gestisce l'evento FocusPistol /// </summary>
    {
        if (!singleton.PistolSM.GetCurrentAnimatorStateInfo(0).IsName("Focus"))
        {
            singleton.PistolSM.SetTrigger("FocusPistol");
        }
    }

    void HandleWeaponOn()    /// <summary> /// Funzione che gestisce l'evento WeaponOn /// </summary>
    {
        if (!singleton.PistolSM.GetCurrentAnimatorStateInfo(0).IsName("Weapon On"))
        {
            singleton.PistolSM.SetTrigger("WeaponPistolOn");
        }
    }

    void HandleWeaponOff()    /// <summary> /// Funzione che gestisce l'evento WeaponOff /// </summary>
    {
        if (!singleton.PistolSM.GetCurrentAnimatorStateInfo(0).IsName("Weapon Off"))
        {
            singleton.PistolSM.SetTrigger("WeaponPistolOff");
        }
    }
    void HandleReloadPistol()    /// <summary> /// Funzione che gestisce l'evento ReloadPistol /// </summary>
    {
        if (!singleton.PistolSM.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
        {
            singleton.PistolSM.SetTrigger("ReloadPistol");
        }
    }

    private void OnDisable()
    {
        ShotBullet -= singleton.HandleShotBullet;
        FocusPistol -= singleton.HandleFocusPistol;
        WeaponPistolOn -= singleton.HandleWeaponOn;
        WeaponPistolOff -= singleton.HandleWeaponOff;
        ReloadPistol -= singleton.HandleReloadPistol;
    }
}