using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI;

namespace AF.DataAccessor.Sample
{
    public partial class DataAccessorDemo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["employee"] = null;
                BindEmployeeGrid();
            }

            lblMessage.Text = String.Empty;
        }

        private void BindEmployeeGrid()
        {
            List<DataAccessorEntity> empList;
            if (Session["employee"] == null)
            {
                var data = new DataAccessorDemoDAL();
                empList = data.GetEmployeeList();
                Session["employee"] = empList;
            }
            else
                empList = Session["employee"] as List<DataAccessorEntity>;

            Employee.DataSource = empList;
            Employee.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var employeeEntity = new DataAccessorEntity();
            employeeEntity.EmpID = Guid.NewGuid();
            employeeEntity.Name = txtName.Text;
            employeeEntity.Address = txtAddress.Text;
            employeeEntity.Phone = txtPhone.Text;
            employeeEntity.EMail = txtEMail.Text;

            try
            {
                var data = new DataAccessorDemoDAL();
                var result = data.AddEmployee(employeeEntity);
                Session["employee"] = null;
                BindEmployeeGrid();

                if (result.IsValid)
                {
                    lblMessage.ForeColor = Color.Black;
                    txtName.Text = String.Empty;
                    txtAddress.Text = String.Empty;
                    txtPhone.Text = String.Empty;
                    txtEMail.Text = String.Empty;
                    lblMessage.Text = "Record added successfuly";
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    foreach (var msg in result.Message)
                        lblMessage.Text = msg + "<br/>";
                }
            }
            catch (Exception ex)
            {
                //Log Error
            }
        }


        protected void Employee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Employee.PageIndex = e.NewPageIndex;
            BindEmployeeGrid();
        }

        protected void Employee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var employeeID = new Guid(e.Keys[0].ToString());

            var data = new DataAccessorDemoDAL();
            data.DeleteEmployee(employeeID);

            Session["employee"] = null;
            BindEmployeeGrid();
        }

        protected void Employee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var employeeID = new Guid(e.Keys[0].ToString());
            TextBox Address = (TextBox)Employee.Rows[e.RowIndex].FindControl("txtAddress");
            TextBox EMail = (TextBox)Employee.Rows[e.RowIndex].FindControl("txtEMail");
            TextBox Phone = (TextBox)Employee.Rows[e.RowIndex].FindControl("txtPhone");

            var emp = new DataAccessorEntity { EmpID = employeeID, Address = Address.Text, EMail = EMail.Text, Phone = Phone.Text };

            var data = new DataAccessorDemoDAL();
            var result = data.UpdateEmployee(emp);

            Employee.EditIndex = -1;
            Session["employee"] = null;
            BindEmployeeGrid();
        }

        protected void Employee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Employee.EditIndex = e.NewEditIndex;
            Session["employee"] = null;
            BindEmployeeGrid();
        }

        protected void Employee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Employee.EditIndex = -1;
            Session["employee"] = null;
            BindEmployeeGrid();
        }
    }
}