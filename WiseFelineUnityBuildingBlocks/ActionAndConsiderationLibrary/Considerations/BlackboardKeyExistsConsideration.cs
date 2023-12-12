using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    /// <summary>
    /// This consideration returns 1 if the specified key name exists and otherwise returns 0
    /// </summary>
    public class BlackboardConsiderationKeyExists : ConsiderationBase
    {

        /// <summary>
        /// The blackboard key type
        /// </summary>
        public enum KeyType
        {
            Float,
            Int,
            Bool,
            GameObject,
            UnityObject,
            Object,
            Vector3
        }

        /// <summary>
        /// Name of the key in the blackboard
        /// </summary>
        [Tooltip("Name of the key in the blackboard")]
        public string keyName;

        /// <summary>
        /// Type of the key to check for existence
        /// </summary>
        [Tooltip("Type of the key to check for existence")]
        public KeyType keyType;

        protected override float GetValue(Component target)
        {
            BlackBoard blackBoard = target.GetComponent<BlackBoard>();
            if (blackBoard != null)
            {
                switch (keyType)
                {
                    case KeyType.Float:
                        if (blackBoard.HasFloat(keyName))
                            return 1;
                        break;
                    case KeyType.Int:
                        if (blackBoard.HasInt(keyName))
                            return 1;
                        break;
                    case KeyType.Bool:
                        if (blackBoard.HasBool(keyName))
                            return 1;
                        break;
                    case KeyType.GameObject:
                        if (blackBoard.HasGameObject(keyName))
                            return 1;
                        break;
                    case KeyType.UnityObject:
                        if (blackBoard.HasUnityObject(keyName))
                            return 1;
                        break;
                    case KeyType.Object:
                        if (blackBoard.HasObject(keyName))
                            return 1;
                        break;
                    case KeyType.Vector3:
                        if (blackBoard.HasVector3(keyName))
                            return 1;
                        break;
                }
            }
            return 0;
        }
    }
}