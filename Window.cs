using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Game_Center
{
    public partial class Window : Form
    {
        string gamesPath;
        Timer searchTimer;

        public Window()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            searchTimer = new Timer();
            searchTimer.Interval = 200; 
            searchTimer.Tick += SearchTimer_Tick; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPaths();
        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void panelGames_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddGameB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Game Files (*.exe;*.url;*.bat)|*.exe;*.url;*.bat";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string selectedExePath in openFileDialog.FileNames)
                    {
                        SavePaths(selectedExePath);
                        CreateGameItem(selectedExePath);
                    }
                }
            }
        }

        private void SetFolderB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gamesPath) || !Directory.Exists(gamesPath))
            {
                MessageBox.Show("Please select a games folder first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> selectedFolders = SelectFoldersWithOpenFileDialog();
            if (selectedFolders.Count > 0)
            {
                foreach (string folderPath in selectedFolders)
                {
                    MoveFolderToGamePath(folderPath);
                }
            }
        }

        private void SelectFolderB_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                gamesPath = dialog.FileName;
                GamesPathTb.Text = gamesPath;
                SavePaths();
            }
        }

        private void GamesPathTb_TextChanged(object sender, EventArgs e)
        {
            gamesPath = GamesPathTb.Text;
            SavePaths();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop(); 
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            string searchText = SearchBox.Text.Trim().ToLower();

            panelGames.SuspendLayout();

            foreach (Control control in panelGames.Controls)
            {
                if (control is Panel containerPanel)
                {
                    TextBox gameLabel = containerPanel.Controls.OfType<TextBox>().FirstOrDefault();

                    if (gameLabel != null)
                    {
                        string gameName = gameLabel.Text.ToLower();
                        containerPanel.Visible = gameName.Contains(searchText);
                    }
                }
            }

            panelGames.ResumeLayout(); 
        }
    

        private void CreateGameItem(string exePath, string gameName = null)
        {
            Button newButton = new Button();
            TextBox newTextBox = new TextBox();
            Button deleteButton = new Button();

            // Button
            Icon exeIcon = Icon.ExtractAssociatedIcon(exePath);
            newButton.BackColor = Color.Transparent;
            newButton.BackgroundImage = exeIcon.ToBitmap();
            newButton.BackgroundImageLayout = ImageLayout.Stretch;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.FlatAppearance.BorderSize = 0;
            newButton.Size = new Size(80, 80);
            newButton.Tag = exePath;
            newButton.Click += new EventHandler(OpenExe);

            // Name 
            if (gameName == null) gameName = Path.GetFileNameWithoutExtension(exePath);
            newTextBox.BackColor = SystemColors.ActiveCaption;
            newTextBox.BorderStyle = BorderStyle.None;
            newTextBox.Text = gameName;
            newTextBox.Font = new Font("Malgun Gothic", 12);
            newTextBox.AutoSize = true;
            newTextBox.Size = new Size(100, 100);
            newTextBox.ForeColor = Color.WhiteSmoke;
            newTextBox.Tag = exePath;
            newTextBox.TextChanged += new EventHandler(GameNameBoxUpdate);

            // Delete Button
            deleteButton.BackColor = Color.Transparent;
            deleteButton.BackgroundImage = Properties.Resources.trash; 
            deleteButton.BackgroundImageLayout = ImageLayout.Zoom;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Size = new Size(18, 18);
            deleteButton.Tag = exePath; 
            deleteButton.Click += new EventHandler(RemoveGameItem); 

            // Panel
            Panel containerPanel = new Panel();
            containerPanel.Size = new Size(120, 120);
            containerPanel.BorderStyle = BorderStyle.None;

            // Adding
            containerPanel.Controls.Add(deleteButton);
            containerPanel.Controls.Add(newButton);
            containerPanel.Controls.Add(newTextBox);

            // Positions
            newButton.Top = 0;
            newButton.Left = (containerPanel.Width - newButton.Width + 35) / 2;

            newTextBox.Top = newButton.Bottom + 5;
            newTextBox.Left = (containerPanel.Width - newTextBox.Width + 35) / 2;

            deleteButton.Top = newButton.Bottom - 17;
            deleteButton.Left = newButton.Right - 17;
            panelGames.Controls.Add(containerPanel);
        }
        private void RemoveGameItem(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string exePath = deleteButton.Tag.ToString();

            foreach (Control control in panelGames.Controls)
            {
                if (control is Panel containerPanel)
                {
                    foreach (Control innerControl in containerPanel.Controls)
                    {
                        if (innerControl is Button button && button.Tag.ToString() == exePath)
                        {
                            panelGames.Controls.Remove(containerPanel);
                            containerPanel.Dispose(); 

                            RemovePath(exePath);
                            return;
                        }
                    }
                }
            }
        }
        private void GameNameBoxUpdate(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string newName = textBox.Text;
                UpdateGameName((string)textBox.Tag, newName);
            }
        }

        private void OpenExe(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string exePath = clickedButton.Tag.ToString();
            try
            {
                Process.Start(exePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open the game file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SavePaths(string exePath = null)
        {
            string filePath = "saved.txt";
            List<string> lines = new List<string>();

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath).ToList();
            }

            string gamesPathLine = $"GamesPath: {gamesPath}";
            if (lines.Count > 0 && lines[0].StartsWith("GamesPath:"))
            {
                lines[0] = gamesPathLine; 
            }
            else
            {
                lines.Insert(0, gamesPathLine); 
            }

            if (!string.IsNullOrEmpty(exePath) && !lines.Any(line => line.StartsWith(exePath + " |")))
            {
                string gameName = Path.GetFileNameWithoutExtension(exePath);
                lines.Add($"{exePath} | {gameName}");
            }

            File.WriteAllLines(filePath, lines);
        }
        private void RemovePath(string exePath)
        {
            if (File.Exists("saved.txt"))
            {
                string[] exePaths = File.ReadAllLines("saved.txt");

                var updatedExePaths = exePaths.Where(line => !line.StartsWith(exePath + " |")).ToArray();

                File.WriteAllLines("saved.txt", updatedExePaths);
            }
        }
        private void LoadPaths()
        {
            string filePath = "saved.txt";
            List<string> validExePaths = new List<string>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0 && lines[0].StartsWith("GamesPath:"))
                {
                    gamesPath = lines[0].Replace("GamesPath: ", "");
                    GamesPathTb.Text = gamesPath;
                    validExePaths.Add(lines[0]);
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];

                    string[] parts = line.Split(new string[] { " | " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        string exePath = parts[0];
                        string gameName = parts[1];

                        if (File.Exists(exePath))
                        {
                            CreateGameItem(exePath, gameName);
                            validExePaths.Add(line);
                        }
                    }
                }

                File.WriteAllLines(filePath, validExePaths);
            }
        }
        private void UpdateGameName(string exePath, string newName)
        {
            if (File.Exists("saved.txt"))
            {
                List<string> lines = File.ReadAllLines("saved.txt").ToList();

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].StartsWith(exePath + " |"))
                    {
                        lines[i] = exePath + " | " + newName;
                        break;
                    }
                }

                File.WriteAllLines("saved.txt", lines);
            }
        }
        private void MoveFolderToGamePath(string sourcePath)
        {
            string fileName = Path.GetFileName(sourcePath);
            string destinationPath = Path.Combine(gamesPath, fileName);

            try
            {
                if (Directory.Exists(destinationPath))
                {
                    Directory.Delete(destinationPath); 
                }

                Directory.Move(sourcePath, destinationPath); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error :c : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> SelectFoldersWithOpenFileDialog()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:";
            dialog.IsFolderPicker = true;
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return dialog.FileNames.ToList(); 
            }

            return new List<string>();
        }
    }
}
