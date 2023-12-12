using NoOpArmy.WiseFeline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NoOpArmy.UtilityAI.Considerations
{

    /// <summary>
    /// Returns a constant value.
    /// This consideration is mostly used for testing
    /// </summary>
    public class ConstBoolConsideration : ConsiderationBase
    {
        /// <summary>
        /// The value to return if isTrue is set.
        /// </summary>
        public float trueValue = 1;

        /// <summary>
        /// The value to return if isTrue is not set.
        /// </summary>
        public float falseValue = 0;

        /// <summary>
        /// Is this consideration in the true condition or not
        /// </summary>
        public bool isTrue = true;

        protected override float GetValue(Component target)
        {
            return isTrue ? trueValue : falseValue;
        }
    }
}
