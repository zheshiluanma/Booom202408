using PolyNav;
using UnityEngine;
    public class MapCtrl : MonoBehaviour
    {
        public PolyNavMap polyNavMap;
        private static MapCtrl _instance;

        public static MapCtrl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MapCtrl>();
                }

                return _instance;
            }
        }
    }
