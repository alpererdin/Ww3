using Managers;

namespace Stages
{
    public class StageTypeOne : MainStage
    {
        protected override void Awake()
        {
            stageID = GetInstanceID();
        }
    }
}