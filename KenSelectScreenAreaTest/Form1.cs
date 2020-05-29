using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenSmithConsulting.KenSelectScreenAreaBase;

namespace KenSmithConsulting.KenSelectScreenAreaTest
{
    public partial class Form1 : Form
    {
        public Rectangle SelectedArea { get; set; }
        public bool SelectionCancelled { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectionCancelled = true;
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            TransparentForm transparentForm = new TransparentForm();
            DialogResult result = transparentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                SelectionCancelled = transparentForm.SelectionCancelled;
                SelectedArea = transparentForm.SelectedArea;
            }
            TextBoxSelectionCancelled.Text = SelectionCancelled ? "true" : "false";
            TextBoxCoordX.Text = SelectedArea.X.ToString();
            TextBoxCoordY.Text = SelectedArea.Y.ToString();
            TextBoxWidth.Text = SelectedArea.Width.ToString();
            TextBoxHeight.Text = SelectedArea.Height.ToString();

        }
    }
}
