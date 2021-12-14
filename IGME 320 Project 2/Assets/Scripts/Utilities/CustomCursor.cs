using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    private SpriteRenderer sprRnd;
    public Sprite gripCursor;
    public Sprite openCursor;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        sprRnd = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0, 0, 99f);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        transform.position = new Vector3(mainCamera.ScreenToWorldPoint(mousePos).x, mainCamera.ScreenToWorldPoint(mousePos).y, 99f);
    }

    private void OnClick(InputValue val)
    {
        if (val.isPressed)
            sprRnd.sprite = gripCursor;
        else
            sprRnd.sprite = openCursor;
    }
}
