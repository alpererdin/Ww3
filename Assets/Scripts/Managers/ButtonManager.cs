using System;
using System.Collections.Generic;
using Signals;
using Stages;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace Managers
{
    public class ButtonManager : MonoBehaviour
    {
        public GameObject ButtonRefPrefab;
        public Dictionary<int, GameObject> idToButtonMap = new Dictionary<int, GameObject>();
        private void OnEnable()
        {
            UnitSignals.Instance.OnUnitID += PasteID;
        }


        private void PasteID(int id,Sprite sprite,Transform pos,GameObject t)//Color color
        {
            t.GetComponent<StageTypeOne>()._stageCount +=1;
            GameObject btn = Instantiate(ButtonRefPrefab, pos.position, quaternion.identity,pos.transform);
            btn.transform.Rotate(new Vector3(0, -90f, 0f));//x=0,z=0 ,y=-86f
            btn.gameObject.transform.localPosition=new Vector3(0,0,0);//z=-115 z=-150
            Button _button= btn.GetComponent<Button>();
            _button.onClick.AddListener(() => CreateAndAddListenerBtn(id, btn , t));
            btn.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
            _button.name = id.ToString();
            idToButtonMap.Add(id, btn);
        }  
        private void CreateAndAddListenerBtn(int id, GameObject btn, GameObject t)
        { 
            AudioManager.Instance.PlaySFX("Click");
            //GameSignals.Instance.PlayEffect?.Invoke(0);
            t.GetComponent<StageTypeOne>()._stageCount -=1;
            idToButtonMap.Remove(id);
            Destroy(btn);
            UnitSignals.Instance.SetUnitState?.Invoke(id);
        }

        // 13.03 17:52
        private void OnDisable()
        {
            UnitSignals.Instance.OnUnitID -= PasteID;
        }
    }
}