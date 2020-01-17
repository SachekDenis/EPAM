using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    [Table(Name = "Session results")]
    public class GroupsSessionResults
    {
        [Column(Name = "Group name")]
        public string GroupName{get;set;}

        [Column(Name = "Student fullname")]
        public string StudentFullName {get;set;}

        [Column(Name = "Session start date")]
        public DateTime SessionStartDate { get;set;}

        [Column(Name = "Session end date")]
        public DateTime SessionEndDate {get;set;}

        [Column(Name = "Subject name")]
        public string SubjectName {get;set;}

        [Column(Name = "Exam date")]
        public DateTime ExamDate  {get;set;}

    }
}
