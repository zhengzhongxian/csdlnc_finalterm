using PointManagement_Application.DTOs;
using PointManagement_Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointManagement_Application
{
    public partial class FormSeeDetailStudentMenuStrip : Form
    {
        private StudentDTO student;
        private FormMain_Manager _parentform;
        private FormMainStudent FormMainStudent;
        public FormSeeDetailStudentMenuStrip(StudentDTO student, FormMain_Manager _parentform, FormMainStudent formMainStudent)
        {
            InitializeComponent();
            this.student = student;
            this._parentform = _parentform;
            FormMainStudent = formMainStudent;
        }

        private void Bsee_details_Click(object sender, EventArgs e)
        {
            var formstudentdetails = new FormStudentDetails(student, _parentform, FormMainStudent);
            _parentform.ShowFormInPanel(formstudentdetails);
            this.Close();
        }

        private async void Binfo_Click(object sender, EventArgs e)
        {
            try
            {
                var metadata = await ApiHelper.GetAsync<Auditable>($"Student/metadata?auditable_id={student.AuditableId}");

                string message = $"Created At: {metadata.created_at:yyyy-MM-dd HH:mm:ss}\n" +
                                 $"Created By: {metadata.created_by}\n" +
                                 $"{(metadata.updated_at != null ? $"Updated At: {metadata.updated_at:yyyy-MM-dd HH:mm:ss}\n" : "")}" +
                                 $"{(!string.IsNullOrEmpty(metadata.updated_by) ? $"Updated By: {metadata.updated_by}\n" : "")}" +
                                 $"{(metadata.deleted_at != null ? $"Deleted At: {metadata.deleted_at:yyyy-MM-dd HH:mm:ss}\n" : "")}" +
                                 $"{(!string.IsNullOrEmpty(metadata.deleted_by) ? $"Deleted By: {metadata.deleted_by}\n" : "")}" +
                                 $"{(metadata.transfered_at != null ? $"Transfered At: {metadata.transfered_at:yyyy-MM-dd HH:mm:ss}\n" : "")}" +
                                 $"{(!string.IsNullOrEmpty(metadata.transfered_by) ? $"Transfered By: {metadata.transfered_by}\n" : "")}" +
                                 $"{(metadata.restored_at != null ? $"Restored At: {metadata.restored_at:yyyy-MM-dd HH:mm:ss}\n" : "")}" +
                                 $"{(!string.IsNullOrEmpty(metadata.restored_by) ? $"Restored By: {metadata.restored_by}\n" : "")}";

                MessageBox.Show(_parentform, message, "Metadata Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy metadata: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
