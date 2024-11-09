using System.ComponentModel.DataAnnotations;
namespace StudyAspDotnetCore.Models;
public interface IRecordableTimestamp
{
    [Display(Name = "作成日")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "更新日")]
    public DateTime LastUpdatedAt { get; set; }
}
