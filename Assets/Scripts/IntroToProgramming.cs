using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class IntroToProgramming : MonoBehaviour
{

        [SerializeField] 
        private int numberOfObjectsToCreate = 1;
        
        [SerializeField] 
        private float objectScale = 1;
        
        [SerializeField] 
        private Color modelColor = Color.white;

        [SerializeField] 
        private GameObject model;

        [SerializeField] 
        private int numberOfObjectsInScene = 0;

        [SerializeField] private Transform spawnPoint;

        public void CreateButtonAction()
        {
                numberOfObjectsInScene = numberOfObjectsInScene + CreateObjects(numberOfObjectsToCreate, model, modelColor, objectScale);
        }

        private int CreateObjects(int num, GameObject model, Color color, float scale)
        {
            for (int i = 0; i < num; i++)
            {
                GameObject item = Instantiate(model, spawnPoint.transform.position+Vector3.up*i, RandomQuaternion());
                ApplyColor(item, color);
                item.AddComponent<Rigidbody>();
                item.transform.localScale = Vector3.one*scale;
                ApplyLayer(item, "Default");
            }

            return num;
        }

        void ApplyColor(GameObject obj, Color col)
        {
            MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mr in renderers)
            {
                foreach (Material mat in mr.materials)
                {
                    mat.color = col;
                }
            }
        }

        void ApplyLayer(GameObject item, string layerName)
        {
            item.layer = LayerMask.NameToLayer(layerName);
            foreach (Transform child in item.transform)
            {
                if (child.childCount > 0)
                {
                    ApplyLayer(child.gameObject, layerName);
                }
                else
                {
                    child.gameObject.layer = LayerMask.NameToLayer(layerName);
                }
                
            }
        }

        Quaternion RandomQuaternion()
        {
            return new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f),1);
        }
        #region AccessorMethods
        public int NumberOfObjectsToCreate
        {
            set => numberOfObjectsToCreate = value;
            get => numberOfObjectsToCreate;
        }

        public Color ModelColor
        {
            get => modelColor;
            set => modelColor = value;
        }

        public float ObjectScale
        {
            get => objectScale;
            set => objectScale = value;
        }

        public GameObject Model
        {
            set => model = value;
            get => model;
        }
        
        #endregion

}
