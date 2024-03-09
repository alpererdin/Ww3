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
                                                                                            // y = 0.7f
            GameObject btn = Instantiate(ButtonRefPrefab, pos.position, 
                quaternion.identity,pos.transform);
            btn.transform.Rotate(new Vector3(0, -90f, 0f));//x=0,z=0
            
            btn.gameObject.transform.localPosition=new Vector3(0,0,-115f);
            
            Button _button= btn.GetComponent<Button>();
//            TextMeshProUGUI _buttonText= btn.GetComponentInChildren<TextMeshProUGUI>();
            _button.onClick.AddListener(() => CreateAndAddListenerBtn(id, btn , t));
            
          //  _button.image.sprite = sprite;
            btn.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
            
          
            _button.name = id.ToString();
//            _buttonText.text = ""+id;
            idToButtonMap.Add(id, btn);
            
        }  
        private void CreateAndAddListenerBtn(int id, GameObject btn, GameObject t)
        { 
            t.GetComponent<StageTypeOne>()._stageCount -=1;
            idToButtonMap.Remove(id);
            Destroy(btn);
            UnitSignals.Instance.SetUnitState?.Invoke(id);
        }
    }
}