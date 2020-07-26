using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface IuserService
    {
        CheckUser CheckUser(string username, string email);
        int RegisterUser(User user);
    }
}
