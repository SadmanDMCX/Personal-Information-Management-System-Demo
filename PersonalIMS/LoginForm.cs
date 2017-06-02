using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseConnectionLib;
using ns1;

namespace PersonalIMS
{
    public partial class LoginForm : Form
    {

        // Variable 
        private BunifuDragControl drag = new BunifuDragControl();
        private Timer currentTime = new Timer();
        private bool isFound = false;

        private bool isDeletePanal = false;
        private bool isRegisterPanal = false;
        private bool isLoginPanal = false;
        private bool isFoundNowDelete = false;
        

        public static int GetCurrentIDFromLogin = 0;
        public static LoginForm instance;
        // Variable End 

        // Method
        private void tickAtEverySec(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            DateTimeLabel.Text = hh + " : "  + mm + " : " + ss;
        }

        // Method End 

        public LoginForm()
        {
            InitializeComponent();

            currentTime.Interval = 1000;
            currentTime.Tick += tickAtEverySec;
            currentTime.Start();

            Height = 243;
        }


        private void CrossBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DragPanelR_MouseDown(object sender, MouseEventArgs e)
        {
            drag.Grab(this);
        }

        private void DragPanelR_MouseUp(object sender, MouseEventArgs e)
        {
            drag.Release();
        }

        private void DragPanelR_MouseMove(object sender, MouseEventArgs e)
        {
            drag.Drag();
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!UsernameTextBox.Text.Equals(""))
            {
                UsernameTextBox.ForeColor = Color.Black;
            }
            if (UsernameTextBox.Text.Equals(""))
            {
                UsernameTextBox.Text = "Username";
                UsernameTextBox.ForeColor = Color.DimGray;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!PasswordTextBox.Text.Equals(""))
            {
                PasswordTextBox.ForeColor = Color.Black;
                PasswordTextBox.PasswordChar = '*';
            }
            if (PasswordTextBox.Text.Equals(""))
            {
                PasswordTextBox.PasswordChar = char.Parse("\0");
                PasswordTextBox.Text = "Password";
                PasswordTextBox.ForeColor = Color.DimGray;
            }
            
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drag.Grab(this);
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            drag.Drag();
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag.Release();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (RegisterPanel.Visible == false)
            {
                RegisterPanel.Visible = true;
                LoginPanel.Visible = false;
                DeletePanel.Visible = false;
                DropDownTimer.Enabled = true;
                isLoginPanal = false;
                isRegisterPanal = true;
                isDeletePanal = false;
            }
            else
            {

                // Register
                var cmd = new SqlCommand { Connection = DBConnectionLib.GetDatabseConnection() };
                SqlQueryClassMain.SetSqlInsertIntoTheDatabase(RegNameTextBox.Text, RegSpcialistTextBox.Text, RegUsernameTextBox.Text, RegUniversityNameTextBox.Text, RegPasswordTextBox.Text, RegUIDTextBox.Text, RegEmailTextBox.Text, RegFacebookIDTextBox.Text, RegPhoneTextBox.Text, RegEducationTextBox.Text, RegAddressTextBox.Text, RegDateOfBirthTextBox.Text, RegAboutTextBox.Text);
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    cmd.CommandText = SqlQueryClassMain.GetSqlInsertIntoTheDatabase();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Successfully Inserted.", "Insert", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            if (LoginPanel.Visible == false)
            {
                LoginPanel.Visible = true;
                RegisterPanel.Visible = false;
                DeletePanel.Visible = false;
                DropDownTimer.Enabled = true;
                isLoginPanal = true;
                isRegisterPanal = false;
                isDeletePanal = false;
            }
            else
            {
                var cmd = new SqlCommand {Connection = DBConnectionLib.GetDatabseConnection()};
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    cmd.CommandText = SqlQueryClassMain.sqlGetAllUsernamePassword;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (
                            UsernameTextBox.Text == dataReader["p_login_user"].ToString() &&
                            PasswordTextBox.Text == dataReader["p_login_password"].ToString()
                        )
                        {
                            GetCurrentIDFromLogin = Int32.Parse(dataReader["p_id"].ToString());
                            isFound = true;
                            MainWindow window = new MainWindow();
                            window.Show();
                            Hide();
                        }
                    }
                    if (!isFound)
                    {
                        MessageBox.Show("Username And Password doesn't match.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (DeletePanel.Visible == false)
            {
                LoginPanel.Visible = false;
                RegisterPanel.Visible = false;
                DeletePanel.Visible = true;
                DropDownTimer.Enabled = true;
                isLoginPanal = false;
                isRegisterPanal = false;
                isDeletePanal = true;
            }
            else
            {
                var cmd = new SqlCommand { Connection = DBConnectionLib.GetDatabseConnection() };
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    cmd.CommandText = SqlQueryClassMain.sqlGetAllUsernamePassword;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (
                            DeleteUsernameTextBox.Text == dataReader["p_login_user"].ToString() &&
                            DeletePasswordTextBox.Text == dataReader["p_login_password"].ToString()
                        )
                        {
                            GetCurrentIDFromLogin = Int32.Parse(dataReader["p_id"].ToString());
                            isFoundNowDelete = true;
                        }
                    }
                }

                if (!isFoundNowDelete)
                {
                    MessageBox.Show("Username And Password doesn't match.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                if (isFoundNowDelete)
                {
                    SqlCommand del = new SqlCommand() {Connection = DBConnectionLib.GetDatabseConnection()};
                    SqlQueryClassMain.SetSqlDeleteAllById(Convert.ToString(GetCurrentIDFromLogin));

                    using (del)
                    {
                            del.Connection.Open();
                            del.CommandText = SqlQueryClassMain.GetSqlDeleteAllById();
                            del.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully Deleted the User.", "Delete", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    isFoundNowDelete = false;
                }
            }
        }

        private void DropDownTimer_Tick(object sender, EventArgs e)
        {
            if (isRegisterPanal)
            {

                if (Height >= 520)
                {
                    DropDownTimer.Enabled = false;
                }
                else
                {
                    Height += 10;
                }

            }

            if (isLoginPanal)
            {
                if (Height <= 243)
                {
                    DropDownTimer.Enabled = false;
                }
                else
                {
                    Height -= 10;
                }
            }

            if (isDeletePanal)
            {
                if (Height <= 243)
                {
                    DropDownTimer.Enabled = false;
                }
                else
                {
                    Height -= 10;
                }
            }

        }

        
    }
}
