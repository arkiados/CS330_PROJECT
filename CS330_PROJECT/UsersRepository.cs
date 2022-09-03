namespace CS330_PROJECT
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void AddUser(User user);
        bool ModifyUser(int id, User user);
        bool DeleteUser(int id);
    }

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> Users
        {
            get
            {
                var items = new[]
                    {
                    new User { Id = 0, Email = "bobi@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 1, Email = "jill@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 2, Email = "john@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 3, Email = "fred@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 4, Email = "sam@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 5, Email = "fran@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 6, Email = "bill@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 7, Email = "erin@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 8, Email = "tom@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                    new User { Id = 9, Email = "ron@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
                };
                return items;
            }
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool ModifyUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
