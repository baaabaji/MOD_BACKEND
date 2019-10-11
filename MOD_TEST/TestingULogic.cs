using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD_DATA;
using MOD_BLO;
using NUnit;
using NUnit.Framework;

namespace MOD_TEST
{
    [TestFixture]
    public class TestingULogic
    {
        [Test]
        public void getAllUser()
        {
            ULogic ULogic = new ULogic();
            IList<usign> user = ULogic.GetAllUsers();
            Assert.IsNotNull(user);


            //mjbjafjadfjdfdjfadjfadjkffdjajkfafafdjkfdadkfkadfkadfkadjfkadfkajka
        }
        

        [Test]
        public void Register()
        {
            ULogic ULogic = new ULogic();
            usign user = new usign()
            {
                firstName = "sakshi",
                lastName = "raina",
                userName = "sakshiraina",
                Password = "12345678",
                Email = "sakshiraina@gmail.com",
                Phone = 9149850424,
                LinkedinURL = "www.linkkdin.com",
                YOE = 10,
                TrainerTechnology = "Jaava",
                active = true,
                role = 3,
            };
            ULogic.Register(user);
            usign user1 = ULogic.GetUserById(1021);
            Assert.IsNotNull(user1);
        }

        [Test]
        public void GetAllUser()
        {
            ULogic ULogic = new ULogic();
            IList<usign> p = ULogic.GetAllUsers();
            Assert.IsNotNull(p);
        }

        

        


        [Test]
        public void getskillbyid()
        {
            ULogic ULogic = new ULogic();
            IList<SkillDtl> p = ULogic.GetSkillById(2);
            Assert.IsNotNull(p);
        }
        [Test]
        public void addTrainingDtls()
        {
            ULogic ULogic = new ULogic();
            IList<TrainingDtl> p = ULogic.GetApproval();
            Assert.IsNotNull(p);
        }

    }
}
