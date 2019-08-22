using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Tooltip("Place within me a Prefab of the cursor you would like.")]
    [SerializeField] private GameObject customCursorPrefab = null;
    private GameObject customCursorObject = null;
    private Animator cursorAnimator = null;
    private string pressedBoolStringReference = "Pressed";

    void Start()
    {
        Cursor.visible = false;
        CreateCursorObject();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        customCursorObject.transform.position = cursorPos;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cursorAnimator.SetBool(pressedBoolStringReference, true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            cursorAnimator.SetBool(pressedBoolStringReference, false);
        }
    }

    private void CreateCursorObject()
    {
        customCursorObject = Instantiate(customCursorPrefab);

        cursorAnimator = customCursorObject.GetComponent<Animator>();

        customCursorObject.transform.parent = this.transform;
    }
}
