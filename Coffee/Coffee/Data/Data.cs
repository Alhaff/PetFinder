using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Coffee.Models;

namespace Coffee.Data
{
    public class Database
    {
        SQLiteAsyncConnection _database;
        public User LoginedUser { get; set; }
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Agreement>().Wait();
            _database.CreateTableAsync<Pet>().Wait();
            _database.CreateTableAsync<PetType>().Wait();
            _database.CreateTableAsync<PetShelter>().Wait();
            _database.CreateTableAsync<Post>().Wait();
        }

       

        public Task<List<User>> DeleteAllData()
        {
            // _database.QueryAsync<CoffeeData>("DELETE FROM CoffeeData");
            _database.QueryAsync<Pet>("DELETE FROM Post");
            _database.QueryAsync<Pet>("DELETE FROM Pet");
            _database.QueryAsync<Agreement>("DELETE FROM Agreement");
            return _database.QueryAsync<User>("DELETE FROM User");          
        }
        public Task<List<PetShelter>> DeleteSomeData()
        {
            // _database.QueryAsync<CoffeeData>("DELETE FROM CoffeeData");
            _database.QueryAsync<Post>("DELETE FROM Post");
            _database.QueryAsync<Pet>("DELETE FROM Pet WHERE ID > 10");
            _database.QueryAsync<PetType>("DELETE FROM PetType WHERE ID > 4");
            return _database.QueryAsync<PetShelter>("DELETE FROM PetShelter WHERE ID > 3");
        }

        public Task<List<Agreement>> GetOrderList(User user)
        {
            return _database.Table<Agreement>()
                            .Where(i => i.UserID == user.ID)
                            .ToListAsync();
        }
        public Task<List<Pet>> GetPetList()
        {
            return _database.Table<Pet>().ToListAsync();
        }
        public Task<List<PetType>> GetPetTypeList()
        {
            return _database.Table<PetType>().ToListAsync();
        }
        public Task<List<Post>> GetPostList()
        {
            return _database.Table<Post>().ToListAsync();
        }

        public async Task<List<Tuple<Post,Pet>>> GetPostPetPair()
        {
           List<Post> posts =  await _database.Table<Post>().ToListAsync();
           List<Pet> pets = await _database.Table<Pet>().ToListAsync();
           List<PetType> petTypes = await _database.Table<PetType>().ToListAsync();
           List<PetShelter> petShelters = await _database.Table<PetShelter>().ToListAsync();
           List<Tuple< Post,Pet>> tuples = new List<Tuple<Post,Pet>>();
           foreach (var post in posts)
           {
                tuples.Add(Tuple.Create(post, pets.Find(pet => pet.ID == post.PetID)));
           }
            return tuples;
        }
        public async Task<List<Tuple<Post, Pet, PetShelter>>> GetPostPetShelterPair(Tuple<Post,Pet> tuple)
        {
            List<PetShelter> petShelters = await _database.Table<PetShelter>().ToListAsync();
            List<Tuple<Post, Pet,PetShelter>> tuples = new List<Tuple<Post, Pet,PetShelter>>();
            tuples.Add(Tuple.Create(tuple.Item1, tuple.Item2, petShelters.Find(shelter => shelter.ID == tuple.Item2.ShelterID)));
            return tuples;
        }

        //public Task<List<CoffeeData>> GetCoffeeList(Agreement order)
        //{
        //    return _database.Table<CoffeeData>()
        //                    .Where(i => i.OrderID == order.ID)
        //                    .ToListAsync();
        //}

        public Task<int> SaveCustomer(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> SavePet(Pet pet)
        {
            if (pet.ID != 0)
            {
                return _database.UpdateAsync(pet);
            }
            else
            {
                return _database.InsertAsync(pet);
            }
        }

        public Task<int> SavePost(Post post)
        {
            if (post.ID != 0)
            {
                return _database.UpdateAsync(post);
            }
            else
            {
                return _database.InsertAsync(post);
            }
        }

        public Task<int> SavePetType(PetType type)
        {
            if (type.ID != 0)
            {
                return _database.UpdateAsync(type);
            }
            else
            {
                return _database.InsertAsync(type);
            }
        }



        public Task<int> SavePetShelter(PetShelter shelter)
        {
            if (shelter.ID != 0)
            {
                return _database.UpdateAsync(shelter);
            }
            else
            {
                return _database.InsertAsync(shelter);
            }
        }

        public Task<User> GetCustomer(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveOrder(Agreement order)
        {
            if (order.ID != 0)
            {
                return _database.UpdateAsync(order);
            }
            else
            {
                return _database.InsertAsync(order);
            }
        }

        public Task<Agreement> GetOrder(int id)
        {
            return _database.Table<Agreement>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Pet> GetPet(int id)
        {
            return _database.Table<Pet>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        //public Task<int> SaveCoffee(CoffeeData coffee)
        //{
        //    if (coffee.ID != 0)
        //    {
        //        return _database.UpdateAsync(coffee);
        //    }
        //    else
        //    {
        //        return _database.InsertAsync(coffee);
        //    }
        //}

        public Task<User> CheckCredentials(string username, string password)
        {
            return _database.Table<User>()
                .Where(i => i.UserName == username && i.Password == password)
                .FirstOrDefaultAsync();
        }

        public Task<User> UserNameExists(string username, string email)
        {
            return _database.Table<User>()
                .Where(i => i.UserName == username && i.EmailAddress == email)
                .FirstOrDefaultAsync();
        }

        public Task<User> ChangePasswordFromEmail(string email)
        {
            return _database.Table<User>()
                .Where(i => i.EmailAddress == email)
                .FirstOrDefaultAsync();
        }

    }
}
