using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Button_spawn
{
    public partial class ButtonSpawn : Form
    {
        List<Button> buttons;

        public ButtonSpawn()
        {
            InitializeComponent();

            buttons = new List<Button>();
        }

        private void UserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
           
        }

        private void UserInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(UserInput.Text) && Convert.ToInt32(UserInput.Text) <= 50)
            {
                MakeBtnList(Convert.ToInt32(UserInput.Text));

                this.Size = new Size(335, 100 + (buttons[0].Size.Height) *(Convert.ToInt32(Math.Ceiling(Convert.ToDouble(UserInput.Text) / 3))));

                for (int i = 0; i < buttons.Count; i++)
                    this.Controls.Add(buttons[i]);

                e.Handled = true;
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            var button = sender as Button;

            MessageBox.Show("You have clicked " + button.Name);
        }

        void MakeBtnList(int input)
        {
            int btnWidth = 100;
            int btnHight = 55;
            int widthOffset = 10;

            if (input > buttons.Count)
            {
                for (int i = buttons.Count(); i < input; i++)
                {
                    Button b = new Button
                    {
                        Size = new Size(btnWidth, btnHight),
                        Name = "Button " + (i + 1),
                        Text = "Button " + (i + 1),
                        Location = new Point((btnWidth * (i % 3)) + widthOffset, btnHight + btnHight * Convert.ToInt32(Math.Floor(i / 3.0)))
                    };

                    b.Click += (s,e)=>{ MessageBox.Show(((Button)s).Text); };

                    buttons.Add(b);
                }
            }
            else if (input < buttons.Count)
            {
                for(int i = buttons.Count - 1; i > input - 1; i--)
                {
                    Controls.Remove(buttons[i]);
                    buttons.RemoveAt(buttons.Count - 1);
                }
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
