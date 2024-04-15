using Data.ScriptableObjects;
using Managers;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeUnitPanelController : MonoBehaviour
{
    public Sprite basicImg;
    public Sprite machinImg;
    public Sprite gunnerImg;
    public Sprite bomberImg;
    public Sprite tankImg;
    public Image typeSprite;
    public TextMeshProUGUI typeString;
    public TextMeshProUGUI oldValue;
    public TextMeshProUGUI newValue;
    private TakePrefsData prefsData;
    public SoldierData basic;
    public SoldierData machine;
    public SoldierData gunner;
    public SoldierData bomber;
    public SoldierData tank;
    
    public Animator animator;
    private void Awake()
    {
        prefsData = FindObjectOfType<TakePrefsData>();
    }
    private void OnEnable()
    {
        GameSignals.Instance.UpgradePanel += SetUpgradePanel;
    }
    private void SetUpgradePanel(PlayerDataHandler.PlayerType arg0, PlayerDataHandler.PlayerUpgradeSelection arg1, int arg2, int arg3)
    {
        prefsData.TakeUnitsData(arg0);
      if (arg0 == PlayerDataHandler.PlayerType.Basic)
      {
          typeSprite.sprite = basicImg;
          if (arg1 == PlayerDataHandler.PlayerUpgradeSelection.Damage)
          {
              typeString.text = "DAMAGE";
              int oldDataValue = (int)(basic.baseDamage + prefsData.Damage);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Health)
          {
              typeString.text = "HEALTH";
              int oldDataValue = (int)(basic.health + prefsData.Health);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          } 
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.FireRate)
          {
              typeString.text = "Fire Rate";
              
              int oldDataValue = (int)(basic.shootSpeed + prefsData.FireRate);
              int newDataValue = oldDataValue + 1;
              oldValue.text = (oldDataValue+10).ToString();
              newValue.text = (newDataValue+10).ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Range)
          {
              typeString.text = "RANGE";
              int oldDataValue = (int)(basic.unitRange + prefsData.Range);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
      }
      else if (arg0 == PlayerDataHandler.PlayerType.Machine)
      {
          typeSprite.sprite = machinImg;
          if (arg1 == PlayerDataHandler.PlayerUpgradeSelection.Damage)
          {
              typeString.text = "DAMAGE";
              int oldDataValue = (int)(machine.baseDamage + prefsData.Damage);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Health)
          {
              typeString.text = "HEALTH";
              int oldDataValue = (int)(machine.health + prefsData.Health);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          } 
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.FireRate)
          {
              typeString.text = "Fire Rate";
              int oldDataValue = (int)(machine.shootSpeed + prefsData.FireRate);
              int newDataValue = oldDataValue + 1;
              oldValue.text = (oldDataValue+10).ToString();
              newValue.text = (newDataValue+10).ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Range)
          {
              typeString.text = "RANGE";
              int oldDataValue = (int)(machine.unitRange + prefsData.Range);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
      }
      else if (arg0 == PlayerDataHandler.PlayerType.Gunner)
      {
          typeSprite.sprite = gunnerImg;
          if (arg1 == PlayerDataHandler.PlayerUpgradeSelection.Damage)
          {
              typeString.text = "DAMAGE";
              int oldDataValue = (int)(gunner.baseDamage + prefsData.Damage);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Health)
          {
              typeString.text = "HEALTH";
              int oldDataValue = (int)(gunner.health + prefsData.Health);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          } 
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.FireRate)
          {
              typeString.text = "Fire Rate";
              int oldDataValue = (int)(gunner.shootSpeed + prefsData.FireRate);
              int newDataValue = oldDataValue + 1;
              oldValue.text = (oldDataValue+10).ToString();
              newValue.text = (newDataValue+10).ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Range)
          {
              typeString.text = "RANGE";
              int oldDataValue = (int)(gunner.unitRange + prefsData.Range);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
      }
      else if (arg0 == PlayerDataHandler.PlayerType.Bomber)
      {
          typeSprite.sprite = bomberImg;
          if (arg1 == PlayerDataHandler.PlayerUpgradeSelection.Damage)
          {
              typeString.text = "DAMAGE";
              int oldDataValue = (int)(bomber.baseDamage + prefsData.Damage);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Health)
          {
              typeString.text = "HEALTH";
              int oldDataValue = (int)(bomber.health + prefsData.Health);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          } 
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.FireRate)
          {
              typeString.text = "Fire Rate";
              int oldDataValue = (int)(bomber.shootSpeed + prefsData.FireRate);
              int newDataValue = oldDataValue + 1;
              oldValue.text = (oldDataValue+10).ToString();
              newValue.text = (newDataValue+10).ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Range)
          {
              typeString.text = "RANGE";
              int oldDataValue = (int)(bomber.unitRange + prefsData.Range);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
          
      }
      else if (arg0 == PlayerDataHandler.PlayerType.Tank)
      {
          typeSprite.sprite = tankImg;
          if (arg1 == PlayerDataHandler.PlayerUpgradeSelection.Damage)
          {
              typeString.text = "DAMAGE";
              int oldDataValue = (int)(tank.baseDamage + prefsData.Damage);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Health)
          {
              typeString.text = "HEALTH";
              int oldDataValue = (int)(tank.health + prefsData.Health);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          } 
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.FireRate)
          {
              typeString.text = "Fire Rate";
              int oldDataValue = (int)(tank.shootSpeed + prefsData.FireRate);
              int newDataValue = oldDataValue + 1;
              oldValue.text = (oldDataValue+10).ToString();
              newValue.text = (newDataValue+10).ToString();
          }
          else if(arg1 == PlayerDataHandler.PlayerUpgradeSelection.Range)
          {
              typeString.text = "RANGE";
              int oldDataValue = (int)(tank.unitRange + prefsData.Range);
              int newDataValue = oldDataValue + 1;
              oldValue.text = oldDataValue.ToString();
              newValue.text = newDataValue.ToString();
          }
      }

      animator.SetTrigger("PanelMoveIn");
     //  Invoke("Hobb",1f);
    }

    void Hobb()
    {
        animator.SetTrigger("PanelMoveOut");
    }

    public void clickSounnd()
    {
        AudioManager.Instance.PlaySFX("Click");
    }
}
