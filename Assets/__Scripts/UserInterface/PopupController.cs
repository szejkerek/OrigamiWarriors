using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopupController : Singleton<PopupController>
{
    [SerializeField] private PopupWindowPanel popupPanel;

    public PopupWindowPanel PopupPanel=> popupPanel;
}
