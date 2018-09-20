using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHibernateHbmToFluent.WinForm;

namespace NHibernateHbmToFluent
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            var parameters = args
                .Select(a => a.Split('='))
                .ToDictionary(a => a[0].Substring(1), a => a[1]);

            string Param(string key)
                => parameters.ContainsKey(key) ? parameters[key] : string.Empty;

			Application.Run(new MainForm(Param("hbmDirectory"), Param("mapDirectory"), Param("nameSpace")));
		}
	}
}