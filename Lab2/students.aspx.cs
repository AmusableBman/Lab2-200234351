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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {

            //connect using our connection string from web.config and EF context class
            using (ContosoEntities conn = new ContosoEntities())
            {
                
                var studs = from s in conn.Students select s;

                grdStudents.DataSource = studs.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //connect
            using (ContosoEntities conn = new ContosoEntities())
            {
                
                Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

                var s = (from stu in conn.Students where stu.StudentID == StudentID select stu).FirstOrDefault();

                conn.Students.Remove(s);
                conn.SaveChanges();
                GetStudents();
            }
        }
    }
}
