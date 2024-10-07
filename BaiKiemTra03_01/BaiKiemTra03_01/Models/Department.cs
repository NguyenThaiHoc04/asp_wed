namespace BaiKiemTra03_01.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int NumberOfEmployees { get; set; }
        public int? ManagerDepartmentId { get; set; } // Phòng ban quản lý (có thể null nếu không có)

        // Liên kết với danh sách nhân viên thuộc phòng ban
        public ICollection<Employee> Employees { get; set; }
    }
}
