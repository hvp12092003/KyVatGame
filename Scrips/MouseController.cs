using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Lấy vị trí chuột trên màn hình
        Vector3 mousePosition = Input.mousePosition;

        // Chuyển đổi vị trí chuột từ không gian màn hình sang không gian thế giới
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        worldPosition.z = 10;
        // Cập nhật vị trí của đối tượng để di chuyển theo vị trí chuột
        transform.position = worldPosition;
    }
}
