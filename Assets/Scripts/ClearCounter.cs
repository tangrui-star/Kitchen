using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectedCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform topPoint;
    [SerializeField] private bool testing = false;
    [SerializeField] private ClearCounter transferTargetCounter;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetMouseButtonDown(0)) 
        {
            TransferKitchenObject(this,transferTargetCounter);
        }
    }

    public void Interact()
    {
        // print(this.gameObject + " Interacting ....");
        if (kitchenObject == null)
        {
            kitchenObject = GameObject.Instantiate(kitchenObjectSO.perfab, topPoint).GetComponent<KitchenObject>();
            kitchenObject.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.LogWarning("已经有了-" + gameObject.name);
        }
    }
    public void SelectedCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelected()
    {
        selectedCounter.SetActive(false);
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void TransferKitchenObject(ClearCounter sourceCounter, ClearCounter targetCounter)
    {
        if (sourceCounter.GetKitchenObject() == null)
        {
            Debug.LogWarning("源柜台上不存在食材，转移失败。");
            return;
        }
        if (targetCounter.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标柜台上存在食材，转移失败。");
            return;
        }
        targetCounter.AddKitchenObject(sourceCounter.GetKitchenObject());
        sourceCounter.ClearKitchenObject();

    }
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(topPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }
    // 清空原始食材
    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }
}
