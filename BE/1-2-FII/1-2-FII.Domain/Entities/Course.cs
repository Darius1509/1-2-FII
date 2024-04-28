using _1_2_FII.Domain.Common;

namespace _1_2_FII.Domain.Entities
{
    public class Course
    {
        public Course(string courseName, string courseDescription, int courseSemester, int courseNrOfCredits, string courseWebsite)
        {
            CourseId= Guid.NewGuid();
            CourseName = courseName;
            CourseDescription = courseDescription;
            CourseSemester = courseSemester;
            CourseNrOfCredits = courseNrOfCredits;
            CourseWebsite = courseWebsite;
        }

        public Guid CourseId { get; private set; }
        public string CourseName { get; private set; }
        public string CourseDescription { get; private set; }
        public int CourseSemester { get; private set; }
        public int CourseNrOfCredits { get; private set; }
        public string CourseWebsite { get; private set; }

        public static Result<Course> Create(string courseName, string courseDescription, int courseSemester, int courseNrOfCredits, string courseWebsite)
        {
            var validation = ValidateParameters(courseName, courseDescription, courseSemester, courseNrOfCredits, courseWebsite);
            if (validation != null)
            {
                return validation;
            }
            return Result<Course>.Success(new Course(courseName, courseDescription, courseSemester, courseNrOfCredits, courseWebsite));
        }

        public static Result<Course> Update(Guid courseId, string courseName, string courseDescription, int courseSemester, int courseNrOfCredits, string courseWebsite)
        {
            var validation = ValidateParameters(courseName, courseDescription, courseSemester, courseNrOfCredits, courseWebsite);
            if (validation != null)
            {
                return validation;
            }
            var course = new Course(courseName, courseDescription, courseSemester, courseNrOfCredits, courseWebsite)
            {
                CourseId = courseId
            };
            return Result<Course>.Success(course);
        }

        private static Result<Course>? ValidateParameters(string courseName, string courseDescription, int courseSemester, int courseNrOfCredits, string courseWebsite)
        {
            if (string.IsNullOrWhiteSpace(courseName))
            {
                return Result<Course>.Failure("Course name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(courseDescription))
            {
                return Result<Course>.Failure("Course description cannot be empty");
            }
            if (courseSemester <= 0 || courseSemester > 6)
            {
                return Result<Course>.Failure("Course semester must be greater than 0 and smaller or equal to 6");
            }
            if (courseNrOfCredits < 4 || courseNrOfCredits > 6)
            {
                return Result<Course>.Failure("Course number of credits must be between 4 and 6");
            }
            if (string.IsNullOrWhiteSpace(courseWebsite))
            {
                return Result<Course>.Failure("Course website cannot be empty");
            }
            return null;
        }
    }
}
