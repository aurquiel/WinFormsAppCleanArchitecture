using ApplicationBusiness;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppCleanArchitecture
{
    public partial class FormNewEditBeer : Form
    {
        private readonly IRepository<Brand> _repository;
        private readonly AddBeer _addBeer;
        private readonly EditBeer _editBeer;

        private Beer _beer;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Beer Beer
        {
            set { _beer = value; }
        }

        public FormNewEditBeer(IRepository<Brand> repository, AddBeer addBeer, EditBeer editBeer)
        {
            InitializeComponent();
            _repository = repository;
            _addBeer = addBeer;
            _editBeer = editBeer;
        }

        private async void FormNewEditBeer_Load(object sender, EventArgs e)
        {
            await ChargeData();

            if(_beer != null)
            {
                SetInfo();
            }
        }

        private async Task ChargeData()
        {
            cboBrand.DataSource = await _repository.GetAllAsync();
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";

            if (cboBrand.Items.Count > 0)
            {
                cboBrand.SelectedIndex = 0;
            }
        }

        private void txtAlcohol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            var textBox = (sender as TextBox);

            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(_beer == null)
                {
                    await Add();
                }
                else
                {
                    await Edit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task Add()
        {
            string name = txtName.Text.Trim();
            int idBrnad = int.Parse(cboBrand.SelectedValue.ToString());
            decimal alcohol = decimal.Parse(txtAlcohol.Text.Trim());

            await _addBeer.ExecuteAsync(new Beer()
            {
                Name = name,
                BrandId = idBrnad,
                Alcohol = alcohol,
            });

            this.Close();
        }

        private async Task Edit()
        {
            string name = txtName.Text.Trim();
            int idBrnad = int.Parse(cboBrand.SelectedValue.ToString());
            decimal alcohol = decimal.Parse(txtAlcohol.Text.Trim());

            await _editBeer.ExecuteAsync(new Beer()
            {
                Id = _beer.Id,
                Name = name,
                BrandId = idBrnad,
                Alcohol = alcohol,
            });

            this.Close();
        }

        public void SetInfo()
        {
            Text = "Editar cerveza";
            txtName.Text = _beer.Name;
            cboBrand.SelectedValue = _beer.BrandId;
            txtAlcohol.Text = _beer.Alcohol.ToString(); 
        }
    }
}
