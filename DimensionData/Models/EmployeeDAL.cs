using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using DimensionData.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

namespace DimensionData.Models
{
    public class EmployeeDAL
    {
        string connectionString = "Data Source=LAPTOP-KAY\\SQLEXPRESS; Initial Catalog=DatasetDimension;Persist Security Info=FalseI;User ID=sa, Password=123;";

        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            List<EmployeeInfo> empList = new List<EmployeeInfo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo();
                    emp.ID = Convert.ToInt32(dr["ID"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Company = dr["Company"].ToString();
                    emp.Department = dr["Department"].ToString();

                    empList.Add(emp);
                }
                con.Close();
            }
            return empList;
            //Get All from employee ends here
        }
       
        public void AddEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Company", emp.Company);
                cmd.Parameters.AddWithValue("@Department", emp.Department);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //INSERTS ENDS

        public void UpdateEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", emp.ID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Company", emp.Company);
                cmd.Parameters.AddWithValue("@Department", emp.Department);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Update Ends Here

        public void DeleteEmployee(int? empId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", empId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Delete Ends Here

        public EmployeeInfo GetEmployeeById(int? empId)
        {
            EmployeeInfo emp = new EmployeeInfo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", empId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo();
                    emp.ID = Convert.ToInt32(dr["ID"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Company = dr["Company"].ToString();
                    emp.Department = dr["Department"].ToString();
                }
                con.Close();
            }
            return emp;
            //Get ends
        }
    }
}
