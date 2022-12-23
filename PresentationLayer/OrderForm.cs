using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer;
using DataAccessLayer;
using Entities.Enum;
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

namespace PresentationLayer
{
    public partial class OrderForm : Form
    {
        IOrderManager orderManager;
        int id;
        Orders orders;
        public OrderForm(int id, Orders orders)
        {
            InitializeComponent();
            orderManager = new OrderManager(new DBOrder());
            this.id = id;
            this.orders = orders;
        }

        private void btnSaveButton_Click(object sender, EventArgs e)
        {
            DeliveryStatus deliveryStatus = Enum.Parse<DeliveryStatus>(cbOrderStatus.Text);
            Order order = orderManager.GetOrder(id);

            orderManager.UpgradeOrder(deliveryStatus, id);
            orders.UpdataData(100);
            this.Close();
        }
    }
}
