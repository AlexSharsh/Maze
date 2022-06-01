using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Maze
{
    delegate void UI();
    class MyEvent
    {
        public event UI UserEvent;

        public void OnUserEvent()
        {
            UserEvent();
        }
    }

    public class TestEvent : MonoBehaviour
    {
        string UILogin;
        int UIAge;

        public UnityEvent TestUnityEvent;

        private void OnEnable()
        {
            if (TestUnityEvent == null)
            {
                TestUnityEvent = new UnityEvent();
            }

            TestUnityEvent.AddListener(UserInfoHandler);
        }

        private void OnDisable()
        {
            if (TestUnityEvent == null)
            {
                TestUnityEvent = new UnityEvent();
            }

            TestUnityEvent.RemoveListener(UserInfoHandler);
        }

        public void UserInfoHandler()
        {
            Debug.Log("Произошло событие: " + UILogin + " " + UIAge);
        }

        void Start()
        {
            MyEvent tempEvent = new MyEvent();

            UILogin = "User";
            UIAge = 19;

            tempEvent.UserEvent += UserInfoHandler;
            tempEvent.OnUserEvent();

            TestUnityEvent.Invoke();
        }
    }
}
