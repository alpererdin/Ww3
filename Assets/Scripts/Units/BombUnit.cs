using UnityEngine;

namespace Units
{
    public class BombUnit : MonoBehaviour
    {
        internal int Speed; 
        //[HideInInspector]
      //  public BaseState CurrentState;
        [HideInInspector]
        public int ID;
        [HideInInspector]
        public Color BtnColor;
        [HideInInspector]
        public Sprite test;
        [HideInInspector]
        public bool onFight = false;
        [HideInInspector]
        public bool onStage = false;
        [HideInInspector]
        public float Range;
        [HideInInspector]
        public LayerMask enemyLayer;
        [HideInInspector]
        public ParticleSystem shootParticle;
        [HideInInspector]
        public Animator gunAnim;
        [HideInInspector]
        public Animator _anim;
        //[HideInInspector]
        //public BaseState memory;  
        [HideInInspector]
        public float Damage;

        public GameObject currentStage;
    }
}