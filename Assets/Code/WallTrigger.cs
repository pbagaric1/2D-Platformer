using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class WallTrigger : MonoBehaviour
    {
        public GameObject Wall;
        public GameObject WallPoint;
        public float speed;
        public Boss boss;
        private bool isLerp;
        public Coroutine gameCoroutine = null;

        //public Camera mainCamera;
        //public Camera bossCamera;

        //public BoxCollider2D BossBounds;

        //private CameraController cameraController;
        public bool CoroutineStarted = false;

        void Start()
        {
            //cameraController = GameObject.FindObjectOfType(typeof(CameraController)) as CameraController;
        }

        //void Update()
        //{
        //}


        public void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<Player>();
            if (player == null)
                return;
            if (CoroutineStarted == false)
            {
                //mainCamera.enabled = false;
                //bossCamera.enabled = true;
                StartCoroutine("WallGoDown");
            }
           

            CoroutineStarted = true;
            
        }

        IEnumerator WallGoDown()
        {
            while (Wall.transform.position.y != WallPoint.transform.position.y)
            {
                Wall.transform.position = Vector2.MoveTowards(Wall.transform.position, new Vector2(WallPoint.transform.position.x, WallPoint.transform.position.y), speed);

                yield return null;
            }

            yield return new WaitForSeconds(2f);

            gameCoroutine = StartCoroutine(boss.GetComponent<Boss>().boss());
        }
    }
   