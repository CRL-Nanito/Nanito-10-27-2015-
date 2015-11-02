using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        bool turbo = false;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
            

            if (Input.GetKeyDown(KeyCode.T) && turbo)
            {
                m_Car.m_FullTorqueOverAllWheels = 500000;
                StartCoroutine(turboTime());
            }
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
        private void onTriggerEnter(Collision other)
        {
            if (other.gameObject.tag == "itemBox")
            {
                // int ran = UnityEngine.Random.Range(0, 0);
                int ran = 0;
                switch (ran)
                {
                    case 0:
                        turbo = true;
                        break;
                }
               
            }
        }

        IEnumerator turboTime()
        {
            yield return new WaitForSeconds(5f);
            m_Car.m_FullTorqueOverAllWheels = 2500;
        }
    }
}
