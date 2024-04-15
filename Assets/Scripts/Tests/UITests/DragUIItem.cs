using System;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
public class DragUIItem : MonoBehaviour, IEndDragHandler, IDragHandler
{
    private Vector3 initialPosition;
    private RectTransform rectTransform;
    public LayerMask abilityLayerMask;
    private float cooldownDuration = 10f;
    public Image fillImage;
    private bool cd=true;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (cd)
        {
            Vector2 dropPosition = eventData.position;
            Ray ray = Camera.main.ScreenPointToRay(dropPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, abilityLayerMask))
            {
                GameSignals.Instance.TargetTankAbility?.Invoke(hit.point);
                StartCoroutine(WaitForCooldown());
            }
        }

        ReturnToInitialPosition();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (cd)
        {
            transform.position = eventData.position;
        }
    }
    public void ReturnToInitialPosition()
    {
        rectTransform.anchoredPosition = initialPosition;
    } 
    private IEnumerator WaitForCooldown()
    {
        cd = false;
        float elapsedTime = 0f;
        while (elapsedTime < cooldownDuration)
        {
            fillImage.fillAmount = elapsedTime / cooldownDuration;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cd = true;
        fillImage.fillAmount = 0f;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}