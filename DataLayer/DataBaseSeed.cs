using EntityLayer.Entities;
using EntityLayer.Enums;
using EntityLayer.LookupEntitis;
using System.Text.Json;

namespace DataLayer;

public class DataBaseSeed
{
    public static async Task SeedAsync(DatabaseContext context)
    {
        if (!context.UserTypes.Any())
        {
            var userTypesData = File.ReadAllText("../DataLayer/SeedData/userTypes.json");
            var userTypes = JsonSerializer.Deserialize<List<UserTypeLookup>>(userTypesData);
            context.UserTypes.AddRange(userTypes);
        }

        //if (!context.Universities.Any())
        //{
        //    var universitiesData = File.ReadAllText("../DataLayer/SeedData/universities.json");
        //    var universities = JsonSerializer.Deserialize<List<University>>(universitiesData);
        //    context.Universities.AddRange(universities);
        //}

        if (!context.Courses.Any())
        {
            var coursesData = File.ReadAllText("../DataLayer/SeedData/courses.json");
            var courses = JsonSerializer.Deserialize<List<Course>>(coursesData);
            context.Courses.AddRange(courses);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

    }
}
