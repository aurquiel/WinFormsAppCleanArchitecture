﻿using ApplicationBusiness;
using Entities;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppCleanArchitecture
{
    public partial class FormBrand : Form
    {
        private IRepository<Brand> _repository;
        private readonly IServiceProvider _serviceProvider;

        public FormBrand(IRepository<Brand> repository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        private async Task Refresh()
        {
            var brands = await _repository.GetAllAsync();
            dgv.DataSource = brands;
        }

        private async void FormBrand_Load(object sender, EventArgs e)
        {
            await Refresh();
            AddColumns();
        }

        private void AddColumns()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditButton";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "Editar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.DefaultCellStyle.BackColor = Color.LightGray;
            dgv.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.Red;
            dgv.Columns.Add(deleteButtonColumn);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormNewEditBrand>();
            frm.ShowDialog();
            await Refresh();
        }

        private async void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "EditButton")
            {
                var frm = _serviceProvider.GetRequiredService<FormNewEditBrand>();
                var brand = await _repository.GetByIdAsync(id);
                frm.SetInfo(brand);
                frm.ShowDialog();
                await Refresh();
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                var confirmresult = MessageBox.Show("Estas seguro de elimnar?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmresult == DialogResult.Yes)
                {
                    await _repository.DeleteAsync(id);
                    await Refresh();
                }
            }
        }
    }
}
