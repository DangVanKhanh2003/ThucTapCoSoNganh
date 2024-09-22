﻿using QuanLyNhanVienTTCSN_Nhom9.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVienTTCSN_Nhom9.View
{
    public partial class ThemNhanVien : Form
    {
        private string typeAcc = "";
        public ThemNhanVien(string typeAccount)
        {
            InitializeComponent();
            this.typeAcc = typeAccount; 
        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            ManageForm mana = new ManageForm();
            DataTable tblPosition = mana.loadTablePosition(typeAcc);
            List<string> items = new List<string>();
            foreach (DataRow row in tblPosition.Rows)
            {
                items.Add(row[0].ToString()); // Convert to string if it's not already
            }

            // Set the ComboBox's DataSource to the list
            positionComboBox.DataSource = items;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ManageForm Mana = new ManageForm();
            DateTime dateBirth = (DateTime)dateOfBirth.Value;
            DateTime dateJoin = (DateTime)dateJoinCompany.Value;
            if(phoneNumberTextBox.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại tối đa là 11 ký tự.");
                return;
            }
            if (fullNameTextBox.Text.Length > 40)
            {
                MessageBox.Show("Họ tên tối đa là 40 ký tự.");
                return;
            }
            if (addressTextBox.Text.Length > 300)
            {
                MessageBox.Show("Địa chỉ tối đa là 300 ký tự.");
                return;
            }
            if (identificationCardTextBox.Text.Length > 15)
            {
                MessageBox.Show("Căn cước công dân tối đa là 15 ký tự.");
                return;
            }
            if (mailTextBox.Text.Length > 100)
            {
                MessageBox.Show("Email tối đa là 100 ký tự.");
                return;
            }
            if (long.TryParse(phoneNumberTextBox.Text.ToString(), out long intValue) &&
                long.TryParse(identificationCardTextBox.Text.ToString(), out long intValue2))
            {
                Mana.addEmployee(typeAcc, fullNameTextBox.Text.ToString(), addressTextBox.Text.ToString(), phoneNumberTextBox.Text.ToString(),
                identificationCardTextBox.Text.ToString(), mailTextBox.Text.ToString(), dateBirth.Year + "-" + dateBirth.Month + "-" +
                dateBirth.Day, dateJoin.Year + "-" + dateJoin.Month + "-" + dateJoin.Day, genderCombobox.Text.ToString(),
                positionComboBox.Text.ToString());
            }
            else
            {
                MessageBox.Show("Bạn nhập không đúng định dạng. Hãy kiểm tra lại số điện thoại hoặc căn cước công dân.");
            }
            this.Close();
        }

        private void genderCombobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void positionComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }
    }
}
