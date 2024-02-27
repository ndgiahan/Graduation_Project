using Fahasa.DAO;
using Fahasa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fahasa
{
    public partial class frmInformation : Form
    {
        public frmInformation()
        {
            InitializeComponent();
            addDataComboboxBranch();
            addDataComboboxPositon();
        }
        Connect data = new Connect();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();
        public class Branch
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public int AreaId { get; set; }
            public Branch() { }
            public Branch(int id, string name, string address, string phoneNumber, int areaId)
            {
                Id = id;
                Name = name;
                Address = address;
                PhoneNumber = phoneNumber;
                AreaId = areaId;
            }
        }
        private void addDataComboboxBranch()
        {
            string str = @"select [id], [name],[address],[phoneNumber],[areaId]  from Branch";
            List<Branch> listBranch = new List<Branch>();
            var dtBranch = data.ExcuteQuery(str);
            listBranch = (from DataRow dr in dtBranch.Rows
                          select new Branch
                          {
                              Id = Convert.ToInt32(dr["id"]),
                              Name = dr["name"].ToString(),
                              Address = dr["address"].ToString(),
                              PhoneNumber = dr["phoneNumber"].ToString(),
                              AreaId = Convert.ToInt32(dr["areaId"]),
                          })
                                .ToList();
            this.cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.DataSource = listBranch;
            cmbBranch.DisplayMember = "Name";
            cmbBranch.ValueMember = "Id";
        }
        public class Position
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Position() { }
            public Position(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        private void addDataComboboxPositon()
        {
            string str = @"select [id], [name] from Position";
            List<Position> listPosition = new List<Position>();
            var dtPosition = data.ExcuteQuery(str);
            listPosition = (from DataRow dr in dtPosition.Rows
                            select new Position
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Name = dr["name"].ToString(),
                            })
                                .ToList();
            this.cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.DataSource = listPosition;
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "Id";
        }
        private void btnConfim_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string password = txtPass.Text.Trim();
                Branch selectedBranch = (Branch)cmbBranch.SelectedItem;
                Position selectedPosition = (Position)cmbPosition.SelectedItem;

                if (name == "") throw new Exception();
                string query = @"select [name], [UserName], [Password], [PositionId], [BranchId]  from Employee";
                var dtEmployee = data.ExcuteQuery(query);
                var listEmployee = (from DataRow dr in dtEmployee.Rows
                                    select new Employee
                                    {
                                        Name = dr["name"].ToString(),
                                        Username = dr["UserName"].ToString(),
                                        Password = dr["Password"].ToString(),
                                        PositionId = (int)dr["PositionId"],
                                        BranchId = (int)dr["BranchId"]
                                    }).ToList();
                var employee = listEmployee.Where(p => p.Username.Equals(name)
                            && p.Password.Equals(password)
                            && p.PositionId == selectedPosition.Id
                            && p.BranchId == selectedBranch.Id).FirstOrDefault();

                StaffInformation staff = new StaffInformation
                {
                    Username = employee.Username,
                    Name = employee.Name,
                    BranchId = selectedBranch.Id,
                    BranchName = selectedBranch.Name,
                    PositionId = selectedPosition.Id,
                    PositionName = selectedPosition.Name,

                };
                string path = Utils.getPath();
                if (Utils.IsFullInformation(staff))
                {
                    Utils.SaveInformation(path, staff);
                    this.Hide();
                    frmMain main = new frmMain();
                    main.Show();
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Thông tin đăng nhập không chính xác!";
            }
        }

        private void frmInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
