using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PersonalIMS
{
    class SqlQueryClassMain
    {

        private static string sqlGetAllById = "";
        internal static void SetSqlGetAllById(string key)
        {
            sqlGetAllById = "Select * from person_datatable where p_id = '" + key + "'";
        }
        internal static string GetSqlGetAllById()
        {
            return sqlGetAllById;
        }

        public static string sqlGetAllUsernamePassword 
            = "Select p_id, p_login_user, p_login_password from person_datatable";


        private static string sqlDeleteAllById = "";
        internal static void SetSqlDeleteAllById(string key)
        {
            sqlDeleteAllById = "Delete from person_datatable where p_id = '" + key + "'";
        }
        internal static string GetSqlDeleteAllById()
        {
            return sqlDeleteAllById;
        }

        private static string sqlInsertIntoTheDatabase = "";
        internal static void SetSqlInsertIntoTheDatabase(string RegNameTextBox, string RegSpcialistTextBox, 
            string RegUsernameTextBox, string RegUniversityNameTextBox, string RegPasswordTextBox, string RegUIDTextBox, string RegEmailTextBox, string RegFacebookIDTextBox, string RegPhoneTextBox, string RegEducationTextBox, string RegAddressTextBox, string RegDateOfBirthTextBox, string RegAboutTextBox
            )
        {
            sqlInsertIntoTheDatabase = "Insert into person_datatable " +
                                       "(p_name, p_spcialist, p_email, p_phoneno, p_address, p_dob, p_uname, p_uid, p_fb, p_edu, p_about, p_login_user, p_login_password) values (" +
                                       "'" + RegNameTextBox + "', '" + RegSpcialistTextBox + "', '" + RegEmailTextBox + "', '" + RegPhoneTextBox + "', '" + RegAddressTextBox + "', '" + RegDateOfBirthTextBox + "', '" + RegUniversityNameTextBox + "', '" + RegUIDTextBox + "', '" + RegFacebookIDTextBox + "', '" + RegEducationTextBox + "', '" + RegAboutTextBox + "', '" + RegUsernameTextBox + "', '" + RegPasswordTextBox + "'"
                                       + ")";
        }
        internal static string GetSqlInsertIntoTheDatabase()
        {
            return sqlInsertIntoTheDatabase;
        }

        public static string sqlGetUsernameFromDatabase = "Select p_login_user from person_datatable";

        private static string sqlUpdate_Name = "";
        internal static void SetSqlUpdate_Name(string RegNameTextBox, string key)
        {
            sqlUpdate_Name = "Update person_datatable set " +
                                       "p_name = " + "'" + RegNameTextBox + "'" + 
                                       " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_Name()
        {
            return sqlUpdate_Name;
        }

        private static string sqlUpdate_Spc = "";
        internal static void SetSqlUpdate_Spc(string RegSpcialistTextBox,string key)
        {
            sqlUpdate_Spc = "Update person_datatable set " +
                            "p_spcialist = " + "'" + RegSpcialistTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_Spc()
        {
            return sqlUpdate_Spc;
        }

        private static string sqlUpdate_Email = "";
        internal static void SetSqlUpdate_Email(string RegEmailTextBox, string key)
        {
            sqlUpdate_Email = "Update person_datatable set " +
                             "p_email = " + "'" + RegEmailTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_Email()
        {
            return sqlUpdate_Email;
        }

        private static string sqlUpdate_PN = "";
        internal static void SetSqlUpdate_PN(string RegPhoneTextBox, string key)
        {
            sqlUpdate_PN = "Update person_datatable set " +
                             "p_phoneno = " + "'" + RegPhoneTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_PN()
        {
            return sqlUpdate_PN;
        }

        private static string sqlUpdate_Add = "";
        internal static void SetSqlUpdate_Add(string RegAddressTextBox, string key)
        {
            sqlUpdate_Add = "Update person_datatable set " +
                             "p_address = " + "'" + RegAddressTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_Add()
        {
            return sqlUpdate_Add;
        }

        private static string sqlUpdate_dob = "";
        internal static void SetSqlUpdate_Dob(string RegDateOfBirthTextBox, string key)
        {
            sqlUpdate_dob = "Update person_datatable set " +
                             "p_dob = " + "'" + RegDateOfBirthTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_Dob()
        {
            return sqlUpdate_dob;
        }

        private static string sqlUpdate_UN = "";
        internal static void SetSqlUpdate_UN(string RegUniversityNameTextBox, string key
        )
        {
            sqlUpdate_UN = "Update person_datatable set " +
                             "p_uname= " + "'" + RegUniversityNameTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_UN()
        {
            return sqlUpdate_UN;
        }

        private static string sqlUpdate_UID = "";
        internal static void SetSqlUpdate_UID(string RegUIDTextBox,string key
        )
        {
            sqlUpdate_UID = "Update person_datatable set " +
                             "p_uid = " + "'" + RegUIDTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_UID()
        {
            return sqlUpdate_UID;
        }

        private static string sqlUpdate_FB = "";
        internal static void SetSqlUpdate_FB(string RegFacebookIDTextBox, string key)
        {
            sqlUpdate_FB = "Update person_datatable set " +
                             "p_fb = " + "'" + RegFacebookIDTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_FB()
        {
            return sqlUpdate_FB;
        }

        private static string sqlUpdate_Edu = "";
        internal static void SetSqlUpdate_Edu(string RegEducationTextBox, string key)
        {
            sqlUpdate_Edu = "Update person_datatable set " +
                             "p_edu = " + "'" + RegEducationTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_Edu()
        {
            return sqlUpdate_Edu;
        }
        private static string sqlUpdate_About = "";
        internal static void SetSqlUpdate_About(string RegAboutTextBox, string key)
        {
            sqlUpdate_About = "Update person_datatable set " +
                                       "p_about = " + "'" + RegAboutTextBox + "'" +
                                       " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_About()
        {
            return sqlUpdate_About;
        }

        private static string sqlUpdate_User = "";
        internal static void SetSqlUpdate_User(string RegUsernameTextBox, string key
        )
        {
            sqlUpdate_User = "Update person_datatable set " +
                                       "p_login_user = " + "'" + RegUsernameTextBox + "'" +
                                       " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_User()
        {
            return sqlUpdate_User;
        }

        private static string sqlUpdate_Pass = "";
        internal static void SetSqlUpdate_Pass(string RegPasswordTextBox, string key)
        {
            sqlUpdate_Pass = "Update person_datatable set " +
                             "p_login_password = " + "'" + RegPasswordTextBox + "'" +
                             " where p_id = " + key + "";
        }
        internal static string GetSqlUpdate_Pass()
        {
            return sqlUpdate_Pass;
        }



    }
}
