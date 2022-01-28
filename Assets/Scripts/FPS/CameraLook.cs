using UnityEngine;

namespace FPS
{
    public class CameraLook : MonoBehaviour
    {
        #region Variables
        #region Public
        [Header("Configuration")]
        public Transform playerBody;
        public float mouseSensitivity = 100f;
        #endregion

        #region Private
        float _xRotation = 0f;
        float _mouseX, _mouseY;
        #endregion
        #endregion

        #region Logic
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
        } // Start

        // Update is called once per frame
        void Update()
        {
            _mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            _mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * _mouseX);
        } // Update
        #endregion
    } // CameraLook
} // namespace
