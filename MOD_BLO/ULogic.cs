using MOD_DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MOD_BLO
{
    public class ULogic
    {

        public MOD_DBEntities data = new MOD_DBEntities();

        public IList<usign> GetAllUsers()
        {
            return data.usigns.ToList();
        }

        public usign GetUserById(int id)
        {
            return data.usigns.Find(id);
        }

        public void Register(usign usign)
        {
            //Adding Trainer
            if (usign.role == 2)
            {
                var newTrainer = new usign()
                {
                    userName = usign.userName,
                    Password = usign.Password,
                    Email = usign.Email,
                    firstName = usign.firstName,
                    lastName = usign.lastName,
                    Phone = usign.Phone,
                    LinkedinURL = usign.LinkedinURL,
                    YOE = usign.YOE,
                    role = usign.role,
                    //confirmedSignUp=usign.confirmedSignUp,
                    profile = usign.profile,
                    active = usign.active


                };
                data.usigns.Add(newTrainer);
                data.SaveChanges();

            }

            //Adding User
            else if (usign.role == 3)
            {
                var newUser = new usign()
                {
                    userName = usign.userName,
                    Password = usign.Password,
                    Email = usign.Email,
                    firstName = usign.firstName,
                    lastName = usign.lastName,
                    Phone = usign.Phone,
                    role = usign.role,
                    LinkedinURL = usign.LinkedinURL,
                    active = usign.active

                    //yearOfExperience = usign.yearOfExperience,
                    //linkdinUrl = usign.linkdinUrl,

                };
                data.usigns.Add(newUser);
                data.SaveChanges();
            }

            //save data to database

        }

        public void BlockUser(int id)
        {
            usign user = data.usigns.Find(id);
            user.active = false;
            data.Entry(user).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            //ata.usigns.Remove(user);
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        public void UnBlockUser(int id)
        {
            usign user = data.usigns.Find(id);
            user.active = true;
            data.Entry(user).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        public void UpdateUser(usign usign)
        {
            data.Entry(usign).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        //Sigin in 

        public usign login(string email, string password)
        {
            usign my = data.usigns.SingleOrDefault(x => x.Email == email && x.Password == password);
            return my;

        }
    }
}
