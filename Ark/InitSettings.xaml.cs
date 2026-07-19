using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using WinForms = System.Windows.Forms;
namespace Ark
{
    /// <summary>
    /// Lógica de interacción para InitSettings.xaml
    /// </summary>
    public partial class InitSettings : Window
    {
        public string pathFolder;
        public InitSettings()
        {
            InitializeComponent();
            ShowDialog();
        }

        private void FolderPathButton_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result.Equals(WinForms.DialogResult.OK))
            {
                this.pathFolder = folderDialog.SelectedPath;
                if (Utils.Utils.isHeekValidatedDirectory(this.pathFolder))
                {
                    this.pathFolderLabel.Text = this.pathFolder;
                }
                else
                {
                    WinForms.MessageBox.Show($"This is not a {Utils.ConstantsGlobals.FOLDER_NAME} Folder!");
                }
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.pathFolder != null)
            {
                this.Close();
            }
            else
            {
                WinForms.MessageBox.Show("Path cant be empty!");
            }
        }
    }
}
