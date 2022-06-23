using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranSmart.DTO
{
    public class TaskDTO
    {
        public Guid TaskID { get; set; }
        public Guid ProjectID { get; set; }
        public Guid TranslatorID { get; set; }
        public Guid ReviewerID { get; set; }
        public string TaskFile { get; set; }
        public string TaskDescription { get; set; }
        public long WordCount { get; set; }
        public DateTime TranslatorDeadLine { get; set; }
        public DateTime ReviewerDeadLine { get; set; }
        public DateTime? isMailSentToTranslator { get; set; }
        public DateTime? isMailSentToReviewer { get; set; }
    }
    public class TaskListDTO
    {
        public Guid ProjectID { get; set; }
        public Guid TaskID { get; set; }
        public string ProjectSerial { get; set; }
        public string TaskSerial { get; set; }
        public string TranslatorName { get; set; }
        public string ReviewerName { get; set; }
        public string TaskStatus { get; set; }
        public long WordCount { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public string LastEditedDate { get; set; }
    }
    public class TaskDetailsDTO
    {
        public Guid TaskID { get; set; }
        public Guid ProjectID { get; set; }
        public string TaskSerial { get; set; }
        public long? ProjectWords { get; set; }
        public long? TasksWords { get; set; }
        public long? WordCount { get; set; }
        public string TaskDescription { get; set; }
        public Guid? TranslatorID { get; set; }
        public Guid? ReviewerID { get; set; }
        public string ProjectManager { get; set; }
        public string TaskStatus { get; set; }
        public DateTime? TranslatorDeadLine { get; set; }
        public DateTime? isTranslatorReceived { get; set; }
        public DateTime? isTranslatorProgress { get; set; }
        public DateTime? isTranslatorDone { get; set; }
        public DateTime ReviewerDeadLine { get; set; }
        public DateTime? isReviewerReceived { get; set; }
        public DateTime? isReviewerProgress { get; set; }
        public DateTime? isReviewerDone { get; set; }
        public DateTime? ProjectPromiseDeliveryDate { get; set; }
        public string TaskFile { get; set; }
        public string TranslatorFile { get; set; }
        public string ReviewerFile { get; set; }
        public decimal? TranslatorQuality { get; set; }
        public int? TranslatorDelay { get; set; }
        public decimal? ReviewerQuality { get; set; }
        public int? ReviewerDelay { get; set; }
        public string SourceLangg { get; set; }
        public string TargetLangg { get; set; }
        public DateTime? isMailSentToTranslator { get; set; }
        public DateTime? isMailSentToReviewer { get; set; }
    }

    public class NewTaskDetailsDTO
    {
        public string TaskSerial { get; set; }
        public long ProjectWords { get; set; }
        public long? TasksWords { get; set; }
        public DateTime? ProjectPromiseDeliveryDate { get; set; }
    }
}