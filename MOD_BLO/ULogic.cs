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

        public MOD_DBEntities2 data = new MOD_DBEntities2();

        public IList<usign> GetAllUsers()
        {
            data.Configuration.ProxyCreationEnabled = false;
            return data.usigns.ToList();
        }

        public usign GetUserById(int id)
        {
            data.Configuration.ProxyCreationEnabled = false;

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
                    TrainerTechnology = usign.TrainerTechnology,
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
        //SkillDtls Logic
        public IList<SkillDtl> GetAllSkills()
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;
                return data.SkillDtls.ToList();
            }
            catch
            {
                throw;
            }

        }

        public List<SkillDtl> GetSkillsPrice(string id)
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;

                return data.SkillDtls.Where(x => x.name == id).ToList();
            }
            catch
            {
                throw;
            }

        }

        public IList<SkillDtl> GetSkillById(int id)
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;

                return data.SkillDtls.Where(x => x.id == id).ToList();
            }
            catch
            {
                throw;
            }

        }
        public void AddNewSkill(SkillDtl skillDtl)
        {
            try
            {
                data.SkillDtls.Add(skillDtl);
                data.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public void DeleteSkill(int id)
        {
            try
            {
                data.SkillDtls.Remove(data.SkillDtls.Find(id));
                data.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public void EditSkill(SkillDtl skillDtl)
        {
            try
            {
                data.Entry(skillDtl).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }

        }

        public List<usign> Search(string Data)
        {
            try
            {
                List<usign> mentors;
                mentors = data.usigns.Where(x => x.TrainerTechnology == Data).ToList();
                data.Configuration.ProxyCreationEnabled = false;

                return mentors;
            }
            catch
            {
                throw;
            }

        }

        //Save to Trainer Table
        public void addTrainingDtls(TrainingDtl trainingDtl)
        {
            try
            {
                var newTraining = new TrainingDtl()
                {
                    startDate = trainingDtl.startDate,
                    endDate = trainingDtl.endDate,
                    timeslot = trainingDtl.timeslot,
                    accept = trainingDtl.accept,
                    userId = trainingDtl.userId,
                    userName = trainingDtl.userName,
                    mentorId = trainingDtl.mentorId,
                    skillId = trainingDtl.skillId,
                    skillname = trainingDtl.skillname,
                    rejected = trainingDtl.rejected,
                    mentorName = trainingDtl.mentorName,

                };
                data.TrainingDtls.Add(newTraining);
                data.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        //get Training Data for showing approval
        public List<TrainingDtl> GetApproval()
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;

                List<TrainingDtl> dtls = data.TrainingDtls.ToList();
                return dtls;
            }
            catch
            {
                throw;
            }

        }

        //Approve and Rejected Training
        public void Approve(int id)
        {
            try
            {
                TrainingDtl user = data.TrainingDtls.Find(id);
                user.accept = true;
                user.rejected = false;
                data.Entry(user).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }

        }

        public void Declined(int id)
        {
            try
            {
                TrainingDtl user = data.TrainingDtls.Find(id);
                user.accept = false;
                user.rejected = true;
                data.Entry(user).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }

        }

        //Get Training Details for Payment
        public IList<TrainingDtl> TrainingById(int id)
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;
                return data.TrainingDtls.Where(x => x.id == id).ToList();
            }
            catch
            {
                throw;
            }
        }

        //payment
        public void addPayment(PaymentDtl paymentDtl)
        {
            try
            {
                var myPay = new PaymentDtl()
                {
                    txtType = paymentDtl.txtType,
                    userId = paymentDtl.userId,
                    mentorId = paymentDtl.mentorId,
                    skillId = paymentDtl.skillId,
                    skillName = paymentDtl.skillName,
                    fees = paymentDtl.fees,
                    mentorfees = paymentDtl.mentorfees,
                    commision = paymentDtl.commision,
                    PaymentStatus = paymentDtl.PaymentStatus
                };
                data.PaymentDtls.Add(myPay);
                data.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        //get all Payment
        public IList<PaymentDtl> GetAllPayment()
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;

                IList<PaymentDtl> dtl = data.PaymentDtls.ToList();
                return dtl;
            }
            catch
            {
                throw;
            }

        }

        //update Payment Status
        public void PayUpdate(int id)
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;
                TrainingDtl payStatus = data.TrainingDtls.Find(id);
                payStatus.PaymentStatus = true;
                data.Entry(payStatus).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }

        }

        //Update Training Progress
        public void UpdateProg(TrainingDtl updateData)
        {
            try
            {
                TrainingDtl prog = data.TrainingDtls.Find(updateData.id);
                prog.progress = updateData.progress;
                data.Entry(prog).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
        }

        //AdminCommision
        public void AdminCommision(PaymentDtl commision)
        {
            try
            {
                PaymentDtl paymentDtl = data.PaymentDtls.Find(commision.id);
                paymentDtl.commision = commision.commision;
                paymentDtl.fees = commision.fees;
                data.Entry(paymentDtl).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
        }

        //Updation Trainer Profile

        public void UpdateProfile(usign updateData)
        {
            try
            {
                usign usign = data.usigns.Find(updateData.id);
                usign.firstName = updateData.firstName;
                usign.lastName = updateData.lastName;
                usign.Phone = updateData.Phone;
                usign.YOE = updateData.YOE;
                data.Entry(usign).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
        }
    }
}
