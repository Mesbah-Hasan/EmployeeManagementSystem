namespace EmployeeManagement.Shared.Models;

public class Complaint
{
    public int Id { get; set; }
    public DateTime SubmissionDate { get; set; }
    public string ComplainantName { get; set; } = string.Empty;
    public string ComplainantMobile { get; set; } = string.Empty;
    public string DesignationDepartment { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string ComplaintDetails { get; set; } = string.Empty;
    public string ActionTaken { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string ResolvingOfficer { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
}