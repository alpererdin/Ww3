using System;
using Signals;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using Random = System.Random;
namespace Managers
{
    public class AbilityManager : MonoBehaviour
    {
        public GameObject tankBomb;
        public GameObject planeBomb;
        public Transform tankBase;
        public Transform planeBase;
        public float bombSpeed = 50f;
        public int numShots = 3;
        private void OnEnable()
        {
            GameSignals.Instance.TargetTankAbility += ListenTargetCoord;
            GameSignals.Instance.TargetPlaneAbility += ListenPlaneTarget;
        }
        private void ListenPlaneTarget(Vector3 targetPosition)
        {
            StartCoroutine(FireRandomPlaneShots(targetPosition));
        }
        private void ListenTargetCoord(Vector3 targetPosition)
        {
            StartCoroutine(FireRandomShots(targetPosition));
        }
        private IEnumerator FireRandomShots(Vector3 targetPosition)
        {
            for (int i = 0; i < numShots; i++)
            {
                Vector3 randomTarget = GetRandomTarget(targetPosition);
                StartCoroutine(MoveBombToTarget(randomTarget));
                yield return new WaitForSeconds(1f);
            }
        }
        private IEnumerator FireRandomPlaneShots(Vector3 targetPosition)
        {
          
            for (int i = 0; i < numShots; i++)
            {
                Vector3 randomTarget = GetPlaneTarget(targetPosition);
                StartCoroutine(MovePlaneBombToTarget(randomTarget));
                yield return new WaitForSeconds(1f);
            }
        }
        private Vector3 GetRandomTarget(Vector3 targetPosition)
        {
            float a = UnityEngine.Random.Range(0,10);
            float z = UnityEngine.Random.Range(0, 2);
            Vector3 randomTarget = new Vector3(targetPosition.x + a, targetPosition.y, targetPosition.z + z);
            return randomTarget;
        } 
        private Vector3 GetPlaneTarget(Vector3 targetPosition)
        {
            float a = UnityEngine.Random.Range(0, 2);
            float z = UnityEngine.Random.Range(0, 10); 
            Vector3 randomTarget = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z + z);
            return randomTarget;
        }
        private IEnumerator MoveBombToTarget(Vector3 targetPosition)
        {
            GameObject bombInstance = Instantiate(tankBomb, tankBase.position, Quaternion.identity);

            while (Vector3.Distance(bombInstance.transform.position, targetPosition) > 0.01f)
            {
                bombInstance.transform.position = Vector3.MoveTowards(bombInstance.transform.position, targetPosition, bombSpeed * Time.deltaTime);
                yield return null;
            }
        }
        private IEnumerator MovePlaneBombToTarget(Vector3 targetPosition)
        {
            GameObject bomb = Instantiate(planeBomb, planeBase.position, Quaternion.identity);

            while (Vector3.Distance(bomb.transform.position, targetPosition) > 0.01f)
            {
                bomb.transform.position = Vector3.MoveTowards(bomb.transform.position, targetPosition, bombSpeed * Time.deltaTime);
                yield return null;
            }
        }
        private void OnDisable()
        {
            GameSignals.Instance.TargetTankAbility -= ListenTargetCoord;
            GameSignals.Instance.TargetPlaneAbility -= ListenPlaneTarget;
        }
    }
}