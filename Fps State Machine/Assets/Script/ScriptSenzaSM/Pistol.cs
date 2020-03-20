using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pistol: MonoBehaviour
{
    public GameObject shotReference;
    public GameObject player;
    int i = 0;
    int rotX = 0;
    int cont = 0;
    void Shot()
    {
        GameObject newShot = Instantiate(shotReference, transform.position, player.transform.localRotation);
    }
    void Recharge()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            i = 0;
            Debug.Log("Ricarica Effettuata");
        }
    }
    void Die()
    {
        Destroy(this.gameObject);
    }

    void Equipment()
    {
        if (Input.GetKeyDown(KeyCode.F) && cont == 0)
        {
            rotX = 0;
            transform.Rotate(rotX, 0, 0);
            cont = 1;
        }
    }

    void Deequipment()
    {
        if (Input.GetKeyDown(KeyCode.F) && cont == 1)
        {
            rotX = 90;
            transform.Rotate(rotX, 0, 0);
            cont = 0;
        }
    }
    void Update()
    {
        if(i<5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                i++;
                Shot();
                Debug.Log(i);
            }
        }
        else
        {
            Debug.Log("Ricarica");
        }
        Recharge();
        Equipment();
        Deequipment();
    }
}