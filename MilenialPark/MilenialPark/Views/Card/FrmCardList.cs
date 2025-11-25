using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilenialPark.Controller;
using MilenialPark.Master;
using MilenialPark.Views;

namespace MilenialPark.Views.Card
{
    public partial class FrmCardList : Form
    {
        public BindingSource bind = new BindingSource();
        public ControllerCard card = new ControllerCard();

        public FrmCardList()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCardList_Load(object sender, EventArgs e)
        {
            cbxCategory.SelectedIndex = 0;
            bind.DataSource = card.getCardListActive();
            dgvSelectCard.DataSource = bind;
            dgvSelectCard.Columns["CardID"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bind.Filter = cbxCategory.Text + " like '%" + txtSearch.Text + "%'";
        }

        private void btnEditShopItem_Click(object sender, EventArgs e)
        {
            if (dgvSelectCard.Rows.Count != 0)
            {
                ClsStaticVariable.CardID = dgvSelectCard.CurrentRow.Cells["CardID"].Value.ToString();
            }
            this.Close();
        }

        private void dgvSelectCard_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditShopItem_Click(null, null);
        }
    }
}
