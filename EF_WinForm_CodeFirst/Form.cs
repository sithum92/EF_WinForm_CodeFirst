using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_WinForm_CodeFirst
{
    public partial class Form : MetroFramework.Forms.MetroForm
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            using (ModelContext Db = new ModelContext())
            {
                employeeBindingSource.DataSource = Db.EmpList.ToList();
            }

            Employee obj = employeeBindingSource.Current as Employee;
           
          
                if (obj.ImageURL != null)
                {
                    pbDisplay.Image = Image.FromFile(obj.ImageURL);
                }

           
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbDisplay.Image = Image.FromFile(ofd.FileName);
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        obj.ImageURL = ofd.FileName;
                    }
                }
            }
        }

        private void employeeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pbDisplay.Image = null;
            panelMain.Enabled = true;
            employeeBindingSource.Add(new Employee());
            employeeBindingSource.MoveLast();
            txtName.Focus();
            
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj.ImageURL != null)
            {
                pbDisplay.Image = Image.FromFile(obj.ImageURL);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (ModelContext Db = new ModelContext())
            {
                Employee obj = employeeBindingSource.Current as Employee;
                if (obj != null)
                {

                    if (Db.Entry<Employee>(obj).State == EntityState.Detached)
                        Db.Set<Employee>().Attach(obj);
                    if (obj.EmpID == 0)
                        Db.Entry<Employee>(obj).State = EntityState.Added;
                    else
                        Db.Entry<Employee>(obj).State = EntityState.Modified;
                    Db.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Saved Successfully");
                    Form_Load(sender, e);

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are You Sure Want To Delete This Record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
            {
                using (ModelContext Db = new ModelContext())
                {
                    Employee obj = employeeBindingSource.Current as Employee;

                    if (obj != null)
                    {
                        if (Db.Entry<Employee>(obj).State == EntityState.Detached)
                            Db.Set<Employee>().Attach(obj);
                        Db.Entry<Employee>(obj).State = EntityState.Detached;
                        Db.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Deleted Successfully");
                        employeeBindingSource.RemoveCurrent();
                        Form_Load(sender, e);
                    }
                }
            
            }
        }
    }
}
