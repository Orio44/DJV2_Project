using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTile : MonoBehaviour
{
    private Camera _mainCamera;
    private float _mousePositionOnPlane;
    private Plane _plane;

    [SerializeField] GameObject selected;
    [SerializeField] GameObject nonSelected;
    [SerializeField] GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _plane = new Plane(Vector3.up, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectTile())
        {
            selected.SetActive(true);
            nonSelected.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                ui.SetActive(true);
            }
        }
        else
        {
            selected.SetActive(false);
            nonSelected.SetActive(true);
        }
    }

    private bool SelectTile()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _plane.Raycast(ray, out _mousePositionOnPlane);
        float xMousePosition = ray.GetPoint(_mousePositionOnPlane).x;
        float yMousePosition = ray.GetPoint(_mousePositionOnPlane).y;
        bool isInTileX = transform.position.x - transform.localScale.x < xMousePosition && xMousePosition < transform.position.x + transform.localScale.x;
        bool isInTileY = transform.position.y - transform.localScale.y < yMousePosition && yMousePosition < transform.position.y + transform.localScale.y;
        return isInTileX && isInTileY;
    }
}
