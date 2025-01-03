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
    public partial class FormExamDetail : Form
    {
        private string examId;
        private string subjectName;
        private string roomName;
        private string invigilatorName;
        private FormMainExams parentForm;
        private readonly FormMain_Manager _parentForm;
        public FormExamDetail(string examId, string subjectName, string roomName, string invigilatorName
            , FormMainExams parentForm, FormMain_Manager _parentForm)
        {
            InitializeComponent();
            this.examId = examId;
            this.subjectName = subjectName;
            this.roomName = roomName;
            this.invigilatorName = invigilatorName;
            this.parentForm = parentForm;
            this._parentForm = _parentForm;
        }

        private void Bsee_details_Click(object sender, EventArgs e)
        {
            FormMainDetailExam detailForm = new FormMainDetailExam(examId, subjectName, roomName, invigilatorName, _parentForm, parentForm, subjectName);
            _parentForm.ShowFormInPanel(detailForm);

            parentForm.Hide();

            this.Close();
        }
    }
}
