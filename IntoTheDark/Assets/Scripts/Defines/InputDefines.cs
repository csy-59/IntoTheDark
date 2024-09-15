using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defines
{
    public static class InputDefines
    {
        public enum ActionMapType
        {
            Player,
        }

        public enum ActionPoint
        {
            IsStarted,
            IsPerformed,
            IsCanceled,
            All,
        }
        public struct InputActionName
        {
            public InputActionName(ActionMapType _mapType, string _actionName)
            {
                MapType = _mapType;
                ActionName = _actionName;
            }

            public ActionMapType MapType { get; }
            public string ActionName { get; }
        }

        public readonly static string Move = "Move";
        public readonly static string Jump = "Jump";
        public readonly static string Dash = "Dash";
        public readonly static string Magic = "Interact";
    }

}
