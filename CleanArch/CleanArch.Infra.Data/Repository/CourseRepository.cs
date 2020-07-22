using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private UniversityDBContext _ctx;
        public CourseRepository(UniversityDBContext ctx)
        {
            this._ctx = ctx;
        }

        public Course GetCourseById(int courseId)
        {
            return _ctx.Courses.Find(courseId);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _ctx.Courses;
        }
    }
}
