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
            //if the page isn't posted back, check the url for an id to see know add or edit
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a url parameter if the count is > 0 so populate the form
                    GetStudent();
                }
            }
        }

        protected void GetStudent()
        {
            //connect
            using (ContosoEntities conn = new ContosoEntities())
            {
                //get id from url parameter and store in a variable
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                var s = (from stu in conn.Students
                         where stu.StudentID == StudentID
                         select stu).FirstOrDefault();

                //populate the form from our department object
                txtFirstName.Text = s.FirstMidName;
                txtLastName.Text = s.LastName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (ContosoEntities conn = new ContosoEntities())
            {
                //instantiate a new deparment object in memory
                Student s = new Student();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    s = (from stu in conn.Students
                         where stu.StudentID == StudentID
                         select stu).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                s.FirstMidName = txtFirstName.Text;
                s.LastName = txtLastName.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Students.Add(s);
                }
                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("students.aspx");
            }
        }
    }
}