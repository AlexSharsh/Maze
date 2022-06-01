using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class Controller
    {
        private Transform _player;
        private View _trigger;
        private View _playerView;

        public Controller(View player, View trigger)
        {
            _playerView = player;
            _player = player.transform;
            _trigger = trigger;

            _trigger.OnLevelObjectContact += ControllerRecieveAction;
        }

        private void ControllerRecieveAction(Collider contactView, int Val, Transform valT)
        {
            Debug.Log("Обработчик события: Имя объекта в триггере" + contactView.gameObject.name);
            GameObject.Destroy(contactView.gameObject);
        }

        public void MyUpdate()
        {

        }
    }
}
