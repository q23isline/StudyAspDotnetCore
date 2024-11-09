using Microsoft.EntityFrameworkCore;

namespace StudyAspDotnetCore.Models;

public static class Seed
{
    public static async Task Initialize(IServiceProvider provider)
    {
        using var db = new MyContext(provider.GetRequiredService<DbContextOptions<MyContext>>());
        if (await db.Profiles.AnyAsync()) { return; }
        db.Profiles.AddRange(
            new Profile
            {
                FirstName = "管理者",
                LastName = "システム",
                FirstNameKana = "かんりしゃ",
                LastNameKana = "しすてむ",
                Sex = "9",
                BirthDay = new DateOnly(2024, 01, 01),
                CellPhoneNumber = "09000000000",
                Remarks = "管理者のプロフィールです。"
            }
        );
        await db.SaveChangesAsync();
    }
}
