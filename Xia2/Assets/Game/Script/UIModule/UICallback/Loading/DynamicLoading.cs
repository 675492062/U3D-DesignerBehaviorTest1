using UnityEngine;
using System.Collections;

public class DynamicLoading : MonoBehaviour {

    public int count = 4;

    public string[] spritName = new string[] { "NGUI", "NGUI", "NGUI", "NGUI" };

    public int[] texts = new int[] { 1, 2, 3, 4 };

    private Transform offset;

    private GameObject obj;

    // Use this for initialization
    void Awake()
    {
        offset = transform;
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Load(i, spritName[i]);
        }
        //重新排列
        UIGrid grid = (UIGrid)offset.GetComponentInChildren<UIGrid>();
        grid.repositionNow = true;
    }

    void Load(int text, string spritName)
    {
		GameObject instance = Instantiate(Resources.Load("Prefab/LoginSystem/TeamImage", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = offset;
        instance.transform.localScale = Vector3.one;
        Vector3 pos = instance.transform.position;
        pos.y -= 100;
        instance.transform.position = pos;

        offset s = instance.GetComponent<offset>();
        s.label.text = text.ToString();
        s.sprite.name = spritName;
        
    }
}
