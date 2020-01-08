using ShowRank.Domain.Models;
using ShowRank.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.ExtensionMethods
{
    public static class ModelsExtensionMethods
    {
        public static Admin ToDTO(this GeneralAdminRequest request)
        {
            return new Admin
            {
                Email = request.Email,
                PasswordHash = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
        }

        public static Admin ToDTO(this GeneralAdminRequest request, string id)
        {
            return new Admin
            {
                Email = request.Email,
                PasswordHash = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Id = id
            };
        }

        public static FollowsTable ToDTO(this GeneralFollowsTableRequest request)
        {
            return new FollowsTable
            {
                IdOfTheOneWhoFollows = request.IdOfTheOneWhoFollows,
                IdOfWhoIsBeingFollowed = request.IdOfWhoIsBeingFollowed
            };
        }

        public static FollowsTable ToDTO(this GeneralFollowsTableRequest request, string id)
        {
            return new FollowsTable
            {
                IdOfTheOneWhoFollows = request.IdOfTheOneWhoFollows,
                IdOfWhoIsBeingFollowed = request.IdOfWhoIsBeingFollowed,
                Id = id
            };
        }

        public static Post ToDTO(this GeneralPostRequest request)
        {
            return new Post
            {
                IdOfProfile = request.IdOfProfile,
                NameOfTheShow = request.NameOfTheShow,
                Opinion = request.Opinion,
                RatingValue = request.RatingValue,
                ShowType = request.ShowType,
                Date = request.Date
            };
        }

        public static Post ToDTO(this GeneralPostRequest request, string id)
        {
            return new Post
            {
                IdOfProfile = request.IdOfProfile,
                NameOfTheShow = request.NameOfTheShow,
                Opinion = request.Opinion,
                RatingValue = request.RatingValue,
                ShowType = request.ShowType,
                Date = request.Date,
                Id = id
            };
        }

        public static Profile ToDTO(this GeneralProfileRequest request)
        {
            return new Profile
            {
                Email = request.Email,
                FirstName = "request.FirstName",
                FollowersNumber = 0,
                FollowingNumber = 0,
                HelpsNumber = 0,
                LastName = "request.LastName",
                PasswordHash = "2do"
            };
        }

        public static Profile ToDTO(this GeneralProfileRequest request, string id)
        {
            return new Profile
            {
                Email = request.Email,
                FirstName = "request.FirstName",
                FollowersNumber = 0,
                FollowingNumber = 0,
                HelpsNumber = 0,
                LastName = "request.LastName",
                PasswordHash = "2do",
                Id = id
            };
        }

        public static ToSeeListItem ToDTO(this GeneralToSeeListItemRequest request)
        {
            return new ToSeeListItem
            {
                IdOfProfile = request.IdOfProfile,
                IdOfPost = request.IdOfPost
            };
        }

        public static ToSeeListItem ToDTO(this GeneralToSeeListItemRequest request, string id)
        {
            return new ToSeeListItem
            {
                IdOfProfile = request.IdOfProfile,
                IdOfPost = request.IdOfPost,
                Id = id
            };
        }

        public static Profile ToDTO(this RegisterProfileRequest request)
        {
            return new Profile
            {
                FirstName = request.FirstName,
                FollowersNumber = 0,
                FollowingNumber = 0,
                HelpsNumber = 0,
                LastName = request.LastName,
                Bio = request.Bio
            };
        }
    }
}
