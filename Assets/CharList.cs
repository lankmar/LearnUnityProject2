using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GUITest
{
    public class CharList : MonoBehaviour
    {

        [SerializeField] GameObject swordsman;
        [SerializeField] GameObject archer;
        [SerializeReference] GameObject[] spheres;

        Vector3 swordsmanTransform;
        Vector3 archerTransform;
        [SerializeField] Transform aimTransform;
        // Start is called before the first frame update
        void Start()
        {
            swordsmanTransform = swordsman.transform.position;
            archerTransform = archer.transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 200, 140), "Character selection");
            if (GUI.Button(new Rect(20, 50, 180, 30), "Archer"))
            {
                Debug.Log("archers");

                SelectCharArcher();

            }
            if (GUI.Button(new Rect(20, 100, 180, 30), "Swordsman"))
            {
                Debug.Log("sword");
                SelectCharSwordsman();

                
            }
        }

        private void SelectCharArcher()
        {
                swordsman.transform.position = swordsmanTransform;
                archer.transform.position = aimTransform.position;

            if (spheres.Length > 0)
            {
                foreach (var item in spheres)
                {
                    item.GetComponent<MeshRenderer>().material.color = Color.blue;
                } 
            }
        }
        private void SelectCharSwordsman()
        {
               archer.transform.position = archerTransform;
               swordsman.transform.position = aimTransform.position;

            if (spheres.Length > 0)
            {
                foreach (var item in spheres)
                {
                    item.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }

}