using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectedCounter;
    public void Interact()
    {
        print(this.gameObject + " Interacting ....");
    }
    public void SelectedCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelected()
    {
        selectedCounter.SetActive(false);
    }
}
