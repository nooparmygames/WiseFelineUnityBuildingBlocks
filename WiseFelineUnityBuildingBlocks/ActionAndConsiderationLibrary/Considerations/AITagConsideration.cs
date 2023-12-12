using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using NoOpArmy.WiseFeline.AITags;

namespace NoOpArmy.WiseFeline.Considerations
{
    /// <summary>
    /// This consideration checks if the target or the executing agent has or doesn't have a specific tag.
    /// </summary>
    public class AITagConsideration : ConsiderationBase
    {
        /// <summary>
        /// The tag to consider
        /// </summary>
        public string tag;

        /// <summary>
        /// The operation to do on the tag to find the score
        /// </summary>
        public TagOperation operation;

        public enum TagOperation
        {
            /// <summary>
            /// The object should have the tag
            /// </summary>
            ShouldHaveTag,

            /// <summary>
            /// The object should not have the tag
            /// </summary>
            ShouldNotHaveTag
        }

        protected override float GetValue(Component target)
        {
            if(target == null)
            {
                return 0;
            }

            AITags.AITags tagsComp = target.GetComponent<AITags.AITags>();
            if (tagsComp == null)
                return 0;
            if (operation == TagOperation.ShouldHaveTag && tagsComp.HasTag(tag))
            {
                return 1;
            }
            if (operation == TagOperation.ShouldNotHaveTag && !tagsComp.HasTag(tag))
            {
                return 1;
            }
            return 0;
        }
    }
}