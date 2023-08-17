using Launcher;
using System;


namespace Launcher
{


    public partial class App : System.Windows.Application
    {
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            this.StartupUri = new System.Uri("Init.xaml", System.UriKind.Relative);
        }
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static void Main()
        {
            Launcher.App app = new Launcher.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}

