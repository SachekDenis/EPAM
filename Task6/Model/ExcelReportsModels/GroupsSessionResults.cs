using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    [Table(Name = "SessionResults")]
    public class GroupsSessionResults
    {
        [Column(Name = "GroupName")]
        public string GroupName{get;set;}

        [Column(Name = "StudentFullname")]
        public string StudentFullName {get;set;}

        [Column(Name = "SessionStartDate")]
        public DateTime SessionStartDate { get;set;}

        [Column(Name = "SessionEndDate")]
        public DateTime SessionEndDate {get;set;}

        [Column(Name = "SubjectName")]
        public string SubjectName {get;set;}

        [Column(Name = "ExamDate")]
        public DateTime ExamDate  {get;set;}

    }
}
