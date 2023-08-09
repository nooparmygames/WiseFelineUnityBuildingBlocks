using NoOpArmy.WiseFeline;
using NoOpArmy.WiseFeline.BlackBoards;
using UnityEngine;

namespace NoOpArmy.UtilityAI.Considerations
{
    public class BoolBlackBoardConsideration : ConsiderationBase
    {
        public string keyName;

        protected override float GetValue(Component target)
        {
            BlackBoard blackBoard = target.GetComponent<BlackBoard>();
            if (blackBoard != null)
            {
                var value = blackBoard.GetBool(keyName);
                return value == true ? 1 : 0;
            }
            return 0;

        }
    }
}
