using Sandbox.Engine.Networking;
using Sandbox.Game;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace HideVersionString
{
    internal class BuildInfoControl : MyGuiControlBase
    {
        private static string m_buildString = string.Empty;

        public BuildInfoControl() : base()
        {
            m_buildString = $"Version {MyFinalBuildConstants.APP_VERSION_STRING_DOTS} | Branch: {MyGameService.BranchName}\n" +
                            $"Client Build {MyPerGameSettings.BasicGameInfo.ClientBuildNumber} | Server Build {MyPerGameSettings.BasicGameInfo.ServerBuildNumber}";
        }

        public override void Draw(float transitionAlpha, float backgroundTransitionAlpha)
        {
            base.Draw(transitionAlpha, backgroundTransitionAlpha);
            var normalizedCoord = MyGuiManager.ComputeFullscreenGuiCoordinate(MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_BOTTOM, 8, 8);
            var stringSize = MyGuiManager.MeasureString("BuildInfo", m_buildString, 0.6f);
            MyGuiManager.DrawRectangle(normalizedCoord + new Vector2(-0.005f, -stringSize.Y - 0.005f), stringSize + new Vector2(0.01f, 0.01f), new Color(0.106f, 0.157f, 0.22f, transitionAlpha - 0.5f));
            MyGuiManager.DrawString("BuildInfo", m_buildString, normalizedCoord, 0.6f, new Color(MyGuiConstants.LABEL_TEXT_COLOR * transitionAlpha, 0.6f), MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_BOTTOM);
        }
    }
}
