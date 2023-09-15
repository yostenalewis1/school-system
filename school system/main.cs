using DevExpress.XtraBars;
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

namespace school_system
{
  
    public partial class main : DevExpress.XtraBars.Ribbon.RibbonForm
    {  int lid;
        int gid;
        public main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void load()
        {
            dgv.AutoResizeColumns();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                Clsdata cls = new Clsdata();
                cls.selectstudents("selectstudents");
                dgv.DataSource = cls.dt;
            }
            catch (Exception)
            {
                clssetting.cn.Close();
                MessageBox.Show("خطأ في تحميل البيانات ");
            }

        }




        private void loadgrade()
        {
            dgv2.AutoResizeColumns();
            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                Clsdata cls = new Clsdata();
                cls.selectstudents("selectgrade");
                dgv2.DataSource = cls.dt;
            }
            catch (Exception)
            {
                clssetting.cn.Close();
                MessageBox.Show("خطأ في تحميل البيانات ");
            }

        }






        private void loadteacher()
        {
            dgv.AutoResizeColumns();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                Clsdata cls = new Clsdata();
                cls.selectstudents ("selectteacher");
                dgv3.DataSource = cls.dt;
            }
            catch (Exception)
            {
                clssetting.cn.Close();
                MessageBox.Show(" خطأ في تحميل بيانات المعلم  "); 
                
            }

        }







        private void main_Load(object sender, EventArgs e)
        {
            load();
            loadgrade();
            loadteacher();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            try
            {
                Clsdata cls = new Clsdata();
                string name = txtname.Text;
                string ph = txtph.Text;
                int gid = Convert.ToInt32(dgv2.CurrentRow.Cells[0].Value);
                cls.insertstudents(name, ph, gid);
                load();
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية الاضافة");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);


                if (MessageBox.Show("عملية حذف", "هل تريد تاكيد عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Clsdata cls = new Clsdata();
                    cls.deletestudents(id);
                    load();

                }
                else
                {
                    MessageBox.Show("عملية حذف", "تم الغاء عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطاء اثناء عملية الحذف");
            }

        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtname.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                txtph.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                lid = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                simpleButton2.Enabled = true;
                simpleButton1.Enabled = false;
                simpleButton3.Enabled = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           try {
                Clsdata cls = new Clsdata();
                string name = txtname.Text;
                string ph = txtph.Text;
                int gid = Convert.ToInt32(dgv2.CurrentRow.Cells[0].Value);
            
                cls.updatestudents(name, ph, lid, gid);
                load();
                simpleButton3.Enabled = false;
                simpleButton1.Enabled = true;
                simpleButton2.Enabled = true;
                txtname.Clear();
                txtph.Clear();
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية التعديل");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string sql = "select * from T_students where name like '%" + textBox1.Text + "%'";
                SqlDataAdapter data = new SqlDataAdapter(sql, clssetting.cn);
                DataSet ds = new DataSet();
                clssetting.cn.Open();
                data.Fill(ds, "au");
                clssetting.cn.Close();
                dgv.AutoResizeColumns();
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.DataSource = ds;
                dgv.DataMember = "au";
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية البحث");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Clsdata cls = new Clsdata();
                string grade = txtgrade.Text;
                cls.insertgrade(grade);
                loadgrade();
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية الاضافة");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(dgv2.CurrentRow.Cells[0].Value);


                if (MessageBox.Show("عملية حذف", "هل تريد تاكيد عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Clsdata cls = new Clsdata();
                    cls.deletegrade(id);
                    loadgrade();

                }
                else
                {
                    MessageBox.Show("عملية حذف", "تم الغاء عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطاء اثناء عملية الحذف");
            }
        }




        private void dgv2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtgrade.Text = dgv2.CurrentRow.Cells[1].Value.ToString();
                gid = Convert.ToInt32(dgv2.CurrentRow.Cells[0].Value);
                simpleButton4.Enabled = false;
                simpleButton6.Enabled = false;
                simpleButton5.Enabled = true;
            }


        }


        private void simpleButton5_Click(object sender, EventArgs e)
        { 
            try
            {
                Clsdata cls = new Clsdata();
                string grade = txtgrade.Text;
                cls.updategrade(grade,gid);
                simpleButton6.Enabled = false;
                simpleButton5.Enabled = true;
                simpleButton4.Enabled = true;
                loadgrade();
                txtgrade.Clear();
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية التعديل");
            }



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string sql = "select * from T_grade where grade like '%" + textBox4.Text + "%'";
                SqlDataAdapter data = new SqlDataAdapter(sql, clssetting.cn);
                DataSet ds = new DataSet();
                clssetting.cn.Open();
                data.Fill(ds, "au");
                clssetting.cn.Close();
                dgv2.AutoResizeColumns();
                dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv2.DataSource = ds;
                dgv2.DataMember = "au";
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية البحث");
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            int gid = Convert.ToInt32(dgv.CurrentRow.Cells[3].Value);
            string gname;
            for (int i = 0 ; i < dgv2.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgv2.Rows[i].Cells[0].Value) == gid) 
                {
                   // dgv2.Rows[i].Selected = true;
                    MessageBox.Show(dgv2.Rows[i].Cells[1].Value.ToString());
                    break;
                }

            }
        }

        private void sm1_Click(object sender, EventArgs e)
        {

            try
            {
                Clsdata cls = new Clsdata();
                string name = txttname.Text;
                string ph = txttph.Text;
                if (name.Length < 4 || ph.Length != 11)
                {
                    MessageBox.Show("خطأ");
                }
                else
                {
                    cls.insertteacher(name, ph);
                    loadteacher();
                    txttph.Clear();
                    txttname.Clear();
                }
            }

            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية الاضافة");
            }
        }

        private void txttph_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttph_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(sm1.Enabled==true)
            {
                  sm1.PerformClick();
            }
            }
            
        }

        private void sm3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgv3.CurrentRow.Cells[0].Value);


                if (MessageBox.Show("عملية حذف", "هل تريد تاكيد عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Clsdata cls = new Clsdata();
                    cls.deleteteacher(id);
                    loadteacher();


                }
                else
                {
                    MessageBox.Show("عملية حذف", "تم الغاء عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطاء اثناء عملية الحذف");
            }







        }

        private void sm2_KeyDown(object sender, KeyEventArgs e)
        {
           

        }

        private void dgv3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txttname.Text = dgv3.CurrentRow.Cells[1].Value.ToString();
                txttph.Text = dgv3.CurrentRow.Cells[2].Value.ToString();
                lid = Convert.ToInt32(dgv3.CurrentRow.Cells[0].Value);
                sm1.Enabled = false;
                sm3.Enabled = false;
                sm2.Enabled = true;
            }
        }

        private void sm2_Click(object sender, EventArgs e)
        {
            try
            {
                Clsdata cls = new Clsdata();
                string name = txttname.Text;
                string ph = txttph.Text;
                int lid = Convert.ToInt32(dgv3.CurrentRow.Cells[0].Value);

                cls.updateteacher(name, ph,lid);
                loadteacher();
                sm2.Enabled = false;
                sm1.Enabled = true;
               sm3.Enabled = true;
                txttname.Clear();
                txttph.Clear();
            }
            catch (Exception)
            {

                clssetting.cn.Close();
                MessageBox.Show("خطا اثناء عملية التعديل");
            }
        }
    }
}

