using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lab2.Models;
using System.Web.ModelBinding;
namespace Lab2
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    GetStudent();
                }
            }
        }

        protected void GetStudent()
        {
            //connect
            using (ContosoEntities conn = new ContosoEntities())
            {
                
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                var s = (from stu in conn.Students where stu.StudentID == StudentID select stu).FirstOrDefault();

                txtFirstName.Text = s.FirstMidName;
                txtLastName.Text = s.LastName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (ContosoEntities conn = new ContosoEntities())
            {
                
                Student s = new Student();

                
                if (Request.QueryString.Count > 0)
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    s = (from stu in conn.Students where stu.StudentID == StudentID select stu).FirstOrDefault();
                }

                s.FirstMidName = txtFirstName.Text;
                s.LastName = txtLastName.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Students.Add(s);
                }
                conn.SaveChanges();
                
                Response.Redirect("students.aspx");
            }
        }
    }
}
