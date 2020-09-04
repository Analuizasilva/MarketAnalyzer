using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.UserViewModel
{
    public class ProfileViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public static ProfileViewModel Parse(Profile profile)
        {
            return new ProfileViewModel()
            {
                BirthDate = profile.BirthDate,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                Id = profile.Id
            };
        }

        public Profile ToProfile()
        {
            return new Profile(FirstName, LastName, Email, BirthDate);
        }

        public Profile ToModel()
        {
            return new Profile(FirstName, LastName, Email, BirthDate);
        }

        public Profile ToModel(Profile model)
        {
            model.BirthDate = BirthDate;
            model.FirstName = FirstName;
            model.LastName = LastName;
            model.Email = Email;
            return model;
        }

        public bool CompareToModel(Profile model)
        {
            return BirthDate == model.BirthDate && FirstName == model.FirstName && LastName == model.LastName && Email == model.Email;
        }
    }
}
