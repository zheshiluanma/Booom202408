using System.Collections.Generic;
using Manager;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Prop
{
    public class UpLevelPanel : MonoBehaviour
    {
        [SerializeField]private GameObject[] propPrefabs;

        [SerializeField]private int showCount;

        [SerializeField]private GameObject[] showCards;

        public void Open()
        {
            Show();
            RandomSelect();
        }

        private void RandomSelect()
        {
            Random random = new Random();
        
            int arrayLength = propPrefabs.Length;
            HashSet<int> usedIndices = new HashSet<int>();
            showCards = new GameObject[showCount];

            for (int i = 0; i < showCount; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = random.Next(arrayLength-1);
                } while (usedIndices.Contains(randomIndex));

                showCards[i] = propPrefabs[randomIndex];
                usedIndices.Add(randomIndex);
            }

            foreach (var go in showCards)
            {
                Instantiate(go,transform).GetComponent<Button>().onClick.AddListener(()=>OnPropCardClick(go.GetComponent<Prop>().propAttribute));
            }
        }

        private void OnPropCardClick(PropAttribute propAttribute)
        {
            foreach (var go in showCards)
            {
                DestroyImmediate(go);
            }

            Hide();

            DataMgr.Instance.UpLevel(propAttribute);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    
    }
}
