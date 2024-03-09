using System.Collections;
using System.Collections.Generic;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class testCanvas : MonoBehaviour
{
    public GameObject P_Unit_Gunner;
    public GameObject P_Unit_Soldier;
    public GameObject P_Unit_Machine;
    public GameObject P_Unit_Bomber;
    public GameObject P_Unit_Tank;
    public void Create_P_Unit_Soldier()
    {
        float t = Random.Range(-1, 10);
      for (int j = 0; j < 1; j++)
      {
          t -= 1f;
          Vector3 z= new Vector3(t, 1.05f, -30.57f);
          var k =Instantiate(P_Unit_Soldier, z, P_Unit_Soldier.transform.rotation);
      }
    } 
    public void Create_P_Unit_Machine()
    {
        float t = Random.Range(-1, 10);
        for (int j = 0; j < 1; j++)
        {
            t -= 1f;
            Vector3 z= new Vector3(t, 1.05f, -30.57f);
            var k =Instantiate(P_Unit_Machine, z, P_Unit_Machine.transform.rotation);
            
        }
    } 
    public void Create_P_Unit_Gunner ()
    {
        float t = Random.Range(-1, 10);
        for (int j = 0; j < 1; j++)
        {
            t -= 1f;
            Vector3 z= new Vector3(t, 1.05f, -30.57f);
            var k =Instantiate(P_Unit_Gunner, z, P_Unit_Gunner.transform.rotation);
            
        }
    } 
    public void Create_P_Unit_Bomber ()
    {
        float t = Random.Range(-1, 10);
        for (int j = 0; j < 1; j++)
        {
            t -= 1f;
            Vector3 z= new Vector3(t, 1.05f, -30.57f);
            var k =Instantiate(P_Unit_Bomber, z, P_Unit_Bomber.transform.rotation);
            
        }
    } 
    public void Create_P_Unit_Tank ()
    {
        float t = Random.Range(-15, -5);
        for (int j = 0; j < 1; j++)
        {
            t -= 1f;
            Vector3 z= new Vector3(t, 0, -30.57f);
            var k =Instantiate(P_Unit_Tank, z, P_Unit_Tank.transform.rotation);
            
        }
    }

    public void TankAbilitiesFunc()
    {
        Debug.Log("open tank abilities");
    }
}
  