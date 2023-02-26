using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;

        //[SerializeField] private Animator _animator;
        [SerializeField] private float _groundDistance;
        //[SerializeField] private Health _healthComponent;

        private float _horizontalMovement;
        private float _verticalMovement;

        private Vector3 _currentAimPoint;

        private float _gravity = -9.81f;

        private bool _isGrounded
        {
            get
            {
                if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1f))
                {
                    return hitInfo.distance <= _groundDistance; //Shorthand if statement
                }

                return false;
            }
        }

        public double health
        {
            get
            {
                return 0; //_healthComponent.currentHealth;
            }

        }

        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            CalcAimPoint();
            ProcessInput();
            RotateTowards(_currentAimPoint);
            //UpdateAnimations();
        }

        public void TakeDamage(double damage)
        {
            //_healthComponent.TakeDmg(damage);
        }

        private void CalcAimPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            if (!plane.Raycast(ray, out float distance))
            {
                _currentAimPoint = Vector3.zero;
                return;
            }

            _currentAimPoint = ray.GetPoint(distance);
        }

        private void RotateTowards(Vector3 position)
        {
            position.y = transform.position.y;
            Vector3 targetDirection = position - transform.position;
            Vector3 newDirection =
                Vector3.RotateTowards(transform.forward, targetDirection, 360 * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        private void ProcessInput()
        {
            Vector3 axisVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            axisVector = Quaternion.Euler(0f, 45f, 0f) * axisVector;

            float verticalSpeed = 0f;

            if (!_isGrounded)
            {
                verticalSpeed = _gravity * Time.deltaTime;
            }

            if (axisVector.magnitude > 0)
            {
                Vector3 normalizedLookingAt = transform.forward.normalized;

                _verticalMovement = Mathf.Clamp(Vector3.Dot(axisVector, normalizedLookingAt), -1, 1);

                Vector3 perpendicularLookingAt = new Vector3(normalizedLookingAt.z, 0f, -normalizedLookingAt.x);

                _horizontalMovement = Mathf.Clamp(Vector3.Dot(axisVector, perpendicularLookingAt), -1, 1);
            }

            Vector3 movementVector = axisVector.normalized * Time.deltaTime * 2.5f;
            movementVector.y = verticalSpeed;
            _controller.Move(movementVector);
        }
    }
}
