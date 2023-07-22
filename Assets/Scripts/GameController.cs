using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController _instance = null;
    private void Awake(){
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
    public static GameController Instance { get { return _instance; } }
    #endregion
    [field: SerializeField]
    public Bounds Bounds {get; private set;}

}
