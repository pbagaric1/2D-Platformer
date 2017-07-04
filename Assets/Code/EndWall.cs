using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class EndWall : MonoBehaviour
    {
        private Boss boss;

        void Start()
        {
            boss = GameObject.FindObjectOfType(typeof(Boss)) as Boss;
        }

        void Update()
        {
            if (boss.Health <= 0)
                Destroy(gameObject);
        }
    }

