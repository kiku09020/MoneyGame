using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExtendInput : MonoBehaviour {
    // マウスプロパティ
    static Mouse Mouse => GetMouse();

    // マウス取得
    static Mouse GetMouse()
    {
        var mouse = Mouse.current;

        if (mouse != null) {
            return mouse;
        }

        return null;
    }

    //-------------------------------------------

    /// <summary>
    /// マウスの座標をワールド座標として取得
    /// </summary>
    /// <returns>マウスのワールド座標</returns>
    public static Vector2 GetMousePosition_World()
    {
        var mousePos = Mouse.position.ReadValue();
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    /// <summary>
    /// マウスの座標をワールド座標として取得
    /// </summary>
    /// <param name="camera">目標のカメラ</param>
    /// <returns>マウスのワールド座標</returns>
    public static Vector2 GetMousePosition_World(Camera camera)
    {
        if (camera) {
            var mousePos = Mouse.position.ReadValue();
            return camera.ScreenToWorldPoint(mousePos);
        }

        throw new System.Exception($"{camera} doesn't exist.");
    }

    //-------------------------------------------



}
