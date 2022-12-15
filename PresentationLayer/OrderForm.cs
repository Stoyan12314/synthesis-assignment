using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Entities.Enum;

namespace PresentationLayer
{
    public partial class OrderForm : Form
    {
        IOrderManager orderManager;
        int id;
        public OrderForm(int id)
        {
            InitializeComponent();
            orderManager = new OrderManager(new DBOrder());
            this.id = id;
        }

        private void btnSaveButton_Click(object sender, EventArgs e)
        {
            DeliveryStatus deliveryStatus = Enum.Parse<DeliveryStatus>(cbOrderStatus.Text);
            Order order =  orderManager.GetOrder(id);

            orderManager.UpgradeOrder(deliveryStatus, id);
            this.Close();
        }
    }
}
