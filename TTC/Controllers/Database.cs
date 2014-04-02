using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace TTC.Controllers.Database
{
        public class Member
        {
            public MySqlConnection conn = null;
            public readonly String ID;
            public string FirstName;
            public string LastName;
            public string FullName;
            public string Email;
            public string PhoneNumber;
            public string ShirtSize;
            public string StudentID;
            public bool WantsShirt;

            public String SaveID;
            private string oldFirstName;
            private string oldLastName;
            private string oldFullName;
            private string oldEmail;
            private string oldPhoneNumber;
            private string oldShirtSize;
            private string oldStudentID;
            private bool oldWantsShirt;

            public Member(MySqlConnection conn) { this.conn = conn; }

            public Member(MySqlConnection conn, int id)
            {
                this.conn = conn;
                if (id <= 0)
                {
                    throw new Exception("ID has to be nonzero positive number");
                }
                try
                {
                    conn.Open();
                    String query = "Select * From Members Where ID = " + id;
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        ID = dataReader["id"] + "";
                        FirstName = dataReader["FirstName"] + "";
                        oldFirstName = FirstName;
                        LastName = dataReader["LastName"] + "";
                        oldLastName = LastName;
                        FullName = FirstName + " " + LastName;
                        Email = dataReader["Email"] + "";
                        oldEmail = Email;
                        StudentID = dataReader["StudentID"] + "";
                        oldStudentID = StudentID;
                        PhoneNumber = dataReader["PhoneNumber"] + "";
                        oldPhoneNumber = PhoneNumber;
                        WantsShirt = !String.IsNullOrEmpty(dataReader["ShirtSize"] + "");
                        oldWantsShirt = WantsShirt;
                        ShirtSize = dataReader["ShirtSize"] + "";
                        oldShirtSize = ShirtSize;
                    }

                    //close Data Reader
                    dataReader.Close();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            
            }

            public bool Save(){
                try
                {
                    if (ID == null)
                    {
                        this.Insert();
                        return true;
                    }
                    else
                    {
                        this.Update();
                        return true;
                    }
                }catch(Exception e){
                    throw new Exception(e.Message);
                }
                
            }

            private void Insert()
            {
                string column = "";
                string value = "";

                if (!String.IsNullOrEmpty(FirstName))
                {
                    column += ", " + "FirstName";
                    value += ", '" + FirstName + "'";
                }

                if (!String.IsNullOrEmpty(LastName))
                {
                    column += ", " + "LastName";
                    value += ", '" + LastName + "'";
                }
                if (!String.IsNullOrEmpty(Email))
                {
                    column += ", " + "Email";
                    value += ", '" + Email + "'";
                }
                if (!String.IsNullOrEmpty(PhoneNumber))
                {
                    column += ", " + "PhoneNumber";
                    value += ", '" + PhoneNumber + "'";
                }
                if (!String.IsNullOrEmpty(StudentID))
                {
                    column += ", " + "StudentID";
                    value += ", '" + StudentID + "'";
                }
                if(!String.IsNullOrEmpty(ShirtSize)){
                    column += ", " + "ShirtSize";
                    value += ", '" + ShirtSize + "'";
                }
                //cut the front off of the string for the comma's
                value = value.Substring(2, value.Length - 2);
                column = column.Substring(2, column.Length - 2);


                string query = "INSERT INTO Members (" + column + ") VALUES(" + value + ")";

                //open connection
                conn.Open();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                conn.Close();
                    
            }

            //Update statement
            public void Update()
            {


                string set = "";

                if (FirstName != oldFirstName)
                {
                    set += ", FirstName='" + FirstName +"'";
                }
                if (LastName != oldLastName)
                {
                    set += ", LastName='" + LastName + "'";
                }
                if (Email != oldEmail)
                {
                    set += ", Email='" + Email + "'";
                }
                if (PhoneNumber != oldPhoneNumber)
                {
                    set += ", PhoneNumber='" + PhoneNumber + "'";
                }
                if (StudentID != oldStudentID)
                {
                    set += ", StudentID='" + StudentID + "'";
                }
                if (ShirtSize != oldShirtSize)
                {
                    set += ", ShirtSize='" + ShirtSize + "'";
                }

                set = set.Substring(2, set.Length - 2);
                string query = "UPDATE Members SET " + set + " WHERE ID = '"+ ID +"'";

                //Open connection
                conn.Open();
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = conn;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    conn.Close();
                }

            //Delete statement
            public void Delete()
            {
                string query = "DELETE FROM Members WHERE ID='" + ID + "'";

               conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

    }
}