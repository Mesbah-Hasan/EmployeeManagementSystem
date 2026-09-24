namespace EmployeeManagement.Api.Models;

public class Complaint
{
    public int Id { get; set; }
    public DateTime SubmissionDate { get; set; }           // তারিখ প্রদান করুন
    public string ComplainantName { get; set; } = string.Empty;      // অভিযোগকারীর নাম
    public string ComplainantMobile { get; set; } = string.Empty;    // অভিযোগকারীর মোবাইল
    public string DesignationDepartment { get; set; } = string.Empty; // অভিযোগকারীর পদবী ও বিভাগ
    public string CompanyName { get; set; } = string.Empty;          // কোম্পানির নাম
    public string ComplaintDetails { get; set; } = string.Empty;     // অভিযোগের বিবরণ
    public string ActionTaken { get; set; } = string.Empty;          // গৃহীত ব্যবস্থা
    public string Status { get; set; } = string.Empty;               // মুলতবি/প্রক্রিয়াধীন/নিষ্পন্ন
    public string ResolvingOfficer { get; set; } = string.Empty;     // নিষ্পত্তিকারী কর্মকর্তা
    public string Comments { get; set; } = string.Empty;             // মন্তব্য
}