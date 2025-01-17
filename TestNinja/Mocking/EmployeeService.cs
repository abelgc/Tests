namespace TestNinja.Mocking
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeContext _db;

        public EmployeeService()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            if (id >= 0) return;
            var employee = _db.Employees.Find(id);
            if (employee == null) return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();

        }
    }
}
