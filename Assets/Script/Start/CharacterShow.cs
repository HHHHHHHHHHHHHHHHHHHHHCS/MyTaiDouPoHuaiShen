using UnityEngine;
using System.Collections;

public class CharacterShow : MonoBehaviour 
{

    void OnPress(bool isPress)
    {
        if(!isPress)
        {
            StartMenuController._instance.OnCharacterCilcik(transform.parent.gameObject);
        }
    }
}
