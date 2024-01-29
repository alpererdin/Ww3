using System;
using System.Collections.Generic;
using Signals;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
namespace Managers
{
    public class ButtonManager : MonoBehaviour
    {
        public GameObject CanvasObj;
        public GameObject ButtonRefPrefab;
        float t=0;
        private Dictionary<int, GameObject> idToButtonMap = new Dictionary<int, GameObject>();
        private Color chech;

        private void OnEnable()
        {
            UnitSignals.Instance.OnUnitID += PasteID;
        }
        private void PasteID(int id,Color color,Transform pos)
        {
            if (chech == color)
            {
                t += 0.8f;
            }
            else
            {
                t = 0;
            }
            chech = color;
            GameObject btn = Instantiate(ButtonRefPrefab, pos.position+new Vector3(5.5f,0,t), quaternion.identity,CanvasObj.transform);
            btn.transform.localScale=new Vector3(0.01f, 0.01f, 0.01f);
            btn.transform.Rotate(new Vector3(0f, 270f, 0));
           
         
            Button _button= btn.GetComponent<Button>();
            TextMeshProUGUI _buttonText= btn.GetComponentInChildren<TextMeshProUGUI>();
            _button.onClick.AddListener(() => CreateAndAddListenerBtn(id, btn));
            _button.image.color = color;
            _button.name = id.ToString();
            _buttonText.text = ""+id;
            idToButtonMap.Add(id, btn);
        }  
        private void CreateAndAddListenerBtn(int id, GameObject btn)
        {
            idToButtonMap.Remove(id);
            Destroy(btn);
            UnitSignals.Instance.SetUnitState?.Invoke(id);
             
            
        }
    }
}