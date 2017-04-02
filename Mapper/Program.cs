﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace Mapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			try
			{
				Application.EnableVisualStyles();
				Application.Run(new Mapper.MainForm());
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message, "Unexpected error");
			}
		}
    }
}