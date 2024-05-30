using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopupController : Singleton<PopupController>
{
    [SerializeField] private PopupWindowPanel popupPanel;

    public PopupWindowPanel popup=> popupPanel;
    // Start is called before the first frame update

}
