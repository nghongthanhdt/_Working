using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace PHCN.ThuNoiBo.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");        
            bool result;
            var mutex = new System.Threading.Mutex(true, "UniqueAppId", out result);
            if (!result)
            {
                MessageBox.Show("Chương trình đang chạy ở khay hệ thống!");                
                Process.GetCurrentProcess().Kill();
                return;
            }
            //GC.KeepAlive(mutex);
            Application.Run(new FormClient());            
        }
        
    }

}
