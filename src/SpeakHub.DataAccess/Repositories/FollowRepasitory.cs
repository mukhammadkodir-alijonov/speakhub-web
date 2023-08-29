using Microsoft.EntityFrameworkCore;
using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Domain.Entities.Followers;
using SpeakHub.Domain.Entities.Users;
using System.Data.Common;

namespace SpeakHub.DataAccess.Repositories
{
    public class FollowRepasitory : GenericRepository<Follower>, IFollowRepasitory
    {
        //private readonly ILogger _logger;
        private readonly AppDbContext _appDbConext;

        public FollowRepasitory(AppDbContext appDbContext) : base(appDbContext)//ILogger logger
        {
            //this._logger = logger;
            this._appDbConext = appDbContext;
            /*            var followings = appDbContext
                .Follows
                .Where(w => w.UserId == 1)
                .Include(i => i.Follower)
                .AsNoTracking()
                .ToListAsync();

            var followers = appDbContext
                .Follows
                .Where(w => w.FollowerId == 1)
                .Include(i => i.Follower)
                .AsNoTracking()
                .ToListAsync();*/
        }
        /*      public async Task<List<Follower>> GetFollowingsAsync(int userId)
                {
                    var followings = await _appDbConext.Follows
                        .Where(w => w.UserId == userId)
                        .Include(i => i.Follower)
                        .AsNoTracking()
                        .ToListAsync();

                    return followings;
                }
                public async Task<List<Follower>> GetFollowersAsync(int followerId)
                {
                    var followers = await _appDbConext.Follows
                        .Where(w => w.FollowerId == followerId)
                        .Include(i => i.Follower)
                        .AsNoTracking()
                        .ToListAsync();

                    return followers;
                }*/

        // Logic: If A follow B
        // Following(A) + B and Follower(B) + A
        public async Task<bool> FollowAsync(int _userId1, int _userId2)
        {
            try
            {
                UserProfile UserA = await _appDbConext.UserProfiles.FirstOrDefaultAsync(u => u.Id == _userId1);
                UserProfile UserB = await _appDbConext.UserProfiles.FirstOrDefaultAsync(u => u.Id == _userId2);

                if (UserA != null || UserB != null)
                {
                    Following B = new Following
                    {
                        UserId = UserB!.Id,
                        CreatedAt = DateTime.UtcNow,
                        User = UserB,
                    };
                    Follower A = new Follower
                    {
                        UserId = UserA!.Id,
                        CreatedAt = DateTime.UtcNow,
                        User = UserA,
                    };
                    UserA.Followings.Add(B);
                    UserB.Followers.Add(A);
                    await _appDbConext.SaveChangesAsync();
                    return true;
                }
                else
                    //_logger.LogInformation($"User with Id {_userId1} or {_userId2} not found.");
                    return false;

            }
            catch (DbException)//ex
            {
                //_logger.LogInformation("Database error occurred: {Message}", ex.Message);
                return false;
            }
            catch (Exception)//ex
            {
                //_logger.LogInformation("An unexpected error occurred: {Message}", ex.Message);
                return false;
            }
        }

        // Logic: If A unfollow B
        // Following(A) - B and Follower(B) - A
        public async Task<bool> UnfollowAsync(int _userId1, int _userId2)
        {
            try
            {
                UserProfile UserA = await _appDbConext.UserProfiles.FirstOrDefaultAsync(u => u.Id == _userId1);
                UserProfile UserB = await _appDbConext.UserProfiles.FirstOrDefaultAsync(u => u.Id == _userId2);
                if (UserA != null && UserB != null)
                {
                    Following B = UserA.Followings.FirstOrDefault(f => f.UserId == UserB.UserId);
                    Follower A = UserB.Followers.FirstOrDefault(f => f.UserId == UserA.UserId);

                    if (B != null && A != null)
                    {
                        UserA.Followings.Remove(B);
                        UserB.Followers.Remove(A);
                        await _appDbConext.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)//ex
            {
                //_logger.LogInformation("An unexpected error occurred:{Message}",ex.Message);
                return false;
            }
        }
    }
}
