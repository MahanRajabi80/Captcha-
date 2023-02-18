using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Speech.Synthesis;

namespace Captcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string _captcha;
       private void RefreshCaptcha()
        {
            Random rnd = new Random();
            string number= rnd.Next(10000, 99999).ToString();
            CaptchaImage Captcha = new CaptchaImage(number, 100, 39);
            pbxCaptcha.Image = Captcha.Image;
            _captcha = Captcha.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }
       private void SpeekCaptcha()
        {
            SpeechSynthesizer Speech = new SpeechSynthesizer();
            Speech.Volume = 100;
            foreach (Char objChar in _captcha.ToCharArray())
                Speech.Speak(objChar.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpeekCaptcha();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text == _captcha)
                MessageBox.Show("پاسخ صحیح است", "بررسی", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("پاسخ صحیح نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
