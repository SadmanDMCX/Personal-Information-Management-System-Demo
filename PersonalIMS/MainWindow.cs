using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseConnectionLib;
using ns1;
using PersonalIMS.Properties;

namespace PersonalIMS
{
    public partial class MainWindow : Form
    {
        // Variables
        private BunifuDragControl drag = new BunifuDragControl();

        private bool isDown = true;
        private bool isEdit = false;
        private bool isUserNameNotExist = true;
        private bool isOneUpdate = false;

        private int getCurrentId = LoginForm.GetCurrentIDFromLogin;

        private string StrUsername, StrPassword;
        // Variables End

        // Method 
        private void LoadData()
        {
            SqlQueryClassMain.SetSqlGetAllById(getCurrentId.ToString());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBConnectionLib.GetDatabseConnection();
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                cmd.CommandText = SqlQueryClassMain.GetSqlGetAllById();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PersonNameLabel.Text = reader["p_name"].ToString();
                    PersonSpeacilistLabel.Text = reader["p_spcialist"].ToString();
                    emailLabel.Text = reader["p_email"].ToString();
                    universityNameLabel.Text = reader["p_uname"].ToString();
                    uidLabel.Text = reader["p_uid"].ToString();
                    dobLabel.Text = reader["p_dob"].ToString();
                    eduLabel.Text = reader["p_edu"].ToString();
                    phoneLabel.Text = reader["p_phoneno"].ToString();
                    addressLabel.Text = reader["p_address"].ToString();
                    fbLabel.Text = reader["p_fb"].ToString();
                    infoLabel.Text = reader["p_about"].ToString();

                    StrUsername = reader["p_login_user"].ToString();
                    StrPassword = reader["p_login_password"].ToString();
                }
            }

        }
        // Method End 


        public MainWindow()
        {
            InitializeComponent();

            LoadData();

        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drag.Grab(this);
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag.Release();
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            drag.Drag();
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            underLineSeparator.Width = AboutLabel.Width;
            underLineSeparator.Left = AboutLabel.Left;

            AboutPanel.Visible = true;
            TaskPanel.Visible = false;
            NotePanel.Visible = false;
        }

        private void TaskLabel_Click(object sender, EventArgs e)
        {
            underLineSeparator.Width = GallaryLabel.Width;
            underLineSeparator.Left = GallaryLabel.Left;

            AboutPanel.Visible = false;
            NotePanel.Visible = false;
            TaskPanel.Visible = true;

            if (!isDown)
            {
                DropDownTimer.Enabled = true;
                if (this.Height <= 550)
                {
                    DropDownTimer.Enabled = false;
                    isDown = !isDown;
                }
                else
                    this.Height -= 10;
            }
        }

        private void NotesLabel_Click(object sender, EventArgs e)
        {
            underLineSeparator.Width = NotesLabel.Width;
            underLineSeparator.Left = NotesLabel.Left;

            AboutPanel.Visible = false;
            TaskPanel.Visible = false;
            NotePanel.Visible = true;

            if (!isDown)
            {
                DropDownTimer.Enabled = true;
                if (this.Height <= 550)
                {
                    DropDownTimer.Enabled = false;
                    isDown = !isDown;
                }
                else
                    this.Height -= 10;
            }
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            Dispose();
            LoginForm log = new LoginForm();
            log.Show();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DropDownBtn_Click(object sender, EventArgs e)
        {
            DropDownTimer.Enabled = true;
        }

        private void DropDownTimer_Tick(object sender, EventArgs e)
        {
            if (isDown)
            {
                if (this.Height >= 650)
                {
                    DropDownTimer.Enabled = false;
                    isDown = !isDown;
                }
                else
                    this.Height += 10;
            }
            else
            {
                if (this.Height <= 550)
                {
                    DropDownTimer.Enabled = false;
                    isDown = !isDown;
                }
                else
                    this.Height -= 10;
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (!isDown)
            {
                DropDownTimer.Enabled = true;
                if (this.Height <= 550)
                {
                    DropDownTimer.Enabled = false;
                    isDown = !isDown;
                }
                else
                    this.Height -= 10;
            }

            if (!isEdit)
            {
                EditPanel.Visible = true;
                isEdit = !isEdit;
            }
            else
            {
                if (!UsernameTextBox.Text.Equals(""))
                {
                    
                    SqlCommand cmdVerify = new SqlCommand() { Connection = DBConnectionLib.GetDatabseConnection()};
                    cmdVerify.CommandText = SqlQueryClassMain.sqlGetUsernameFromDatabase;
                    using (cmdVerify) 
                    {
                        cmdVerify.Connection.Open();
                        var reader = cmdVerify.ExecuteReader();
                        while (reader.Read())
                        {
                            if (UsernameTextBox.Text == reader["p_login_user"].ToString())
                            {
                                MessageBox.Show("Change Username, Username should be unique.", "Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isUserNameNotExist = false;
                            }
                        }
                    }
                }


                if (isUserNameNotExist)
                {
                    EditPanel.Visible = false;
                    isEdit = !isEdit;

                    SqlCommand cmd = new SqlCommand() { Connection = DBConnectionLib.GetDatabseConnection() };

                    if (!UsernameTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_User(UsernameTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_User();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        UsernameTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!NameTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_Name(NameTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_Name();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        NameTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!SpcialityTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_Spc(SpcialityTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_Spc();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        SpcialityTextBox.Text = "";
                        isOneUpdate = true;
                        cmd.Connection.Close();
                    }

                    if (!PhoneNoTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_PN(PhoneNoTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_PN();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        PhoneNoTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!AddressTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_Add(AddressTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_Add();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        AddressTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!DateOfBirthTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_Dob(DateOfBirthTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_Dob();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        DateOfBirthTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!UniversityNameTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_UN(UniversityNameTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_UN();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        UniversityNameTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!UIDTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_UID(UIDTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_UID();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        UIDTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!FacebookIDTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_FB(FacebookIDTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_FB();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        FacebookIDTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!EducationTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_Edu(EducationTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_Edu();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        EducationTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!EmailTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_Email(EmailTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_Email();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        EmailTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!PasswordTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_Pass(PasswordTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_Pass();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        PasswordTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    if (!AboutTextBox.Text.Equals(""))
                    {
                        SqlQueryClassMain.SetSqlUpdate_About(AboutTextBox.Text, getCurrentId.ToString());
                        cmd.CommandText = SqlQueryClassMain.GetSqlUpdate_About();
                        using (cmd)
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        AboutTextBox.Text = "";
                        isOneUpdate = true;
                    }

                    LoadData();

                    if (isOneUpdate)
                    {
                        MessageBox.Show("Successfully Updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isOneUpdate = false;
                    }
                    
                }

            }
        }
        
    }
}
