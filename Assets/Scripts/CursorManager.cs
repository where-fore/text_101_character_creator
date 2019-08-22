using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Tooltip("Place within me a Prefab of the cursor you would like.")]
    [SerializeField] private GameObject customCursorPrefab = null;
    private GameObject customCursorObject = null;

    void Start()
    {
        Cursor.visible = false;
        CreateCursorObject();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        customCursorObject.transform.position = cursorPos;
    }

    private void CreateCursorObject()
    {
        customCursorObject = Instantiate(customCursorPrefab);
        customCursorObject.transform.parent = this.transform;
    }
}
