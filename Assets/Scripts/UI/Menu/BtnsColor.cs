using System.Collections;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.UI;

public class BtnsColor : MonoBehaviour
{
    public List<Image> a;
    int i = 0;
    public void paint3d()
    {
        GameSignals.Instance.PlayOneShotEffect?.Invoke();
        if (i>=5) return;
        a[i].color=Color.green;
        i++;
    }
}
