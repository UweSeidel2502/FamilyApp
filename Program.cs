using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilyApp.Classes;
using System.Resources;
namespace FamilyApp
{
    public static class Program
    {
        public static frmMain fMain;
        public static FamilyApp.Repositories.Registry.DBRegistry DBReg;
        public static USSoft.Data.TProjectClass cPRO = new USSoft.Data.TProjectClass();
        public static clsAppData AppData = new clsAppData();
        public static clsMain cMain = new clsMain();
        public static string AssemblyName = "FamilyApp";

        
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += GeneralErrorHandler;
            Application.ThreadException += GeneralThreadHandler;

            FamilyAppApplication.SetConnectionString();

            Application.Run(new frmMain());
        }
        private static void GeneralErrorHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                Exception ex = (Exception)e.ExceptionObject;
                ErrorException(ex, ex.Source.ToString(), "");
            }
            else
            {
                if (!(cPRO == null))
                {
                    Exception ex = (Exception)e.ExceptionObject;
                    cPRO.ErrorException(ex, "");
                }
                else
                {
                    MessageBox.Show(FamilyApp.Properties.Resources.CriticalError, FamilyApp.Properties.Resources.ErrorString);
                }

                Environment.Exit(0);
            }
        }

        private static void GeneralThreadHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ErrorException(e.Exception, e.Exception.Source.ToString(), "");
        }
        /// <summary>
        /// Zentrale Fehlerbehandlung
        /// </summary>
        public static void ErrorException(Exception ex, string source, string className, string additionalText = "")
        {

            if (!(cPRO == null))
            {
                cPRO.ErrorException(ex, ex.TargetSite.Name, ex.TargetSite.DeclaringType.Name, additionalText);
            }
            else
            {
                MessageBox.Show(ex.ToString(), FamilyApp.Properties.Resources.UnexpectedError);
            }

            if (FamilyAppApplication.DataFactory.ChangeTracker.HasChanges())
            {
                foreach (var entry in FamilyAppApplication.DataFactory.ChangeTracker.Entries().Where(e =>  e.State == EntityState.Added || e.State == EntityState.Modified))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.State = EntityState.Detached;
                    }
                    else
                    {
                        entry.State = EntityState.Unchanged;
                    }
                }
            }
        }

        public static bool HasFormInstance(string sFormName, bool bBringToFront)
        {
            bool HasFormInstanceRet = default;

            int i;
            Form f;

            HasFormInstanceRet = false;

            var loopTo = fMain.MdiChildren.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                f = (Form)fMain.MdiChildren[i];
                if (f.Name == sFormName)
                {
                    if (bBringToFront)
                        f.BringToFront();
                    return true;
                }
            }

            return HasFormInstanceRet;

        }
        public static bool HasFormInstance(string sFormName)
        {
            return HasFormInstance(sFormName, false);
        }
        public static Form GetFormInstance(string sFormName)
        {
            Form GetFormInstanceRet = default;

            GetFormInstanceRet = default;
            for (int i = 0, loopTo = fMain.MdiChildren.Length - 1; i <= loopTo; i++)
            {
                if (fMain.MdiChildren[i].Name == sFormName)
                {
                    return fMain.MdiChildren[i];
                }
            }

            return GetFormInstanceRet;

        }
    }

    public static class StringExtensions
    {

        public static int ToInteger(this string value)
        {
            int testValue;

            if (int.TryParse(value, out testValue))
            {
                return testValue;
            }

            return 0;
        }


        public static decimal ToDecimal(this string value)
        {
            decimal testValue;

            if (decimal.TryParse(value, out testValue))
            {
                return testValue;
            }

            return 0m;
        }

        public static double ToDouble(this string value)
        {
            double testValue;

            if (double.TryParse(value, out testValue))
            {
                return testValue;
            }

            return 0d;
        }

        public static Guid ToGuid(this string value)
        {
            try
            {
                return new Guid(value);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static int ToInteger(this bool value)
        {
            if (!value)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static string SetFilterEndQuote(this string value)
        {
            if (!value.EndsWith("%"))
            {
                return value + "%";
            }
            else
            {
                return value;
            }
        }
    }
}
