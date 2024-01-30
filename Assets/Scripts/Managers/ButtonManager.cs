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
        private Dictionary<int, GameObject> idToButtonMap = new Dictionary<int, GameObject>();
        private void OnEnable()
        {
            UnitSignals.Instance.OnUnitID += PasteID;
        }
        private void PasteID(int id,Color color,Transform pos,GameObject t)
        {
            t.GetComponent<StageTypeOne>()._stageCount +=1;
         
            GameObject btn = Instantiate(ButtonRefPrefab, pos.position+new Vector3(0f,.7f,0), quaternion.identity,pos.transform);
            btn.transform.Rotate(new Vector3(0f, -90f, 0));
            Button _button= btn.GetComponent<Button>();
            TextMeshProUGUI _buttonText= btn.GetComponentInChildren<TextMeshProUGUI>();
            _button.onClick.AddListener(() => CreateAndAddListenerBtn(id, btn , t));
            _button.image.color = color;
            _button.name = id.ToString();
            _buttonText.text = ""+id;
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