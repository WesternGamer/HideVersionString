using Sandbox;
using Sandbox.Game.Screens;
using Sandbox.Graphics.GUI;
using SpaceEngineers.Game.GUI;
using System;
using VRage;

namespace HideVersionString
{
    // Some code from SEWorldGenPlugin was used.
    public class MyCustomMainMenu : MyGuiScreenMainMenu
    {
        private MyGuiControlElementGroup m_elemtents;

        public MyCustomMainMenu() : this(false)
        {

        }

        public MyCustomMainMenu(bool pauseGame) : base(pauseGame)
        {
            m_pauseGame = pauseGame;
        }

        public override void RecreateControls(bool constructor)
        {
            base.RecreateControls(constructor);
                m_elemtents = new MyGuiControlElementGroup();
                m_elemtents.HighlightChanged += OnHighlightChange;
                MyGuiControlButton button = null;
                foreach (var c in Controls)
                {
                    if (c is MyGuiControlButton)
                    {
                        m_elemtents.Add(c);
                        if (((MyGuiControlButton)c).Text == MyTexts.GetString(MyCommonTexts.ScreenMenuButtonOptions))
                            button = (MyGuiControlButton)c;
                    }
                }
                if (button != null)
                {
                    int index = Controls.IndexOf(button);
                    MyGuiControlButton optionsButton = MakeButton(button.Position, MyCommonTexts.ScreenMenuButtonOptions, OnOptionsClick);
                    Controls.Add(optionsButton);
                    m_elemtents.Add(optionsButton);
                    optionsButton.Name = button.Name;
                    Controls[index] = optionsButton;
                    optionsButton.SetToolTip(button.Tooltips);
                }
           
        }

        private void OnHighlightChange(MyGuiControlElementGroup obj)
        {
            foreach (var c in m_elemtents)
            {
                if (c.HasFocus && m_elemtents.SelectedIndex != obj.SelectedIndex)
                {
                    FocusedControl = c;
                    break;
                }
            }
        }

        private void OnOptionsClick(object sender)
        {
            RunWithTutorialCheck(delegate
            {
                MyGuiSandbox.AddScreen(new MyCustomOptionsMenu());
            });
        }

        private void RunWithTutorialCheck(Action afterTutorial)
        {
            if (MySandboxGame.Config.FirstTimeTutorials)
            {
                MyGuiSandbox.AddScreen(new MyGuiScreenTutorialsScreen(afterTutorial));
            }
            else
            {
                afterTutorial();
            }
        }
    }
}
