using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum ItemType
{
    Crystal,
    Plant,
    Bush,
    Tree,
    VegetableStow,
    FruitSalad,
    RepairKit

}
public class ItemDetector : MonoBehaviour
{
    public float chekRadius = 3.0f;
    private Vector3 lastPosition;
    private float moveThreshold = 0.1f;
    private CollectibleItem currentNearbyItem;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        CheckForItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastPosition, transform.position) > moveThreshold)
        {
            CheckForItem();
            lastPosition = transform.position;
        }

        if (currentNearbyItem != null && Input.GetKeyDown(KeyCode.E))
        {
            currentNearbyItem.CollectItem(GetComponent<PlayerInventory>());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, chekRadius);
    }

    private void CheckForItem()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, chekRadius);
        
        float closestDistance = float.MaxValue;
        CollectibleItem closestItem = null;

        foreach (Collider collider in hitColliders)
        {
            CollectibleItem item = collider.GetComponent<CollectibleItem>();
            if (item != null && item.canCollect)
            {
                float distance = Vector3.Distance(transform.position, item.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestItem = item;
                }
            }
        }
        if (closestItem != currentNearbyItem)
        {
            currentNearbyItem = closestItem;
            if (currentNearbyItem != null)
            {
                Debug.Log($"[E] 키를 눌러 {currentNearbyItem.itemName} 수집");
            }
        }
    }

}
