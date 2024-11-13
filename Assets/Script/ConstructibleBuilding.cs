using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructibleBuilding : MonoBehaviour
{
    [Header("Building Seetings")]
    public BuildingType buildingType;
    public string buildingName;
    public int requiredTree = 5;
    public float constructionTime = 2.0f;

    public bool canBuild = true;
    public bool isConstructed = false;

    private Material buildngMaterial;

    // Start is called before the first frame update
    void Start()
    {
        buildngMaterial = GetComponent<MeshRenderer>().material;

        Color color = buildngMaterial.color;
        color.a = 0.5f;
        buildngMaterial.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CostructionRoutine()
    {
        canBuild = false;
        float timer = 0;
        Color color = buildngMaterial.color;

        while (timer < constructionTime)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0.5f, 1f, timer / constructionTime);
            buildngMaterial.color = color;
            yield return null;
        }
        isConstructed = true;

        if(FloatingTextManager.Instance != null)
        {
            FloatingTextManager.Instance.Show($"{buildingName} 건설 완료!", transform.position + Vector3.up);
        }

    }

    public void StartConstruction(PlayerInventory inventory)
    {
        if (!canBuild || isConstructed) return;

        if(inventory.treeCount >= requiredTree)
        {
            inventory.RemoveItem(ItemType.Tree, requiredTree);
            if (FloatingTextManager.Instance != null)
            {
                FloatingTextManager.Instance.Show($"{buildingName} 건설 시작!", transform.position + Vector3.up);
            }
            StartConstruction(CostructionRoutine());
        }
        else
        {
            if (FloatingTextManager.Instance != null)
            {
                FloatingTextManager.Instance.Show($"나무가 부족합니다! ({inventory.treeCount} / {requiredTree})", transform.position + Vector3.up);
            }
        }

    }

}
