namespace EmployeeManagementSystem;

public partial class EmployeePage : ContentPage
{
    public EmployeePage()
    {
        InitializeComponent();
    }

    private async void GoToDesignation(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Navigation",
            "Employee Designation Page will be created next.",
            "OK");
    }
}