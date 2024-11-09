using System.ComponentModel.DataAnnotations;
namespace StudyAspDotnetCore.Models;

public partial class Profile : IRecordableTimestamp
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(50)]
    [Display(Name = "名")]

    public required string FirstName { get; set; }
    [MaxLength(50)]
    [Display(Name = "姓")]

    public required string LastName { get; set; }
    [MaxLength(50)]
    [Display(Name = "名（かな）")]

    public required string FirstNameKana { get; set; }
    [MaxLength(50)]
    [Display(Name = "姓（かな）")]

    public required string LastNameKana { get; set; }
    [MaxLength(1)]
    [RegularExpression("0|1|2|9")]
    [Display(Name = "性別")]

    public required string Sex { get; set; } = "0";
    [Display(Name = "誕生日")]

    public DateOnly? BirthDay { get; set; }
    [MaxLength(11)]
    [Display(Name = "携帯電話番号")]

    public string? CellPhoneNumber { get; set; }
    [Display(Name = "メモ")]

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }
}
