using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameObject DeadPanel;

    public void deadTrigger()
    {
        DeadPanel.SetActive(true);
    }
}
