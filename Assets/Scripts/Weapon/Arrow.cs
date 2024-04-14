using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField]
        private float damage = 0;

        public float Damage => damage;
    }
}
