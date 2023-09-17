﻿using SpeakHub.Domain.Entities.Admins;
using SpeakHub.Domain.Enums;

namespace SpeakHub.Service.ViewModels.AdminViewModels
{
    public class AdminViewModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string ImagePath { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; } = default!;

        public string Address { get; set; } = String.Empty;

        public Role Role { get; set; } = Role.Admin;

        public DateTime CreatedAt { get; set; } = default!;

        public static implicit operator AdminViewModel(Admin model)
        {
            return new AdminViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ImagePath = model.Image!,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                CreatedAt = model.CreatedAt
            };
        }
    }
}
