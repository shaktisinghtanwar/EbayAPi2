using EbaySdkLib;
using EbaySdkLib.Messages;
using EbaySdkLib.Models;
using EbaySdkLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbaySelling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
            SqlConnectionStringBuilder cstr = new SqlConnectionStringBuilder();
            cstr.DataSource = "DESKTOP-4SQEA0V\\SQLEXPRESS2012";
            cstr.InitialCatalog = "Ebay_Api";
            cstr.IntegratedSecurity = true;
            cstr.TrustServerCertificate = true;
            //cstr.IntegratedSecurity = false;
            //cstr.UserID = "";
            //cstr.Password = "";
            // SellingTools_Lib.Account.MintAccessToken(cstr, "");
           
            try
            {
                //SellingTools_Lib.Account.GetFulfillmentPolicies(cstr, "EBAY_GB");
                SellingTools_Lib.Account.GetPaymentPolicies(cstr, "EBAY_GB");
            }
            catch(Exception er)
            {

            }
        }



    }
}
