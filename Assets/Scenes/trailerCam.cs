using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailerCam : MonoBehaviour
{
    public float rotationSpeed = 90f; // Dönme hızı (derece/s)
    private bool isRotating = false; // Dönme durumu
    private float startAngle; // Başlangıç açısı

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isRotating)
        {
            StartCoroutine(RotateAround());
        }
    }

    IEnumerator RotateAround()
    {
        isRotating = true; // Dönme durumunu aktif yap
        startAngle = transform.eulerAngles.y; // Başlangıç açısını kaydet

        float targetAngle = startAngle + 360f; // Hedef açıyı hesapla
        float elapsedTime = 0f;

        while (transform.eulerAngles.y < targetAngle) // Hedef açıya ulaşana kadar dönme işlemini yap
        {
            elapsedTime += Time.deltaTime; // Zamanı ilerlet
            float angle = Mathf.Lerp(startAngle, targetAngle, elapsedTime * rotationSpeed / 360f); // Dönme açısını hesapla
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z); // Yeni açıyı uygula

            yield return null; // Bir sonraki frame'e geç
        }

        isRotating = false; // Dönme işlemi tamamlandığında dönme durumunu pasif yap
    }
}