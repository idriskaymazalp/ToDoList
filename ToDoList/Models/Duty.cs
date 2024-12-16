using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Duty
    {
        
        public int DutyId {  get; set; }
        public string DutyNote { get; set; }
        public bool IsCompleted { get; set; }
    }
}