using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Test {
    public class Plaeyer : MonoBehaviour {

        [SerializeField] Rigidbody2D rb;
        [SerializeField] float jumpForce;
        [SerializeField] float moveSpeed;

        [SerializeField] SpriteRenderer rend;

        public SpriteRenderer Rend => rend;

        //--------------------------------------------------

        float x = 0;


        public void Move(InputAction.CallbackContext callbackContext)
        {
            x = callbackContext.ReadValue<float>();
        }

        public void Jump()
        {
            rb.AddForce(jumpForce * Vector2.up);
        }

        void Update()
        {
            rb.AddForce(moveSpeed * x * Vector2.right);
        }
    }
}