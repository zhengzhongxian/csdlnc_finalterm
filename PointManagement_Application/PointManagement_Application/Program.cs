using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Flogin());
            //Application.Run(new FormMain_Manager());
            //Application.Run(new FormMainStudent());
            //Application.Run(new FormAddStudent());
            //Application.Run(new FormAddExam());
            //Application.Run(new Flogin());
            //Application.Run(new FormAddSchedule());
            //Application.Run(new FormSeat("sdsd","sdsdsd"));
            //Application.Run(new FormMainClass());
            //Application.Run(new FormAddClass());
        }
    }
}
