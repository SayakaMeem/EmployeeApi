using System.ComponentModel.DataAnnotations;
public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; } = "";
    [Range(18,65)]
    public int Age { get; set; }
    public string Department { get; set; } = "";
}