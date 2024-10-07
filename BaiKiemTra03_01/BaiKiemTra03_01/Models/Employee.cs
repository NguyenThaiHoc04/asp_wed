namespace BaiKiemTra03_01.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public DateTime HireDate { get; set; }

        // Khóa ngoại liên kết tới lớp Department
        public Department Department { get; set; }
    }
}
