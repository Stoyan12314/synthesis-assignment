using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using Entities;
namespace PresentationLayer
{
    public partial class Orders : Form
    {
        IOrderManager orderManager;
        public Orders()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewOrders.Rows[index];
            int id = (int)selectedRow.Cells[0].Value;
            OrderForm form = new OrderForm(id, this);
            form.ShowDialog();
          //  ItemForm newForm = new ItemForm(id, this);
          //  newForm.ShowDialog();
        }
        public void UpdataData(int limit)
        {
            
            orderManager = new OrderManager(new DBOrder());
            dataGridViewOrders.Rows.Clear();
            foreach (Order order in orderManager.GetOrders(limit))
            {
                dataGridViewOrders.Rows.Add(order.OrderId, order.OrderDate, order.DeliveryOption, order.DeliveryDate, order.DeliveryStatus);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int limit = Convert.ToInt32(tbLimit.Text);
            UpdataData(limit);
        }
    }
}
